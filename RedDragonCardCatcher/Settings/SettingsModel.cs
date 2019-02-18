//-----------------------------------------------------------------------
// <copyright file="GGNImporter.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.Entities;
using System.Runtime.Serialization;

namespace RedDragonCardCatcher.Settings
{
    [DataContract(Name = "Settings")]
    public class SettingsModel
    {
        [DataMember(Name = "AutomaticUpdates")]
        public bool AutomaticUpdatingEnabled { get; set; }

        [DataMember(Name = "Logging")]
        public bool IsAdvancedLoggingEnabled { get; set; }

        [DataMember(Name = "Database")]
        public DatabaseType Database { get; set; }

        [DataMember(Name = "DisableWarnings")]
        public bool DisableWarnings { get; set; }

        [DataMember(Name = "IsFirstLaunch")]
        public bool IsFirstLaunch { get; set; }

        [DataMember(Name = "UsePlayerId")]
        public bool UsePlayerId { get; set; }

        public SettingsModel()
        {
            SetDefaults();
        }

        public SettingsModel Clone()
        {
            var clone = (SettingsModel)MemberwiseClone();
            return clone;
        }

        private void SetDefaults()
        {
            AutomaticUpdatingEnabled = true;
            IsAdvancedLoggingEnabled = true;
            DisableWarnings = false;
            IsFirstLaunch = true;
            UsePlayerId = false;
            Database = DatabaseType.DH;
        }
    }
}