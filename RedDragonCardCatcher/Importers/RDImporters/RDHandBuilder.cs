//-----------------------------------------------------------------------
// <copyright file="RDHandBuilder.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using HandHistories.Objects.GameDescription;
using HandHistories.Objects.Hand;
using HandHistories.Parser.Utils;
using RedDragonCardCatcher.Common.Exceptions;
using RedDragonCardCatcher.Common.Extensions;
using RedDragonCardCatcher.Common.Linq;
using RedDragonCardCatcher.Common.Log;
using RedDragonCardCatcher.Common.Resources;
using RedDragonCardCatcher.Entities;
using RedDragonCardCatcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using static RedDragonCardCatcher.Model.RoomTypeEnum;

namespace RedDragonCardCatcher.Importers
{
    internal class RDHandBuilder : IRDHandBuilder
    {
        private readonly Dictionary<IntPtr, RDRoomInfo> roomInfos = new Dictionary<IntPtr, RDRoomInfo>();

        public bool IsRoomInfoAvailable(IntPtr windowHandle)
        {
            return roomInfos.TryGetValue(windowHandle, out RDRoomInfo roomInfo) && roomInfo.IsDefined;
        }

        public bool TryBuild(RDPackage package, IntPtr windowHandle, out HandHistory handHistory)
        {
            handHistory = null;

            if (package == null)
            {
                return false;
            }

            if (!roomInfos.TryGetValue(windowHandle, out RDRoomInfo roomInfo))
            {
                roomInfo = roomInfos[windowHandle] = new RDRoomInfo
                {
                    WindowHandle = windowHandle
                };
            }

            switch (package.PackageType)
            {
                case RDPackageType.JoinRoomResponse:
                    ParsePackage<JoinRoomResponse>(package, response => ProcessJoinRoomResponse(response, roomInfo));
                    return false;
            }

            roomInfo.Packages.Add(package);

            if (package.PackageType == RDPackageType.NotifyGainsResponse)
            {
                handHistory = BuildHand(roomInfo);
            }

            return handHistory != null && handHistory.Players.Count > 0;
        }

        private HandHistory BuildHand(RDRoomInfo roomInfo)
        {
            HandHistory history = null;

            try
            {
                if (!ValidatePackages(roomInfo))
                {
                    return history;
                }

                var isGameStarted = false;

                foreach (var package in roomInfo.Packages)
                {
                    if (package.PackageType == RDPackageType.NotifyNextRoundStartRoomResponse)
                    {
                        var dateOfHandUtc = DateTime.UtcNow;

                        history = new HandHistory
                        {
                            DateOfHandUtc = dateOfHandUtc,
                            HandId = dateOfHandUtc.ToUnixTimeInMilliseconds()
                        };

                        ParsePackage<NotifyNextRoundStartRoomResponse>(package, response => ProcessNotifyNextRoundStartRoomResponse(response, roomInfo, history));
                        isGameStarted = true;
                        continue;
                    }

                    if (!isGameStarted)
                    {
                        continue;
                    }

                    switch (package.PackageType)
                    {
                        case RDPackageType.PlayerCallResponse:
                            ParsePackage<PlayerCallResponse>(package, response => ProcessPlayerCallResponse(response, roomInfo, history));
                            break;

                    }
                }

                AdjustHandHistory(history);

                return history;
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to build hand #{history?.HandId ?? 0} room #{history?.GameDescription.Identifier ?? 0} [{roomInfo.WindowHandle}]", e);
                return null;
            }
        }

        private bool ValidatePackages(RDRoomInfo roomInfo)
        {
            var nextRoundStartRoomResponse = roomInfo.Packages.FirstOrDefault(x => x.PackageType == RDPackageType.NotifyNextRoundStartRoomResponse);

            if (nextRoundStartRoomResponse == null)
            {
                LogProvider.Log.Warn(this, $"Hand cannot be built because NextRoundStart message is missing. [{roomInfo.WindowHandle}]");
                return false;
            }

            return true;
        }

        private void ProcessJoinRoomResponse(JoinRoomResponse response, RDRoomInfo roomInfo)
        {
            roomInfo.RoomId = response.roomId;
            roomInfo.RoomName = response.Name;
            roomInfo.RoomType = (ERoomType)response.roomType;
            roomInfo.MaxPlayers = response.sitInfoes.Count;
        }

