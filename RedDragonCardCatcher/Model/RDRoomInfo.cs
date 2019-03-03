//-----------------------------------------------------------------------
// <copyright file="RDRoomInfo.cs" company="Ace Poker Solutions">
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
using static RedDragonCardCatcher.Model.RoomTypeEnum;

namespace RedDragonCardCatcher.Model
{
    internal class RDRoomInfo
    {
        public int RoomId { get; set; }

        public string RoomName { get; set; }

        public ERoomType RoomType { get; set; }

        public IntPtr WindowHandle { get; set; }

        public int MaxPlayers { get; set; }

        public bool IsTournament
        {
            get
            {
                return RoomType == ERoomType.mttRoom || RoomType == ERoomType.sngRoom;
            }
        }

        public string SignUpCost { get; set; }

        public int SignUpFee { get; set; }

        public List<RDPackage> Packages { get; } = new List<RDPackage>();

        public long TournamentStartTime { get; set; }

        public int TournamentStartingStack { get; set; }

        public bool IsDefined => RoomId != 0;
    }
}