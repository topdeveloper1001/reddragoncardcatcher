//-----------------------------------------------------------------------
// <copyright file="PT4HudProfileConfig.cs" company="Ace Poker Solutions">
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
using System.Linq;
using System.Text;

namespace RedDragonCardCatcher.DbInstallers
{
    internal class PT4HudProfileConfig
    {
        private readonly static byte[] header = new byte[] { 0, 0, 0, 15 };
        private const string headerStr = "PT4.HudProfiles";
        private const string cashPrefix = "Cash - ";
        private const string tournamentPrefix = "Tournament - ";

        private const byte newItemByte = 60;
        private const byte newFieldByte = 105;
        private const byte strFieldByte = 115;
        private const byte endItemByte = 62;

        public PT4HudProfileConfig() : this(null, null)
        {
        }

        public PT4HudProfileConfig(IEnumerable<PT4HudProfile> cashProfiles, IEnumerable<PT4HudProfile> tournamentProfiles)
        {
            CashProfiles = cashProfiles != null ? new List<PT4HudProfile>(cashProfiles) : new List<PT4HudProfile>();
            TournamentProfiles = tournamentProfiles != null ? new List<PT4HudProfile>(tournamentProfiles) : new List<PT4HudProfile>();
        }

        public List<PT4HudProfile> CashProfiles { get; private set; }

        public List<PT4HudProfile> TournamentProfiles { get; private set; }

        public static PT4HudProfileConfig ReadFromBinary(byte[] bytes)
        {
            IEnumerable<PT4HudProfile> cashProfiles = null;
            IEnumerable<PT4HudProfile> tournamentProfiles = null;

            var isCashData = false;

            for (var i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == newItemByte)
                {
                    i++;

                    var numberOfProfilesBytes = bytes.Skip(i + 2).Take(4).Reverse().ToArray();
                    var numberOfProfiles = BitConverter.ToInt32(numberOfProfilesBytes, 0);
                    i += 6;

                    // cash data section
                    if (!isCashData)
                    {
                        isCashData = true;
                        cashProfiles = GetSections(ref i, bytes, numberOfProfiles);
                        i--;
                    }
                    // tournament data section
                    else
                    {
                        tournamentProfiles = GetSections(ref i, bytes, numberOfProfiles, true);
                    }
                }
            }

            var profileConfig = new PT4HudProfileConfig(cashProfiles, tournamentProfiles);

            return profileConfig;
        }

        private static IEnumerable<PT4HudProfile> GetSections(ref int index, byte[] bytes, int numberOfSections, bool isTournament = false)
        {
            var profiles = new List<PT4HudProfile>();

            if (numberOfSections == 0)
            {
                return profiles;
            }

            index++;

            for (var section = 0; section < numberOfSections; section++)
            {
                var profile = new PT4HudProfile();

                profile.Site = BitConverter.ToInt32(bytes.Skip(index + 2).Take(4).Reverse().ToArray(), 0);
                profile.Limit = BitConverter.ToInt32(bytes.Skip(index + 8).Take(4).Reverse().ToArray(), 0);
                profile.Speed = BitConverter.ToInt32(bytes.Skip(index + 14).Take(4).Reverse().ToArray(), 0);
                profile.Game = BitConverter.ToInt32(bytes.Skip(index + 20).Take(4).Reverse().ToArray(), 0);
                profile.Seats = BitConverter.ToInt32(bytes.Skip(index + 26).Take(4).Reverse().ToArray(), 0);

                var nameLength = 2 * BitConverter.ToInt32(bytes.Skip(index + 31).Take(4).Reverse().ToArray(), 0);
                profile.Name = isTournament ? GetTournamentName(index, bytes, nameLength) : GetCashName(index, bytes, nameLength);

                profiles.Add(profile);

                index += 37 + nameLength;
            }

            return profiles;
        }

