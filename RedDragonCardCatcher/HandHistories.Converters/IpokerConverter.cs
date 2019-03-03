//-----------------------------------------------------------------------
// <copyright file="IpokerConverter.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using RedDragonCardCatcher.Entities;
using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using HandHistories.Objects.GameDescription;
using HandHistories.Objects.Hand;
using HandHistories.Objects.Players;
using RedDragonCardCatcher.Common.Exceptions;
using RedDragonCardCatcher.Common.Resources;
using RedDragonCardCatcher.Common.Linq;
using RedDragonCardCatcher.Settings;
using Microsoft.Practices.ServiceLocation;

namespace HandHistories.Converters
{
    public class IpokerConverter
    {
        private const string DefaultCurrencySymbol = "$";

        private static readonly Dictionary<HandActionType, Ipoker.ActionType> ActionMapping = new Dictionary<HandActionType, Ipoker.ActionType>
        {
            { HandActionType.ANTE, Ipoker.ActionType.Ante },
            { HandActionType.SMALL_BLIND, Ipoker.ActionType.SB },
            { HandActionType.BIG_BLIND, Ipoker.ActionType.BB },
            { HandActionType.POSTS, Ipoker.ActionType.BB },
            { HandActionType.FOLD, Ipoker.ActionType.Fold },
            { HandActionType.CHECK, Ipoker.ActionType.Check },
            { HandActionType.CALL, Ipoker.ActionType.Call },
            { HandActionType.BET, Ipoker.ActionType.Bet },
            { HandActionType.RAISE, Ipoker.ActionType.RaiseTo },
            { HandActionType.ALL_IN, Ipoker.ActionType.AllIn },
            { HandActionType.STRADDLE, Ipoker.ActionType.RaiseTo }
        };

        private static readonly HashSet<Street> ValidStreets = new HashSet<Street>
        {
            Street.Preflop,
            Street.Flop,
            Street.Turn,
            Street.River,
        };

        private static readonly HashSet<HandActionType> InitActions = new HashSet<HandActionType>
        {
            HandActionType.ANTE,
            HandActionType.SMALL_BLIND,
            HandActionType.BIG_BLIND,
            HandActionType.POSTS,
        };

        private static readonly Dictionary<Street, Ipoker.CardsType> StreetCardsTypeMapping = new Dictionary<Street, Ipoker.CardsType>
        {
            { Street.Flop, Ipoker.CardsType.Flop },
            { Street.Turn, Ipoker.CardsType.Turn },
            { Street.River, Ipoker.CardsType.River },
        };

        private readonly bool usePlayerId;

        public IpokerConverter()
        {
            var settingsService = ServiceLocator.Current.GetInstance<ISettingsService>();
            usePlayerId = settingsService.GetSettings().UsePlayerId;
        }

        private string GetCurrencySymbol(HandHistory history)
        {
            switch (history.GameDescription.Site)
            {
                case EnumPokerSites.RedDragon:
                    return DefaultCurrencySymbol;
                default:
                    return history.GameDescription.Tournament.BuyIn.GetCurrencySymbol();
            }
        }

        private string GetBuyInString(HandHistory history)
        {
            // Most of this code was taken from HandHistories.Objects.GameDescription.Buyin.ToString()
            // because it's not possible to replace currency symbol using just ToString() method
            var currency = GetCurrencySymbol(history);
            var separator = " + ";

            var format = CultureInfo.InvariantCulture;
            var prizePoolValue = history.GameDescription.Tournament.BuyIn.PrizePoolValue;
            var rake = history.GameDescription.Tournament.BuyIn.Rake;

            var prizePoolString = (prizePoolValue != Math.Round(prizePoolValue)) ? prizePoolValue.ToString("N2", format) : prizePoolValue.ToString("N0", format);
            var rakeString = (rake != Math.Round(rake)) ? rake.ToString("N2", format) : rake.ToString("N0", format);

            if (history.GameDescription.Tournament.BuyIn.IsKnockout)
            {
                var KnockoutValue = history.GameDescription.Tournament.BuyIn.KnockoutValue;

                string knockoutString = (KnockoutValue != Math.Round(KnockoutValue)) ? KnockoutValue.ToString("N2", format) : KnockoutValue.ToString("N0", format);

                return string.Format("{0}{1}{4}{0}{3}{4}{0}{2}", currency, prizePoolString, rakeString, knockoutString, separator);
            }

            return string.Format("{0}{1}{3}{0}{2}", currency, prizePoolString, rakeString, separator);
        }

        private string GetTotalBuyInString(HandHistory history)
        {
            var buyIn = history.GameDescription.Tournament.BuyIn.TotalBuyin().ToString(CultureInfo.InvariantCulture);
            var currency = GetCurrencySymbol(history);

            return $"{currency}{buyIn}";
        }

