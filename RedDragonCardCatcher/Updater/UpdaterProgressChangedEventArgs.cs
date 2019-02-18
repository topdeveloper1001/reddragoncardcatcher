﻿//-----------------------------------------------------------------------
// <copyright file="UpdaterProgressChangedEventArgs.cs" company="Ace Poker Solutions">
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

namespace RedDragonCardCatcher.Updater.Core
{
    internal class UpdaterProgressChangedEventArgs : EventArgs
    {
        public UpdaterProgressChangedEventArgs(int progress, OperationStatus operation)
        {
            Progress = progress;
            Operation = operation;
        }

        public int Progress { get; private set; }

        public OperationStatus Operation { get; private set; }
    }
}