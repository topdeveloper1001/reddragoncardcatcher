//-----------------------------------------------------------------------
// <copyright file="DBHelper.cs" company="Ace Poker Solutions">
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
using System.IO;

namespace RedDragonCardCatcher.DbInstallers
{
    internal class DBHelper
    {
        public static string GetPT4ConfigurationFile()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PokerTracker 4", "Config", "PokerTracker.cfg");
        }

        public static string GetPT4HudProfilesFile()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PokerTracker 4", "Data", "HudProfiles.pt4");
        }

        public static string GetHM2ConfigurationFile()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HoldemManager", "HoldemManager.config");
        }
    }
}