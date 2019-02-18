//-----------------------------------------------------------------------
// <copyright file="ResourceRegistrator.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using System.Reflection;
using System.Threading;

namespace RedDragonCardCatcher.Common.Resources
{
    public class ResourceRegistrator
    {
        public static void Initialization()
        {
            RegisterResources(CommonResourceManager.Instance);
        }

        static int resourcesRegistered;
        static readonly FileResourceManager commonResourceManager = new FileResourceManager("Common_", "RedDragonCardCatcher.Common.Resources.Common", Assembly.GetExecutingAssembly());
        static readonly FileResourceManager errorsResourceManager = new FileResourceManager("Error_", "RedDragonCardCatcher.Common.Resources.Errors", Assembly.GetExecutingAssembly());
        static readonly FileResourceManager enumsResourceManager = new FileResourceManager("Enum_", "RedDragonCardCatcher.Common.Resources.Enums", Assembly.GetExecutingAssembly());
        static readonly FileResourceManager notificationsResourceManager = new FileResourceManager("Notifications_", "RedDragonCardCatcher.Common.Resources.Notifications", Assembly.GetExecutingAssembly());
        static readonly FileResourceManager systemSettingsResourceManager = new FileResourceManager("SystemSettings_", "RedDragonCardCatcher.Common.Resources.SystemSettings", Assembly.GetExecutingAssembly());

        public static void RegisterResources(CommonResourceManager resourceManager)
        {
            if (Interlocked.Exchange(ref resourcesRegistered, 1) == 1)
            {
                return;
            }

            resourceManager.RegisterResourceManager(commonResourceManager);
            resourceManager.RegisterResourceManager(errorsResourceManager);
            resourceManager.RegisterResourceManager(enumsResourceManager);
            resourceManager.RegisterResourceManager(notificationsResourceManager);
            resourceManager.RegisterResourceManager(systemSettingsResourceManager);
        }
    }
}