        private string GetGameType(HandHistory history)
        {
            switch (history.GameDescription.GameType)
            {
                case GameType.NoLimitHoldem:
                    return "Holdem NL";
                case GameType.PotLimitOmaha:
                    return "Omaha PL";
                default:
                    return string.Empty;
            }
        }

        private Ipoker.General CreateGeneral(HandHistory history)
        {
            var result = new Ipoker.General
            {
                Mode = "real",
                Chipsin = 0,
                Chipsout = 0,
                GameCount = 1,
                Awardpoints = 0,
                StatusPoints = 0,
                Ipoints = 0,
                IsAsian = "0",
                StartDate = history.DateOfHandUtc,
                Duration = "N/A",
                TableName = history.TableName,
                Nickname = history.Hero != null ? GetPlayerName(history.Hero) :
                   !string.IsNullOrEmpty(history.HeroName) ? history.HeroName : string.Empty,
                GameType = GetGameType(history),
            };

            if (history.GameDescription.IsTournament)
            {
                result.TournamentName = history.GameDescription.Tournament.TournamentName;
                result.TournamentCurrency = history.GameDescription.Tournament.BuyIn.Currency.ToString();
                result.Currency = history.GameDescription.Tournament.BuyIn.Currency;
                result.BuyIn = GetBuyInString(history);           // These two functions add $ currency symbol to buyins with empty currency (Gold, Club Chips, etc.)
                result.TotalBuyIn = GetTotalBuyInString(history); // Otherwise HM2 will consider it's euros and convert to $ anyway
                // For some reason HM2 doesn't want to import tournament hand without place
                // If place is unknown we put number of players involved in the hand there
                result.Place = history.GameDescription.Tournament.FinishPosition > 0 ? history.GameDescription.Tournament.FinishPosition : history.Players.Count;
                result.Win = history.GameDescription.Tournament.TotalPrize;
            }
            else
            {
                result.Currency = history.GameDescription.Limit.Currency;
                var blinds = history.GameDescription.Limit.ToString(CultureInfo.InvariantCulture, false, true, "/");
                result.GameType = $"{result.GameType} {blinds}";
                result.Bets = 0;
                result.Wins = 0;
            }

            return result;
        }

        private List<Ipoker.Player> CreateGameGeneralPlayers(HandHistory history)
        {
            var result = new List<Ipoker.Player>();

            seatMap.TryGetValue(history.GameDescription.SeatType.MaxPlayers, out Dictionary<int, int> seats);

            foreach (var player in history.Players)
            {
                var uncalledBet = history.HandActions
                    .Where(a => a.PlayerName == player.PlayerName && a.HandActionType == HandActionType.UNCALLED_BET)
                    .Select(a => a.Amount)
                    .DefaultIfEmpty(0)
                    .Sum();

                result.Add(
                    new Ipoker.Player
                    {
                        Name = GetPlayerName(player),
                        Chips = player.StartingStack,
                        Bet = player.Bet,
                        Win = player.Win + uncalledBet,
                        Seat = seats != null && seats.ContainsKey(player.SeatNumber) ? seats[player.SeatNumber] : player.SeatNumber,
                        Dealer = history.DealerButtonPosition == player.SeatNumber,
                    }
                );
            }

            return result;
        }

        private Ipoker.GameGeneral CreateGameGeneral(HandHistory history)
        {
            var result = new Ipoker.GameGeneral
            {
                StartDate = history.DateOfHandUtc,
                Players = CreateGameGeneralPlayers(history),
            };

            return result;
        }

        private int GetRoundNumber(HandAction action)
        {
            if (action.Street == Street.Preflop)
            {
                return InitActions.Contains(action.HandActionType) ? 0 : 1;
            }

            return (int)action.Street;
        }

        private string CardsToText(IEnumerable<Card> cards)
        {
            return string.Join(" ", cards.Select(c => $"{c.Suit}{c.Rank}".ToUpper()));
        }

        private string CreateGameRoundsRoundCardsTextForPlayer(HandHistory history, Player player)
        {
            if (player.hasHoleCards)
            {
                return CardsToText(player.HoleCards);
            }

            int totalCards = history.GameDescription.GameType == GameType.PotLimitOmaha ? 4 : 2;
            return string.Join(" ", Enumerable.Repeat("X", totalCards));
        }

        private IEnumerable<Card> GetCardsDealtOnStreet(IEnumerable<Card> cards, Street street)
        {
            switch (street)
            {
                case Street.Flop:
                    return cards.Take(3);
                case Street.Turn:
                    return cards.Skip(3).Take(1);
                case Street.River:
                    return cards.Skip(4).Take(1);
                default:
                    return Enumerable.Empty<Card>();
            }
        }

