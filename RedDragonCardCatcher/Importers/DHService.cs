//-----------------------------------------------------------------------
// <copyright file="DHService.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.Common.Extensions;
using RedDragonCardCatcher.Common.Log;
using RedDragonCardCatcher.Common.Resources;
using RedDragonCardCatcher.Entities;
using System;
using System.ServiceModel;

namespace RedDragonCardCatcher.Importers
{
    internal class DHService : IDatabaseService
    {
        private IDHImporterService dhImporterService;

        public bool IsAdvancedLogEnabled { get; set; }

        public void Import(HandHistoryData handHistoryData)
        {
            try
            {
                InitializeDHImporterService();

                var handHistoryText = SerializationHelper.SerializeObject(handHistoryData.HandHistory);

                var handHistoryDto = new HandHistoryDto
                {
                    PokerSite = EnumPokerSites.RedDragon,
                    WindowHandle = handHistoryData.WindowHandle.ToInt32(),
                    HandText = handHistoryText
                };

                dhImporterService.ImportHandHistory(handHistoryDto);

                LogProvider.Log.Info(this, $"Hand #{handHistoryData.HandHistory.HandId} has been sent. [{handHistoryData.HandHistory.TableName}] [{handHistoryData.WindowHandle}]");
            }
            catch (EndpointNotFoundException)
            {
                LogProvider.Log.Error(this, $"DriveHUD isn't running. Hand #{handHistoryData.HandHistory.HandId} hasn't been sent. [{handHistoryData.HandHistory.TableName}] [{handHistoryData.WindowHandle}]");
                dhImporterService = null;
            }
            catch (Exception e)
            {
                if (IsAdvancedLogEnabled)
                {
                    LogProvider.Log.Error(this, $"Hand #{handHistoryData.HandHistory.HandId} hasn't been sent. [{handHistoryData.HandHistory.TableName}] [{handHistoryData.WindowHandle}]", e);
                }
                else
                {
                    LogProvider.Log.Error(this, $"Hand #{handHistoryData.HandHistory.HandId} hasn't been sent. [{handHistoryData.HandHistory.TableName}] [{handHistoryData.WindowHandle}]");
                }

                dhImporterService = null;
            }
        }

        public void SendCloseHUDRequest(IntPtr[] windowHandles)
        {
            InitializeDHImporterService();

            foreach (var windowHandle in windowHandles)
            {
                try
                {
                    dhImporterService.CloseHUD(windowHandle.ToInt32());
                    LogProvider.Log.Info(this, $"Sent close HUD request. [{windowHandle}]");
                }
                catch (EndpointNotFoundException)
                {
                    LogProvider.Log.Error(this, $"DriveHUD isn't running. Request to close HUD hasn't been sent [{windowHandle.ToInt32()}].");
                    dhImporterService = null;
                }
                catch (Exception e)
                {
                    if (IsAdvancedLogEnabled)
                    {
                        LogProvider.Log.Error(this, $"Failed to send request to close HUD [{windowHandle.ToInt32()}].", e);
                    }

                    dhImporterService = null;
                }
            }
        }

        public void SendShowHUDRequest(string loadingTextKey, IntPtr windowHandle)
        {
            if (windowHandle == IntPtr.Zero)
            {
                return;
            }

            var loadingText = CommonResourceManager.Instance.GetResourceString(loadingTextKey);

            InitializeDHImporterService();

            if (dhImporterService == null)
            {
                return;
            }

            try
            {
                dhImporterService.ShowHUD(EnumPokerSites.PPPoker, windowHandle.ToInt32(), loadingText);
            }
            catch (EndpointNotFoundException)
            {
                LogProvider.Log.Error(this, $"DriveHUD isn't running. Request to show HUD hasn't been sent [{windowHandle.ToInt32()}].");
                dhImporterService = null;
            }
            catch (Exception e)
            {
                if (IsAdvancedLogEnabled)
                {
                    LogProvider.Log.Error(this, $"Failed to send request to show HUD [{windowHandle.ToInt32()}].", e);
                }

                dhImporterService = null;
            }
        }

        public void SendWarningRequest(string loadingTextKey, IntPtr windowHandle)
        {
            SendShowHUDRequest(loadingTextKey, windowHandle);
        }

        public void Clear()
        {
        }

        protected virtual void InitializeDHImporterService()
        {
            if (dhImporterService != null)
            {
                return;
            }

            var endpointAddress = CommonResourceManager.Instance.GetResourceString("SystemSettings_ImporterPipeAddress");
            var pipeFactory = new ChannelFactory<IDHImporterService>(new NetNamedPipeBinding(), new EndpointAddress(endpointAddress));
            dhImporterService = pipeFactory.CreateChannel();
        }
    }
}