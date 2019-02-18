﻿//-----------------------------------------------------------------------
// <copyright file="UpdaterError.cs" company="Ace Poker Solutions">
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDragonCardCatcher.Updater.Core
{
    //error codes
    public enum UpdaterError
    {        
        InvalidAppInfoPath,
        AppInfoLoadingFailed,
        InvalidXmlFormat,
        DeserializingFailed,
        DownloadingFailed,
        ComputingHashingFailed,
        InvalidHash,
        UnzippingFailed,
        VerifyingFailed,
        CopyingFailed,
        Unexpected,
    }
}
