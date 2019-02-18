//-----------------------------------------------------------------------
// <copyright file="PT4Configurator.cs" company="Ace Poker Solutions">
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
    internal class PT4Configurator : IPT4Configurator
    {
        private const string VectorScalingIniPath = "Hud/VectorScaling";
        private const string FontScalingIniPath = "Hud/NewFontScaling";

        private readonly static string[] hudsToInstall = new[] { "Cash - PPP IPoker Profile", "Tournament - PPP IPoker Profile" };


        private const string hudFileExt = "pt4hud";
        private const string hudToInstallPattern = "RedDragonCardCatcher.Services.DbInstallers.Profiles.{0}.{1}";
        private const int iPokerSiteCode = 400;

        public void DisableScaling()
        {
            try
            {
                var configurationFile = DBHelper.GetPT4ConfigurationFile();
                var iniFile = new IniFile(configurationFile);

                iniFile.SetParameter(VectorScalingIniPath, "N");
                iniFile.SetParameter(FontScalingIniPath, "N");

                iniFile.Save();

                LogProvider.Log.Info("PT4 Scaling was disabled.");
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, "Failed to disable scaling in PT4 config.", e);
            }
        }

        public void InstallPredefinedHUD()
        {
            try
            {
                CopyHudProfiles();
                UpdateHudConfiguration();

                LogProvider.Log.Info("Predefined PT4 HUDs were installed.");
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, "Failed to install  predefined HUDs.", e);
            }
        }

        public bool IsPredefinedHUDInstalled()
        {
            try
            {
                var hudProfilesConfigFilePath = DBHelper.GetPT4HudProfilesFile();

                if (!File.Exists(hudProfilesConfigFilePath))
                {
                    return false;
                }

                var hudProfileBinary = File.ReadAllBytes(hudProfilesConfigFilePath);
                var hudProfileConfig = PT4HudProfileConfig.ReadFromBinary(hudProfileBinary);

                return hudProfileConfig.CashProfiles.Any(x => x.Name.Equals(hudsToInstall[0])) &&
                    hudProfileConfig.TournamentProfiles.Any(x => x.Name.Equals(hudsToInstall[1]));
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, "Failed to detect if predefined HUDs are installed.", e);
            }

            return false;
        }

        public bool IsScalingDisabled()
        {
            try
            {
                var configurationFile = DBHelper.GetPT4ConfigurationFile();
                var iniFile = new IniFile(configurationFile);

                var vectorScaling = iniFile.GetParameter(VectorScalingIniPath);
                var fontScaling = iniFile.GetParameter(FontScalingIniPath);

                return vectorScaling.Equals("N", StringComparison.OrdinalIgnoreCase) && fontScaling.Equals("N", StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, "Failed to check if scaling is disabled in PT4 config.", e);
            }

            return false;
        }

        private void UpdateHudConfiguration()
        {
            var hudProfilesConfigFilePath = DBHelper.GetPT4HudProfilesFile();

            PT4HudProfileConfig hudProfileConfig;

            if (File.Exists(hudProfilesConfigFilePath))
            {
                var hudProfileBinary = File.ReadAllBytes(hudProfilesConfigFilePath);
                hudProfileConfig = PT4HudProfileConfig.ReadFromBinary(hudProfileBinary);
            }
            else
            {
                hudProfileConfig = new PT4HudProfileConfig();
            }

            // add cash profile
            if (!hudProfileConfig.CashProfiles.Any(x => x.Name.Equals(hudsToInstall[0])))
            {
                var cashProfile = new PT4HudProfile
                {
                    Site = iPokerSiteCode,
                    Name = hudsToInstall[0]
                };

                hudProfileConfig.CashProfiles.Add(cashProfile);
            }

            // add tournament profile
            if (!hudProfileConfig.TournamentProfiles.Any(x => x.Name.Equals(hudsToInstall[1])))
            {
                var cashProfile = new PT4HudProfile
                {
                    Site = iPokerSiteCode,
                    Name = hudsToInstall[1]
                };

                hudProfileConfig.TournamentProfiles.Add(cashProfile);
            }

            var hudProfilesBinary = PT4HudProfileConfig.WriteToBinary(hudProfileConfig);
            File.WriteAllBytes(hudProfilesConfigFilePath, hudProfilesBinary);
        }

        private void CopyHudProfiles()
        {
            // logic for setting folder up                               
            var hudProfilesFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "PokerTracker 4", "Data", "Hud");

            if (!Directory.Exists(hudProfilesFilePath))
            {
                return;
            }

            var executingAssembly = Assembly.GetExecutingAssembly();

            foreach (var hudToInstall in hudsToInstall)
            {
                var resourceName = string.Format(hudToInstallPattern, hudToInstall, hudFileExt);

                var hudFile = Path.Combine(hudProfilesFilePath, string.Format("{0}.{1}", hudToInstall, hudFileExt));

                using (var fs = new FileStream(hudFile, FileMode.Create))
                {
                    using (var resourceStream = executingAssembly.GetManifestResourceStream(resourceName))
                    {
                        resourceStream.CopyTo(fs);
                    }
                }
            }
        }
    }
}