        private static string GetCashName(int index, byte[] bytes, int nameLength)
        {
            var prefix = Encoding.Unicode.GetString(bytes.Skip(index + 36).Take(13).Concat(new[] { bytes[index + 35] }).ToArray());
            var name = Encoding.Unicode.GetString(bytes.Skip(index + 50).Take(nameLength - 15).Concat(new[] { bytes[index + 49] }).ToArray());

            return prefix + name;
        }

        private static string GetTournamentName(int index, byte[] bytes, int nameLength)
        {
            var prefix = Encoding.Unicode.GetString(bytes.Skip(index + 36).Take(25).Concat(new[] { bytes[index + 35] }).ToArray());
            var name = Encoding.Unicode.GetString(bytes.Skip(index + 62).Take(nameLength - 27).Concat(new[] { bytes[index + 61] }).ToArray());

            return prefix + name;
        }

        public static byte[] WriteToBinary(PT4HudProfileConfig profile)
        {
            var result = new List<byte>();

            result.AddRange(header);
            result.AddRange(AdjustStringBytes(Encoding.Unicode.GetBytes(headerStr)));
            result.Add(0);
            result.Add(0);
            result.Add(0);
            result.Add(2);

            result.AddRange(WriteToBinary(profile.CashProfiles));
            result.AddRange(WriteToBinary(profile.TournamentProfiles));

            return result.ToArray();
        }

        private static IEnumerable<byte> WriteToBinary(IEnumerable<PT4HudProfile> profiles)
        {
            var result = new List<byte>();

            result.Add(newItemByte);
            result.Add(newFieldByte);
            result.Add(sizeof(Int32));

            var profilesCountInBytes = BitConverter.GetBytes(profiles.Count()).Reverse();
            result.AddRange(profilesCountInBytes);

            foreach (var profile in profiles)
            {
                result.AddRange(WriteToBinary(profile));
            }

            result.Add(endItemByte);

            return result;
        }

        private static IEnumerable<byte> WriteToBinary(PT4HudProfile profile)
        {
            var result = new List<byte>();

            result.Add(newItemByte);

            result.AddRange(GetIntFieldBytes(profile.Site));
            result.AddRange(GetIntFieldBytes(profile.Limit));
            result.AddRange(GetIntFieldBytes(profile.Speed));
            result.AddRange(GetIntFieldBytes(profile.Game));
            result.AddRange(GetIntFieldBytes(profile.Seats));
            result.AddRange(GetNameFieldBytes(profile.Name));

            result.Add(endItemByte);

            return result;
        }

        private static IEnumerable<byte> GetIntFieldBytes(int fieldValue)
        {
            var result = new List<byte>();

            result.Add(newFieldByte);
            result.Add(sizeof(Int32));

            var fieldBytes = BitConverter.GetBytes(fieldValue).Reverse().ToArray();

            result.AddRange(fieldBytes);

            return result;
        }

        private static IEnumerable<byte> GetNameFieldBytes(string name)
        {
            var result = new List<byte>();

            result.Add(strFieldByte);
            result.AddRange(BitConverter.GetBytes(name.Length).Reverse().ToArray());

            var isTournament = name.StartsWith(tournamentPrefix);
            var prefix = isTournament ? tournamentPrefix : cashPrefix;

            var profileName = name.Substring(prefix.Length, name.Length - prefix.Length);

            var profileNameInBytes = AdjustStringBytes(Encoding.Unicode.GetBytes(profileName));
            var prefixNameInBytes = AdjustStringBytes(Encoding.Unicode.GetBytes(prefix));

            result.AddRange(prefixNameInBytes);
            result.AddRange(profileNameInBytes);

            return result;
        }

        private static byte[] AdjustStringBytes(byte[] bytesToAdjust)
        {
            var adjustBytes = new byte[] { bytesToAdjust[bytesToAdjust.Length - 1] };
            adjustBytes = adjustBytes.Concat(bytesToAdjust.Take(bytesToAdjust.Length - 1)).ToArray();
            return adjustBytes;
        }
    }
}