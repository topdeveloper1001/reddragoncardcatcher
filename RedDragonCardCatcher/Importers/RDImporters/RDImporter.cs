//-----------------------------------------------------------------------
// <copyright file="RDImporter.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using ConcurrentCollections;
using HandHistories.Objects.Hand;
using HandHistories.Objects.Players;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RedDragonCardCatcher.Common.Extensions;
using RedDragonCardCatcher.Common.Linq;
using RedDragonCardCatcher.Common.Log;
using RedDragonCardCatcher.Licensing;
using RedDragonCardCatcher.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedDragonCardCatcher.Importers
{
    internal class RDImporter : BaseImporter, IRDImporter
    {
        private const int NoDataDelay = 200;
        private const int ShowPreHUDDelay = 2500;
        private const int DelayToProcessHands = 2000;
        private readonly BlockingCollection<PipeData> packetBuffer = new BlockingCollection<PipeData>();
        private IProtectedLogger protectedLogger;
        private IDatabaseService databaseService;
        private readonly ILicenseService licenseService;

        public override string ImporterName => "RDImporter";

#if DEBUG        
        private Dictionary<RDPackageType, MethodInfo> LogPackageMapping { get; } = new Dictionary<RDPackageType, MethodInfo>();
#endif

        public RDImporter()
        {
            licenseService = ServiceLocator.Current.GetInstance<ILicenseService>();
#if DEBUG
            RDPackageTypeEnumerator.ForEach((RDPackageType enumValue, Type packageObjectType) =>
            {
                Action<RDPackage> action = LogPackage<HeartbeatResponse>;
                MethodInfo method = action.Method.GetGenericMethodDefinition();
                MethodInfo generic = method.MakeGenericMethod(packageObjectType);

                LogPackageMapping[enumValue] = generic;
            });
#endif
        }

        public void AddPackage(PipeData pipeData)
        {
            if (!IsRunning)
            {
                return;
            }

            packetBuffer.Add(pipeData);
        }

        protected override void DoImport()
        {
            try
            {
                InitializeLogger();
                InitializeSettings();
                ProcessBuffer();
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"General failure in processing of buffer data.", e);
            }

            isRunning = false;
            packetBuffer.Clear();

            RaiseProcessStopped();
        }

        /// <summary>
        /// Reads settings and initializes importer variables
        /// </summary>
        private void InitializeSettings()
        {
            var settings = Settings.GetSettings();

            databaseService = ServiceLocator.Current.GetInstance<IDatabaseService>(settings.Database.ToString());
            databaseService.IsAdvancedLogEnabled = settings.IsAdvancedLoggingEnabled;
        }

        /// <summary>
        /// Processes buffer data
        /// </summary>
        private void ProcessBuffer()
        {
            var dataManager = ServiceLocator.Current.GetInstance<IDataManager>();
            var handBuilder = ServiceLocator.Current.GetInstance<IRDHandBuilder>();
            var detectedTables = new ConcurrentHashSet<IntPtr>();
            var handHistoriesToProcess = new ConcurrentDictionary<long, List<HandHistoryData>>();
            var outOfRoomTasks = new ConcurrentDictionary<IntPtr, OutOfRoomTask>();

            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    if (!packetBuffer.TryTake(out PipeData capturedData))
                    {
                        Task.Delay(NoDataDelay).Wait();
                        continue;
                    }

                    var data = dataManager.ProcessData(capturedData.Data);
#if DEBUG
                    // LogPacket(capturedData);
#endif
                    if (!RDPackage.TryParse(data, out RDPackage package))
                    {
                        continue;
                    }

                    LogPackage(package, capturedData.WindowHandle);

                    if (!IsAllowedPackage(package))
                    {
                        continue;
                    }

                    if (!detectedTables.Contains(capturedData.WindowHandle))
                    {
                        detectedTables.Add(capturedData.WindowHandle);

                        outOfRoomTasks.TryAdd(capturedData.WindowHandle, new OutOfRoomTask());

                        if (package.PackageType == RDPackageType.JoinRoomResponse ||
                            package.PackageType == RDPackageType.JoinSNGRoomResponse ||
                            package.PackageType == RDPackageType.JoinMTTRoomResponse
                            || handBuilder.IsRoomInfoAvailable(capturedData.WindowHandle))
                        {
                            LogProvider.Log.Info(this, $"User entered room. [{capturedData.WindowHandle}]");
                            databaseService.SendShowHUDRequest("Notifications_HudLayout_PreLoadingText_Init", capturedData.WindowHandle);
                        }
                        else
                        {
                            LogProvider.Log.Info(this, $"Room was opened before catcher. Data can't be captured. [{capturedData.WindowHandle}]");
                            databaseService.SendWarningRequest("Notifications_HudLayout_PreLoadingText_CanNotBeCapturedText", capturedData.WindowHandle);
                        }
                    }

                    if (outOfRoomTasks.TryGetValue(capturedData.WindowHandle, out OutOfRoomTask outOfRoomTask))
                    {
                        outOfRoomTask.Cancel();
                    }

                    if (handBuilder.TryBuild(package, capturedData.WindowHandle, out HandHistory handHistory))
                    {
                        LogProvider.Log.Info(this, $"Hand #{handHistory.HandId} captured: tablename={handHistory.TableName}, room={handHistory.GameDescription?.Identifier},windows={capturedData.WindowHandle}.");

                        var handHistoryData = new HandHistoryData
                        {
                            Uuid = capturedData.WindowHandle.ToInt32(),
                            HandHistory = handHistory,
                            WindowHandle = capturedData.WindowHandle
                        };

                        if (!licenseService.IsMatch(handHistory))
                        {
                            LogProvider.Log.Info(this, $"License doesn't support cash hand #{handHistory.HandId}. BB={handHistory.GameDescription.Limit.BigBlind} [{capturedData.WindowHandle}]");
                            databaseService.SendWarningRequest("Notifications_HudLayout_PreLoadingText_NoLicense", capturedData.WindowHandle);
                            continue;
                        }

                        ExportHandHistory(handHistoryData, handHistoriesToProcess);
                    }

                    if (package.PackageType == RDPackageType.OutRoomResponse ||
                        package.PackageType == RDPackageType.OutSngRoomResponse ||
                        package.PackageType == RDPackageType.AdvOutRoomResponse)
                    {
                        outOfRoomTask?.Run(() =>
                        {
                            LogProvider.Log.Info(this, $"User left room. [{capturedData.WindowHandle}]");

                            SendCloseHUDRequest(capturedData.WindowHandle);
                            detectedTables.TryRemove(capturedData.WindowHandle);
                        });
                    }
                }
                catch (Exception e)
                {
                    LogProvider.Log.Error(this, $"Failed to process buffered data.", e);
                }
            }

            protectedLogger?.StopLogging();
        }

        private static bool IsAllowedPackage(RDPackage package)
        {
            switch (package.PackageType)
            {
                case RDPackageType.JoinRoomResponse:
                case RDPackageType.JoinSNGRoomResponse:
                case RDPackageType.JoinMTTRoomResponse:
                case RDPackageType.OutRoomResponse:
                case RDPackageType.OutSngRoomResponse:
                case RDPackageType.AdvOutRoomResponse:
                case RDPackageType.RaceMTTResponse:
                case RDPackageType.NotifyGainsResponse:
                case RDPackageType.NotifyNextRoundStartRoomResponse:
                case RDPackageType.NotifyNextRoundStartResponse:
                case RDPackageType.PlayerCallResponse:
                case RDPackageType.PlayerFoldResponse:
                case RDPackageType.PlayerCheckResponse:
                case RDPackageType.PlayerRaiseResponse:
                case RDPackageType.NotifyFlopRoundResponse:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Exports captured hand history to the supported DB
        /// </summary>
        private void ExportHandHistory(HandHistoryData handHistoryData, ConcurrentDictionary<long, List<HandHistoryData>> handHistoriesToProcess)
        {
            var handId = handHistoryData.HandHistory.HandId;

            if (!handHistoriesToProcess.TryGetValue(handId, out List<HandHistoryData> handHistoriesData))
            {
                handHistoriesData = new List<HandHistoryData>();
                handHistoriesToProcess.AddOrUpdate(handId, handHistoriesData, (key, prev) => handHistoriesData);

                Task.Run(() =>
                {
                    try
                    {
                        Task.Delay(DelayToProcessHands).Wait(cancellationTokenSource.Token);
                        ExportHandHistory(handHistoriesData.ToList());
                    }
                    catch (OperationCanceledException)
                    {
                        return;
                    }
                    finally
                    {
                        handHistoriesToProcess.TryRemove(handId, out List<HandHistoryData> removedData);
                    }
                });
            }

            handHistoriesData.Add(handHistoryData);
        }

        /// <summary>
        /// Exports captured hand history to the supported DB
        /// </summary>
        private void ExportHandHistory(List<HandHistoryData> handHistories)
        {
            // merge hands
            var playerWithHoleCards = handHistories
                .SelectMany(x => x.HandHistory.Players)
                .Where(x => x.hasHoleCards)
                .DistinctBy(x => x.SeatNumber)
                .ToDictionary(x => x.SeatNumber, x => x.HoleCards);

            foreach (var handHistoryData in handHistories)
            {
                handHistoryData.HandHistory.Players.ForEach(player =>
                {
                    if (!player.hasHoleCards && playerWithHoleCards.ContainsKey(player.SeatNumber))
                    {
                        player.HoleCards = playerWithHoleCards[player.SeatNumber];
                    }
                });

                handHistoryData.HandHistory.Players = GetPlayerList(handHistoryData.HandHistory);

#if DEBUG
                var handHistoryText = SerializationHelper.SerializeObject(handHistoryData.HandHistory);

                if (!Directory.Exists("Hands"))
                {
                    Directory.CreateDirectory("Hands");
                }

                File.WriteAllText($"Hands\\hand_exported_{handHistoryData.Uuid}_{handHistoryData.HandHistory.HandId}.xml", handHistoryText);
#endif

                databaseService.Import(handHistoryData);
            }
        }

        /// <summary>
        /// Creates logger to log pipe data
        /// </summary>
        /// <returns></returns>
        private ProtectedLoggerConfiguration CreateProtectedLoggerConfiguration()
        {
            var logger = new ProtectedLoggerConfiguration
            {
                DateFormat = "yyy-MM-dd",
                DateTimeFormat = "HH:mm:ss",
                LogCleanupTemplate = "rdc-games-*-*-*.log",
                LogDirectory = "Logs",
                LogTemplate = "rdc-games-{0}.log",
                MessagesInBuffer = 30
            };

            return logger;
        }

        /// <summary>
        /// Initializes logger
        /// </summary>
        private void InitializeLogger()
        {
            var protectedLoggerConfiguration = CreateProtectedLoggerConfiguration();

            protectedLogger = ServiceLocator.Current.GetInstance<IProtectedLogger>();
            protectedLogger.Initialize(protectedLoggerConfiguration);
            protectedLogger.CleanLogs();
        }

        private void SendCloseHUDRequest(IntPtr windowHandle)
        {
            // add delay
            Task.Run(() =>
            {
                Task.Delay(DelayToProcessHands * 2).Wait();
                databaseService.SendCloseHUDRequest(new[] { windowHandle });
            });
        }

        private readonly Dictionary<int, int> autoCenterSeats = new Dictionary<int, int>
        {
            { 2, 2 },
            { 3, 2 },
            { 6, 3 },
            { 9, 5 }
        };

        private PlayerList GetPlayerList(HandHistory handHistory)
        {
            var playerList = handHistory.Players;

            var maxPlayers = handHistory.GameDescription.SeatType.MaxPlayers;

            var heroSeat = handHistory.Hero != null ? handHistory.Hero.SeatNumber : 0;

            if (heroSeat != 0 && autoCenterSeats.ContainsKey(maxPlayers))
            {
                var prefferedSeat = autoCenterSeats[maxPlayers];

                var shift = (prefferedSeat - heroSeat) % maxPlayers;

                foreach (var player in playerList)
                {
                    player.SeatNumber = ShiftPlayerSeat(player.SeatNumber, shift, maxPlayers);
                }

                handHistory.DealerButtonPosition = ShiftPlayerSeat(handHistory.DealerButtonPosition, shift, maxPlayers);
            }

            return playerList;
        }

        private static int ShiftPlayerSeat(int seat, int shift, int tableType)
        {
            return (seat + shift + tableType - 1) % tableType + 1;
        }

        private void LogPackage(RDPackage package, IntPtr windowHandle)
        {
#if DEBUG
            if (LogPackageMapping.ContainsKey(package.PackageType))
            {
                LogPackageMapping[package.PackageType].Invoke(this, new object[] { package });
                return;
            }
#else
            try
            {
                using (var ms = new MemoryStream())
                {
                    Serializer.Serialize(ms, package);
                    var packageBytes = ms.ToArray();

                    var logText = Convert.ToBase64String(packageBytes);
                    protectedLogger.Log(logText);
                }
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to log package '{package.PackageType}'", e);
            }
#endif
        }

#if DEBUG
        private void LogPackage<T>(RDPackage package)
        {
            try
            {
                switch (package.PackageType)
                {
                    case RDPackageType.HeartbeatResponse:
                    case RDPackageType.HeartbeatRequest:
                    case RDPackageType.RoomUpdateResponse:
                    case RDPackageType.CommonRoomListResponse:
                    case RDPackageType.RedPacketActivityResponse:
                    case RDPackageType.SitInfo:
                    case RDPackageType.showRankConfigRes:
                    case RDPackageType.JackpotInfoResponse:
                    case RDPackageType.NotifyNewCommonRoom:
                    case RDPackageType.RoomUpdateNotify:
                    case RDPackageType.WorldMessageNotify:
                        return;
                }

                if (!SerializationHelper.TryDeserialize(package.Body, out T packageContent))
                {
                    LogProvider.Log.Warn(this, $"Failed to deserialize {typeof(T)} package");
                }

                var packageJson = new PackageJson<T>
                {
                    PackageType = package.PackageType,
                    Content = packageContent,
                    Time = package.Timestamp
                };

                var json = JsonConvert.SerializeObject(packageJson, Formatting.Indented, new StringEnumConverter());

                protectedLogger.Log(json);
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to log package '{package.PackageType}'", e);
            }
        }

        private void LogPacket(PipeData pipeData)
        {
            var packageFileName = $"Logs\\raw-log-{pipeData.WindowHandle}.txt";

            var sb = new StringBuilder();
            sb.AppendLine("-----------begin----------------");
            sb.AppendLine($"Date Now: {DateTime.Now}");
            sb.AppendLine($"Date Now (ticks): {DateTime.Now.Ticks}");
            sb.AppendLine($"Packet Current Length: {pipeData.Data.Length}");
            sb.AppendLine($"Body:");
            sb.AppendLine("---------body begin-------------");
            sb.AppendLine(BitConverter.ToString(pipeData.Data).Replace("-", " "));
            sb.AppendLine("----------body end--------------");
            sb.AppendLine("--------------ascii begin-------------");
            sb.AppendLine(Encoding.UTF8.GetString(pipeData.Data.ToArray()));
            sb.AppendLine("------------ascii end-----------");
            sb.AppendLine("------------end-----------------");

            File.AppendAllText(packageFileName, sb.ToString());
        }

        private class PackageJson<T>
        {
            public RDPackageType PackageType { get; set; }

            public DateTime Time { get; set; }

            public T Content { get; set; }
        }

#endif

        private class OutOfRoomTask
        {
            private const int delay = 3000;

            private CancellationTokenSource cancellationTokenSource;

            public void Cancel()
            {
                cancellationTokenSource?.Cancel();
                cancellationTokenSource = null;
            }

            public void Run(Action action)
            {
                cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = cancellationTokenSource.Token;

                Task.Run(() =>
                {
                    try
                    {
                        Task.Delay(delay).Wait(cancellationToken);
                    }
                    catch
                    {
                        return;
                    }

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    action();
                });
            }
        }
    }
}