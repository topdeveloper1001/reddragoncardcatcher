//-----------------------------------------------------------------------
// <copyright file="RDCCInternalException.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.Common.Resources;
using System;

namespace RedDragonCardCatcher.Common.Exceptions
{
    /// <summary>
    /// Class for internal RDCC exceptions
    /// </summary>
    public class RDCCInternalException : LocalizableException
    {
        public RDCCInternalException(ILocalizableString message)
            : base(message, null)
        {
        }

        public RDCCInternalException(ILocalizableString message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}