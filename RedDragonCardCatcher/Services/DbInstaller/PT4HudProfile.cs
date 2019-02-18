//-----------------------------------------------------------------------
// <copyright file="PT4HudProfile.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

namespace RedDragonCardCatcher.DbInstallers
{
    internal class PT4HudProfile
    {
        // 400 = iPoker
        // Unicode = 2 bytes per symbol => Ф = { 36,4 } but in file it would be {4,36}
        // all is reversed
        public int Site { get; set; }

        public int Limit { get; set; }

        public int Speed { get; set; }

        public int Game { get; set; }

        public int Seats { get; set; }

        public string Name { get; set; }        
    }
}