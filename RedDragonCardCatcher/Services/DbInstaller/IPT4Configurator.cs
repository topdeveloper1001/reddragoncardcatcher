﻿//-----------------------------------------------------------------------
// <copyright file="IPT4Configurator.cs" company="Ace Poker Solutions">
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
    interface IPT4Configurator
    {
        bool IsPredefinedHUDInstalled();

        void InstallPredefinedHUD();

        bool IsScalingDisabled();

        void DisableScaling();
    }
}