//-----------------------------------------------------------------------
// <copyright file="RDHandActionType.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

namespace RedDragonCardCatcher.Model
{
    internal enum RDHandActionType
    {
        WaitingState = 0,
        Call = 1,
        Fold = 2,
        Check = 4,
        Raise = 8,
        AllIn = 16,
        Bet = 18
    }
}