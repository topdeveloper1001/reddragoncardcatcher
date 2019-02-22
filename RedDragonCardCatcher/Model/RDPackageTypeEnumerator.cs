//-----------------------------------------------------------------------
// <copyright file="RDPackageTypeEnumerator.cs" company="Ace Poker Solutions">
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
using System.Reflection;

namespace RedDragonCardCatcher.Model
{
    internal class RDPackageTypeEnumerator
    {
        public static void ForEach(Action<RDPackageType, Type> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            foreach (var enumValue in Enum.GetValues(typeof(RDPackageType)))
            {
                Type packageObjectType = Assembly.GetExecutingAssembly().GetType($"{typeof(RDPackageTypeEnumerator).Namespace}.{enumValue}");

                if (packageObjectType != null)
                {
                    action((RDPackageType)enumValue, packageObjectType);
                }
            }
        }
    }
}