//-----------------------------------------------------------------------
// <copyright file="PT4DbInstaller.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.Common.Log;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RedDragonCardCatcher.DbInstallers
{
    internal class PT4DbInstaller : IDbInstaller
    {
        private static string[][] PT4SimpleSettings = new[]
        {
            new[] { "Import/AutoStart.400", "Y"},
            new[] { "Import/AutoStart.100", "Y"},
            new[] { "Site.iPoker/AutoCenter", "N" }
        };

        private static readonly string[] PT4Directories = new[]
        {
            "Site.PokerStars/HandHistoryDirectory",
            "Site.iPoker/HandHistoryDirectories"
        };

        public bool CanInstall(out string[] warnings)
        {
            warnings = null;
            return true;
        }

        public void Install()
        {
            LogProvider.Log.Info(this, "Updating PT4 settings.");

            try
            {
                // get current path
                var exePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                var stringToAppend = exePath + @"\HandHistories";

                // logic for setting folder up                               
                var settingsFilePath = DBHelper.GetPT4ConfigurationFile();

                var iniFile = new IniFile(settingsFilePath);

                var simpleSettings = PT4SimpleSettings.Concat(GetActivePlayerSettings()).ToArray();

                // set simple settings
                foreach (var simpleSetting in simpleSettings)
                {
                    iniFile.SetParameter(simpleSetting[0], simpleSetting[1]);
                }

                foreach (var directory in PT4Directories)
                {
                    var existingDirectories = iniFile.GetParameter(directory);

                    if (existingDirectories.Contains(stringToAppend))
                    {
                        continue;
                    }

                    existingDirectories = string.IsNullOrWhiteSpace(existingDirectories) ?
                                            stringToAppend + ";" :
                                            existingDirectories.TrimEnd('-', ';') + ";" + stringToAppend + ";";

                    iniFile.SetParameter(directory, existingDirectories);
                }

                iniFile.Save();

                LogProvider.Log.Info(this, "PT4 settings have been updated.");
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, "Failed to update IPoker settings to set hh location in PT4 config.", e);
            }
        }

        private string[][] GetActivePlayerSettings()
        {
            var activeSettings = new[]
            {
                new[] { "Players/ActiveSiteID", "400" }
            };

            return activeSettings;
        }
    }
}