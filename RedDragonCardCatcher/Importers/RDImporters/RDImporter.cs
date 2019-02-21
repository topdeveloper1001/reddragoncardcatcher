//-----------------------------------------------------------------------
// <copyright file="IRDImporter.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using Microsoft.Practices.ServiceLocation;
using RedDragonCardCatcher.Common.Extensions;
using RedDragonCardCatcher.Common.Log;
using RedDragonCardCatcher.Settings;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDragonCardCatcher.Importers
{
    internal sealed class RDImporter : BaseImporter, IRDImporter
    {
        private const int NoDataDelay = 200;
        private const int ShowPreHUDDelay = 2500;
        private readonly BlockingCollection<PipeData> packetBuffer = new BlockingCollection<PipeData>();
        private IProtectedLogger protectedLogger;

        public override string ImporterName => "RDImporter";

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
        /// Processes buffer data
        /// </summary>
        private void ProcessBuffer()
        {
            var dataManager = ServiceLocator.Current.GetInstance<IDataManager>();

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

                    LogPacket(data);
                }
                catch (Exception e)
                {
                    LogProvider.Log.Error(this, $"Failed to process buffered data.", e);
                }
            }

            protectedLogger?.StopLogging();
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

        private void InitializeLogger()
        {
            var protectedLoggerConfiguration = CreateProtectedLoggerConfiguration();

            protectedLogger = ServiceLocator.Current.GetInstance<IProtectedLogger>();
            protectedLogger.Initialize(protectedLoggerConfiguration);
            protectedLogger.CleanLogs();
        }

        private void LogPacket(byte[] data)
        {
            var packageFileName = "Logs\\raw-log.txt";

            var sb = new StringBuilder();
            sb.AppendLine("-----------begin----------------");
            sb.AppendLine($"Date Now: {DateTime.Now}");
            sb.AppendLine($"Date Now (ticks): {DateTime.Now.Ticks}");
            sb.AppendLine($"Packet Current Length: {data.Length}");
            sb.AppendLine($"Body:");
            sb.AppendLine("---------body begin-------------");
            sb.AppendLine(BitConverter.ToString(data).Replace("-", " "));
            sb.AppendLine("----------body end--------------");
#if DEBUG
            sb.AppendLine("--------------ascii-------------");
            sb.AppendLine(Encoding.UTF8.GetString(data.ToArray()));
            sb.AppendLine("------------ascii end-----------");
#endif
            sb.AppendLine("------------end-----------------");

            File.AppendAllText(packageFileName, sb.ToString());
        }
    }
}