        private void ProcessNotifyNextRoundStartRoomResponse(NotifyNextRoundStartRoomResponse response, RDRoomInfo roomInfo, HandHistory handHistory)
        {
            handHistory.GameDescription = new GameDescriptor(
                EnumPokerSites.RedDragon,
                ConvertRoomInfoToGameType(roomInfo),
                Limit.FromSmallBlindBigBlind(response.Sb, response.Bb, Currency.All, response.Ante != 0, response.Ante),
                TableType.FromTableTypeDescriptions(
                    roomInfo.RoomName.StartsWith("SD", StringComparison.OrdinalIgnoreCase) ?
                        TableTypeDescription.ShortDeck :
                        TableTypeDescription.Regular),
                SeatType.FromMaxPlayers(roomInfo.MaxPlayers), null);

            handHistory.TableName = $"{roomInfo.RoomName}-{roomInfo.RoomId}";
            handHistory.GameDescription.Identifier = response.roomId;

            foreach (var seatInfo in response.sitInfoes)
            {
                if (seatInfo.playerId <= 0)
                {
                    continue;
                }

                var player = new HandHistories.Objects.Players.Player
                {
                    PlayerName = seatInfo.playerId.ToString(),
                    PlayerNick = seatInfo.playerName,
                    SeatNumber = seatInfo.sitId + 1,
                    StartingStack = seatInfo.Bankroll + seatInfo.Bet + seatInfo.Ante
                };

                handHistory.Players.Add(player);

                if (seatInfo.isDealer)
                {
                    handHistory.DealerButtonPosition = player.SeatNumber;
                }

                if (seatInfo.Bet > 0)
                {
                    var actionType = seatInfo.isSB ? HandActionType.SMALL_BLIND :
                       (seatInfo.isBB ? HandActionType.BIG_BLIND :
                       (seatInfo.isStraddle ? HandActionType.STRADDLE : HandActionType.POSTS));

                    handHistory.HandActions.Add(
                        new HandAction(player.PlayerName,
                            actionType,
                            seatInfo.Bet,
                            Street.Preflop));
                }

                if (seatInfo.Ante > 0)
                {
                    handHistory.HandActions.Add(
                       new HandAction(player.PlayerName,
                           HandActionType.ANTE,
                           seatInfo.Ante,
                           Street.Preflop));
                }

                HandHistoryUtils.SortHandActions(handHistory);
            }
        }

        private void ProcessPlayerCallResponse(PlayerCallResponse response, RDRoomInfo roomInfo, HandHistory handHistory)
        {
            var actionType = (RDHandActionType)response.doPlayerCallResponse.Action;
            var handActionType = ConvertRDHandActionTypeToHandActionType(actionType);

            if (handActionType == HandActionType.UNKNOWN)
            {
                LogProvider.Log.Warn($"Unknown call response action is detected. Hand #{handHistory.HandId}");
                return;
            }

            var action = new HandAction(response.doPlayerCallResponse.playerId.ToString(),
                handActionType,
                0,
                handHistory.CommunityCards.Street);

            handHistory.HandActions.Add(action);
        }

        private void AdjustHandHistory(HandHistory history)
        {
            const decimal divider = 100m;

            if (history == null)
            {
                return;
            }

            HandHistoryUtils.UpdateAllInActions(history);
            HandHistoryUtils.CalculateBets(history);
            HandHistoryUtils.CalculateUncalledBets(history, false);
            HandHistoryUtils.CalculateTotalPot(history);
            HandHistoryUtils.RemoveSittingOutPlayers(history);

            if (history.GameDescription.IsTournament)
            {
                history.GameDescription.Tournament.BuyIn.PrizePoolValue /= divider;
                history.GameDescription.Tournament.BuyIn.KnockoutValue /= divider;
                history.GameDescription.Tournament.BuyIn.Rake /= divider;
                history.GameDescription.Tournament.Addon /= divider;
                history.GameDescription.Tournament.Rebuy /= divider;
                history.GameDescription.Tournament.Winning /= divider;
                history.GameDescription.Tournament.Bounty /= divider;
                history.GameDescription.Tournament.TotalPrize /= divider;
            }

            history.HandActions.ForEach(a => a.Amount = a.Amount / divider);

            history.GameDescription.Limit.SmallBlind /= divider;
            history.GameDescription.Limit.BigBlind /= divider;
            history.GameDescription.Limit.Ante /= divider;

            history.Players.ForEach(p =>
            {
                p.Bet /= divider;
                p.StartingStack /= divider;
                p.Win /= divider;
            });

            history.TotalPot /= divider;

            if (!history.GameDescription.IsTournament)
            {
                HandHistoryUtils.CalculateRake(history);
            }
        }

        private T ParsePackage<T>(RDPackage package)
        {
            if (!SerializationHelper.TryDeserialize(package.Body, out T packageBody))
            {
                throw new RDCCInternalException(new NonLocalizableString($"Failed to deserialize package of {package.PackageType} type."));
            }

            return packageBody;
        }

        private void ParsePackage<T>(RDPackage package, Action<T> action)
        {
            var packageBody = ParsePackage<T>(package);

            action?.Invoke(packageBody);
        }

        #region Converters

        private GameType ConvertRoomInfoToGameType(RDRoomInfo roomInfo)
        {
            if (roomInfo.RoomName.StartsWith("PLO", StringComparison.OrdinalIgnoreCase))
            {
                return GameType.PotLimitOmaha;
            }

            return GameType.NoLimitHoldem;
        }

        private HandActionType ConvertRDHandActionTypeToHandActionType(RDHandActionType actionType)
        {
            switch (actionType)
            {
                case RDHandActionType.Bet:
                    return HandActionType.BET;
                case RDHandActionType.Call:
                    return HandActionType.CALL;
                case RDHandActionType.Check:
                    return HandActionType.CHECK;
                case RDHandActionType.Fold:
                    return HandActionType.FOLD;
                case RDHandActionType.Raise:
                    return HandActionType.RAISE;
                case RDHandActionType.AllIn:
                    return HandActionType.ALL_IN;
            }

            return HandActionType.UNKNOWN;
        }

        #endregion
    }
}