        private List<Ipoker.Cards> CreateGameRoundsRoundCards(HandHistory history, Street street)
        {
            var result = new List<Ipoker.Cards>();

            if (street == Street.Preflop)
            {
                foreach (var player in history.Players)
                {
                    result.Add(
                        new Ipoker.Cards
                        {
                            Player = GetPlayerName(player),
                            Type = Ipoker.CardsType.Pocket,
                            Value = CreateGameRoundsRoundCardsTextForPlayer(history, player),
                        }
                    );
                }
            }
            else if (street >= Street.Flop && street <= Street.River)
            {
                result.Add(
                    new Ipoker.Cards
                    {
                        Type = StreetCardsTypeMapping[street],
                        Value = CardsToText(GetCardsDealtOnStreet(history.CommunityCards, street))
                    }
                );
            }

            return result;
        }

        private List<Ipoker.Action> CreateGameRoundsRoundActions(HandHistory history, Dictionary<int, List<HandAction>> roundActions, Street street, ref int currentActionNumber)
        {
            var result = new List<Ipoker.Action>();

            int roundIndex = (int)street;

            if (!roundActions.ContainsKey(roundIndex))
            {
                return result;
            }

            var investments = history.Players.ToDictionary(p => p.PlayerName, p => 0m);

            if (street == Street.Preflop)
            {
                var actionAmountMapping = new[]
                {
                     HandActionType.SMALL_BLIND,
                     HandActionType.BIG_BLIND,
                     HandActionType.POSTS
                };

                var players = history.Players.ToList();

                var actions = history.HandActions.Where(a => actionAmountMapping.Contains(a.HandActionType));

                actions.ForEach(action =>
                {
                    investments[action.PlayerName] = Math.Abs(action.Amount);
                });
            }

            var playerNicks = history.Players.ToDictionary(p => p.PlayerName, p => GetPlayerName(p));

            foreach (var action in roundActions[roundIndex])
            {
                var amount = Math.Abs(action.Amount);
                investments[action.PlayerName] += amount;

                var sum = action.HandActionType == HandActionType.RAISE ? investments[action.PlayerName] : amount;

                result.Add(
                    new Ipoker.Action
                    {
                        No = currentActionNumber++,
                        Type = ActionMapping[action.HandActionType],
                        Player = playerNicks[action.PlayerName],
                        Sum = sum,
                    }
                );
            }

            return result;
        }

        private List<Ipoker.Round> CreateGameRounds(HandHistory history)
        {
            var result = new List<Ipoker.Round>();

            var actionGroups = history.HandActions
                .Where(a => ValidStreets.Contains(a.Street) && ActionMapping.ContainsKey(a.HandActionType))
                .GroupBy(GetRoundNumber)
                .ToDictionary(g => g.Key, g => g.ToList());

            int currentActionNumber = 0;
            for (Street street = Street.Init; street <= history.CommunityCards.Street; street++)
            {
                result.Add(
                    new Ipoker.Round
                    {
                        No = (int)street,
                        Cards = CreateGameRoundsRoundCards(history, street),
                        Actions = CreateGameRoundsRoundActions(history, actionGroups, street, ref currentActionNumber),
                    }
                );
            }

            return result;
        }

        private Ipoker.Game CreateGame(HandHistory history)
        {
            var result = new Ipoker.Game
            {
                GameCode = (ulong)history.HandId,
                General = CreateGameGeneral(history),
                Rounds = CreateGameRounds(history),
            };

            return result;
        }

        public Ipoker.HandHistory Convert(HandHistory history)
        {
            Ipoker.HandHistory target = new Ipoker.HandHistory
            {
                SessionCode = history.GameDescription.Identifier.ToString(),
                General = CreateGeneral(history),
                Games = new List<Ipoker.Game> { CreateGame(history) },
            };

            return target;
        }

        private string GetPlayerName(Player player)
        {
            return usePlayerId ? player.PlayerName : player.PlayerNick;
        }

        private static readonly Dictionary<int, Dictionary<int, int>> seatMap = new Dictionary<int, Dictionary<int, int>>
        {
            { 2, new Dictionary<int, int>
                 {
                    { 1, 3 },
                    { 2, 8 }
                 }
            },
            { 4, new Dictionary<int, int>
                {
                    {1, 2},
                    {2, 4},
                    {3, 7},
                    {4, 9}
                }
            },
            { 6, new Dictionary<int, int>
                 {
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 5 },
                    { 4, 6 },
                    { 5, 8 },
                    { 6, 10 }
                 }
            },
            { 9, new Dictionary<int, int>
                 {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 8 },
                    { 8, 9 },
                    { 9, 10 },
                 }
            }
        };
    }
}
