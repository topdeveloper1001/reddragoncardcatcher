﻿//-----------------------------------------------------------------------
// <copyright file="MomoEmulatorProvider.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using System.Text;

namespace RedDragonCardCatcher.Importers
{
    internal sealed class MomoEmulatorProvider : VirtualBoxEmulator
    {
        // adb.exe
        private static readonly byte[] location = new byte[] { 0x61, 0x64, 0x62, 0x2E, 0x65, 0x78, 0x65 };

        public override string EmulatorName => "MOMO";

        protected override string ProcessName => "dnplayer";

        protected override string InstanceArgumentPrefix => "index=";

        protected override string VbProcessName => "LdBoxHeadless";

        protected override string VbInstanceArgumentPrefix => "leidian";

        protected override int? EmptyInstanceNumber => 0;

        protected override string ExtractInstanceNumber(string instanceIndexText)
        {
            return instanceIndexText.TrimEnd('|');
        }

        public override string GetAdbLocation()
        {
            return Encoding.ASCII.GetString(location);
        }
    }
}