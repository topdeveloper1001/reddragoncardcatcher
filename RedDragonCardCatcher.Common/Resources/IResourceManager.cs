﻿//-----------------------------------------------------------------------
// <copyright file="IResourceManager.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using System.Globalization;

namespace RedDragonCardCatcher.Common.Resources
{
    public interface IResourceManager
    {       
        string GetResourceString(string resourceKey);

        string GetResourceString(string resourceKey, CultureInfo cultureInfo);
      
        object GetResourceObject(string resourceKey);

        object GetResourceObject(string resourceKey, CultureInfo cultureInfo);
     
        bool Match(string resourceKey);
    }
}