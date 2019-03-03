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
using RedDragonCardCatcher.Common.Utils;
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
        private const Currency DefaultCurrency = Currency.All;

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
                case RDPackageType.JoinMTTRoomResponse:
                    ParsePackage<JoinMTTRoomResponse>(package, response => ProcessJoinMTTRoomResponse(response, roomInfo));
                    return false;
                case RDPackageType.JoinSNGRoomResponse:
                    ParsePackage<JoinSNGRoomResponse>(package, response => ProcessJoinSNGRoomResponse(response, roomInfo));
                    return false;
                case RDPackageType.RaceMTTResponse:
                    ParsePackage<RaceMTTResponse>(package, response => ProcessRaceMTTResponse(response, roomInfo));
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
                    if (package.PackageType == RDPackageType.NotifyNextRoundStartRoomResponse ||
                        package.PackageType == RDPackageType.NotifyNextRoundStartResponse)
                    {
                        var dateOfHandUtc = package.Timestamp;

                        history = new HandHistory
                        {
                            DateOfHandUtc = dateOfHandUtc,
                            HandId = dateOfHandUtc.ToUnixTimeInMilliseconds()
                        };

                        if (package.PackageType == RDPackageType.NotifyNextRoundStartRoomResponse)
                        {
                            ParsePackage<NotifyNextRoundStartRoomResponse>(package, response => ProcessNotifyNextRoundStartRoomResponse(response, roomInfo, history));
                        }
                        else if (package.PackageType == RDPackageType.NotifyNextRoundStartResponse)
                        {
                            ParsePackage<NotifyNextRoundStartResponse>(package, response => ProcessNotifyNextRoundStartResponse(response, roomInfo, history));
                        }

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
                            ParsePackage<PlayerCallResponse>(package, response => ProcessPlayerCallResponse(response.doPlayerCallResponse, roomInfo, history));
                            break;
                        case RDPackageType.PlayerFoldResponse:
                            ParsePackage<PlayerFoldResponse>(package, response => ProcessPlayerFoldResponse(response.doPlayerFoldResponse, roomInfo, history));
                            break;
                        case RDPackageType.PlayerCheckResponse:
                            ParsePackage<PlayerCheckResponse>(package, response => ProcessPlayerCheckResponse(response.doPlayerCheckResponse, roomInfo, history));
                            break;
                        case RDPackageType.PlayerRaiseResponse:
                            ParsePackage<PlayerRaiseResponse>(package, response => ProcessPlayerRaiseResponse(response.doPlayerRaiseResponse, roomInfo, history));
                            break;
                        case RDPackageType.NotifyFlopRoundResponse:
                            ParsePackage<NotifyFlopRoundResponse>(package, response => ProcessNotifyFlopRoundResponse(response, roomInfo, history));
                            break;
                        case RDPackageType.NotifyGainsResponse:
                            ParsePackage<NotifyGainsResponse>(package, response => ProcessNotifyGainsResponse(response, roomInfo, history));
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
            finally
            {
                roomInfo.Packages.Clear();
            }
        }

        private bool ValidatePackages(RDRoomInfo roomInfo)
        {
            if (roomInfo.RoomId == 0)
            {
                LogProvider.Log.Warn(this, $"Hand cannot be built because room info is missing. [{roomInfo.WindowHandle}]");
                return false;
            }
            
            if (roomInfo.Packages.FirstOrDefault(x => x.PackageType == RDPackageType.NotifyNextRoundStartRoomResponse) == null
                && roomInfo.Packages.FirstOrDefault(x => x.PackageType == RDPackageType.NotifyNextRoundStartResponse) == null)
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

        private void ProcessJoinMTTRoomResponse(JoinMTTRoomResponse response, RDRoomInfo roomInfo)
        {
            roomInfo.RoomId = response.roomId;
            roomInfo.RoomName = response.Name;
            roomInfo.RoomType = (ERoomType)response.roomType;
            roomInfo.MaxPlayers = response.sitInfoes.Count;
            roomInfo.SignUpCost = response.signUpCost;
            roomInfo.SignUpFee = response.signUpFeePercent;
        }

        private void ProcessJoinSNGRoomResponse(JoinSNGRoomResponse response, RDRoomInfo roomInfo)
        {
            roomInfo.RoomId = response.roomId;
            roomInfo.RoomName = response.Name;
            roomInfo.RoomType = (ERoomType)response.roomType;
            roomInfo.MaxPlayers = response.sitInfoes.Count;
        }

        private void ProcessRaceMTTResponse(RaceMTTResponse response, RDRoomInfo roomInfo)
        {
            roomInfo.TournamentStartTime = response.startTime;
            roomInfo.TournamentStartingStack = response.startStack;
        }

        private void ProcessNotifyNextRoundStartRoomResponse(NotifyNextRoundStartRoomResponse response, RDRoomInfo roomInfo, HandHistory handHistory)
        {
            var newResponse = new NotifyNextRoundStartResponse
            {
                Sb = response.Sb,
                Bb = response.Bb,
                Ante = response.Ante,
                sitInfoes = response.sitInfoes,
                roomId = response.roomId
            };

            ProcessNotifyNextRoundStartResponse(newResponse, roomInfo, handHistory);
        }

        private void ProcessNotifyNextRoundStartResponse(NotifyNextRoundStartResponse response, RDRoomInfo roomInfo, HandHistory handHistory)
        {
            TournamentDescriptor tournamentDescriptor = null;

            if (roomInfo.IsTournament)
            {
                tournamentDescriptor = new TournamentDescriptor
                {
                    StartDate = roomInfo.TournamentStartTime != 0 ? Utils.UnixTimeInMilisecondsToDateTime(roomInfo.TournamentStartTime) : DateTime.UtcNow,
                    StartingStack = roomInfo.TournamentStartingStack,
                    TournamentId = roomInfo.RoomId.ToString(),
                    BuyIn = ParseBuyin(roomInfo),
                    TournamentName = roomInfo.RoomName,
                    TournamentsTags = roomInfo.RoomType == ERoomType.mttRoom ? TournamentsTags.MTT : TournamentsTags.STT,
                    Speed = TournamentSpeed.Regular
                };
            }

            handHistory.GameDescription = new GameDescriptor(
                roomInfo.IsTournament ? PokerFormat.Tournament : PokerFormat.CashGame,
                EnumPokerSites.RedDragon,
                ConvertRoomInfoToGameType(roomInfo),
                Limit.FromSmallBlindBigBlind(response.Sb,
                    response.Bb,
                    roomInfo.IsTournament ? Currency.Chips : DefaultCurrency,
                    response.Ante != 0,
                    response.Ante),
                TableType.FromTableTypeDescriptions(
                    roomInfo.RoomName.StartsWith("SD", StringComparison.OrdinalIgnoreCase) ?
                        TableTypeDescription.ShortDeck :
                        TableTypeDescription.Regular),
                SeatType.FromMaxPlayers(roomInfo.MaxPlayers),
                tournamentDescriptor);

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

                if (seatInfo.playerId == response.playerId)
                {
                    handHistory.Hero = player;

                    if (response.Cards != null)
                    {
                        player.Cards = string.Join(string.Empty, response.Cards.Select(x => ParseCard(x)));
                    }
                }

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
            }

            HandHistoryUtils.SortHandActions(handHistory);
        }

        private void ProcessPlayerCallResponse(DoPlayerCallResponse response, RDRoomInfo roomInfo, HandHistory handHistory)
        {
            var actionType = (RDHandActionType)response.Action;
            var handActionType = ConvertRDHandActionTypeToHandActionType(actionType);

            if (handActionType == HandActionType.UNKNOWN)
            {
                LogProvider.Log.Warn($"Unknown call response action is detected. Hand #{handHistory.HandId}");
                return;
            }

            var playerName = response.playerId.ToString();
            var street = handHistory.CommunityCards.Street;
            var amount = (handActionType == HandActionType.CHECK || handActionType == HandActionType.FOLD) ?
                0 :
                response.Bet - GetPutInPotAmount(playerName, handHistory, street);

            var action = new HandAction(playerName,
                handActionType,
                amount,
                street);

            handHistory.HandActions.Add(action);
        }

        private void ProcessPlayerFoldResponse(DoPlayerFoldResponse response, RDRoomInfo roomInfo, HandHistory handHistory)
        {
            var action = new HandAction(response.playerId.ToString(),
                HandActionType.FOLD,
                0,
                handHistory.CommunityCards.Street);

            handHistory.HandActions.Add(action);
        }

        private void ProcessPlayerCheckResponse(DoPlayerCheckResponse response, RDRoomInfo roomInfo, HandHistory handHistory)
        {
            var action = new HandAction(response.playerId.ToString(),
                  HandActionType.CHECK,
                  0,
                  handHistory.CommunityCards.Street);

            handHistory.HandActions.Add(action);
        }

        private void ProcessPlayerRaiseResponse(DoPlayerRaiseResponse response, RDRoomInfo roomInfo, HandHistory handHistory)
        {
            var actionType = (RDHandActionType)response.Action;
            var handActionType = ConvertRDHandActionTypeToHandActionType(actionType);

            if (handActionType == HandActionType.UNKNOWN)
            {
                LogProvider.Log.Warn($"Unknown raise response action is detected. Hand #{handHistory.HandId}");
                return;
            }

            var playerName = response.playerId.ToString();
            var street = handHistory.CommunityCards.Street;

            var action = new HandAction(playerName,
                handActionType,
                response.Bet - GetPutInPotAmount(playerName, handHistory, street),
                street);

            handHistory.HandActions.Add(action);
        }

        private void ProcessNotifyFlopRoundResponse(NotifyFlopRoundResponse response, RDRoomInfo roomInfo, HandHistory handHistory)
        {
            ProcessPlayerCallResponse(response.doPlayerCallResponse, roomInfo, handHistory);

            foreach (var card in response.Cards)
            {
                handHistory.CommunityCards.Add(ParseCard(card));
            }
        }

        private void ProcessNotifyGainsResponse(NotifyGainsResponse response, RDRoomInfo roomInfo, HandHistory handHistory)
        {
            ProcessPlayerCallResponse(response.doPlayerCallResponse, roomInfo, handHistory);

            foreach (var gainInfo in response.playerGainsInfoes)
            {
                var player = handHistory.Players.FirstOrDefault(x => x.PlayerName == gainInfo.playerId.ToString());

                if (player == null)
                {
                    throw new RDCCInternalException(new NonLocalizableString($"Failed to find player {gainInfo.playerId} from gain info in list of players."));
                }

                if (gainInfo.handCard != null)
                {
                    player.Cards = string.Join(string.Empty, gainInfo.handCard.Cards.Select(x => ParseCard(x)));
                }

                var putInPot = Math.Abs(handHistory.HandActions.Where(x => x.PlayerName == player.PlayerName).Sum(x => x.Amount));
                var won = gainInfo.Gains + putInPot;

                if (won > 0)
                {
                    handHistory.HandActions.Add(new WinningsAction(
                        player.PlayerName,
                         HandActionType.WINS,
                         won,
                         1));

                    player.Win = won;
                }
            }
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

                return;
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

            HandHistoryUtils.CalculateRake(history);
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

        private HandHistories.Objects.Cards.Card ParseCard(Model.Card card)
        {
            if (!CardsMap.TryGetValue(card.cardNumber, out string rank))
            {
                rank = card.cardNumber.ToString();
            }

            return HandHistories.Objects.Cards.Card.Parse($"{rank}{card.cardSuit[0]}");
        }

        private static readonly Dictionary<int, string> CardsMap = new Dictionary<int, string>
        {
            [10] = "T",
            [11] = "J",
            [12] = "Q",
            [13] = "K",
            [14] = "A"
        };

        private static decimal GetPutInPotAmount(string playerName, HandHistory handHistory, Street street)
        {
            return Math.Abs(handHistory.HandActions
                .Where(x => x.PlayerName == playerName && x.Street == street)
                .Sum(x => x.Amount));
        }

        private static Buyin ParseBuyin(RDRoomInfo roomInfo)
        {
            if (string.IsNullOrEmpty(roomInfo.SignUpCost))
            {
                LogProvider.Log.Warn("Failed to parse tournament buy info.");
                return Buyin.FromBuyinRake(0, 0, DefaultCurrency);
            }

            var colonIndex = roomInfo.SignUpCost.IndexOf(":");

            decimal prizePool = 0;

            if (colonIndex < 0 && !decimal.TryParse(roomInfo.SignUpCost, out prizePool))
            {
                LogProvider.Log.Warn($"Failed to parse tournament buy info from '{roomInfo.SignUpCost}' text.");
                return Buyin.FromBuyinRake(0, 0, DefaultCurrency);
            }

            if (colonIndex >= 0)
            {
                var prizeText = roomInfo.SignUpCost.Substring(colonIndex + 1);

                if (!decimal.TryParse(prizeText, out prizePool))
                {
                    LogProvider.Log.Warn($"Failed to parse tournament buy info from '{roomInfo.SignUpCost}' text.");
                    return Buyin.FromBuyinRake(0, 0, DefaultCurrency);
                }
            }

            var fee = prizePool * roomInfo.SignUpFee / 100;

            return Buyin.FromBuyinRake(prizePool, fee, DefaultCurrency);
        }

        #endregion
    }
}