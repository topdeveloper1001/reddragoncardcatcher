//-----------------------------------------------------------------------
// <copyright file="HM2Service.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using HandHistories.Converters;
using Microsoft.Practices.ServiceLocation;
using Prism.Events;
using RedDragonCardCatcher.Common.Linq;
using RedDragonCardCatcher.Common.Log;
using RedDragonCardCatcher.Common.Resources;
using RedDragonCardCatcher.Common.WinApi;
using RedDragonCardCatcher.Events;
using RedDragonCardCatcher.Overlays;
using RedDragonCardCatcher.Services;
using RedDragonCardCatcher.Settings;
using System;
using System.Collections.Generic;
using System.Windows;

namespace RedDragonCardCatcher.Importers
{
    internal class HM2Service : IDatabaseService
    {
        private readonly IHandHistoryFileService handHistoryFileService;
        private readonly IEventAggregator eventAggregator;

        private static readonly Dictionary<IntPtr, RDOverlayWindow> overlayWindows = new Dictionary<IntPtr, RDOverlayWindow>();

        public HM2Service()
        {
            handHistoryFileService = ServiceLocator.Current.GetInstance<IHandHistoryFileService>();
            eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
        }

        public bool IsAdvancedLogEnabled { get; set; }

        public virtual void Import(HandHistoryData handHistoryData)
        {
            try
            {
                handHistoryData.HandHistory.TableName = RemoveUnsupportedSymbols(handHistoryData.HandHistory.TableName);

                var title = GetTableTitle(handHistoryData);

                AttachOverlayWindow(handHistoryData.WindowHandle, title);

                var ipokerConverter = new IpokerConverter();
                var handHistory = ipokerConverter.Convert(handHistoryData.HandHistory);

                var handHistoryFileInfo = new HandHistoryFileInfo
                {
                    HandNumber = handHistoryData.HandHistory.HandId.ToString(),
                    HandHistoryXml = handHistory.ToHandHistoryXmlDocument(),
                    FileName = handHistoryData.HandHistory.TableName
                };

                handHistoryFileService.Save(handHistoryFileInfo);
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to import hand history {handHistoryData.HandHistory.HandId} [{handHistoryData.WindowHandle}]", e);
            }
        }

        public virtual void SendCloseHUDRequest(IntPtr[] windowHandles)
        {
            windowHandles.ForEach(hwnd =>
            {
                try
                {
                    if (overlayWindows.TryGetValue(hwnd, out RDOverlayWindow overlayWindow))
                    {
                        Application.Current.Dispatcher.Invoke(() => overlayWindow.CloseWindow());
                        overlayWindows.Remove(hwnd);

                        LogProvider.Log.Info(this, $"Closed attached window '{overlayWindow.Title}'. [{hwnd}]");
                    }
                }
                catch (Exception e)
                {
                    LogProvider.Log.Error(this, $"Failed to close window [{hwnd}]", e);
                }
            });
        }

        public virtual void SendShowHUDRequest(string loadingTextKey, IntPtr windowHandle)
        {
        }

        public virtual void SendWarningRequest(string loadingTextKey, IntPtr windowHandle)
        {
            var settings = ServiceLocator.Current.GetInstance<ISettingsService>();
            var settingsModel = settings.GetSettings();

            if (settingsModel != null && settingsModel.DisableWarnings)
            {
                return;
            }

            eventAggregator.GetEvent<ShowWarningEvent>().Publish(
                new ShowWarningEventArgs(CommonResourceManager.Instance.GetResourceString(loadingTextKey), windowHandle));
        }

        public virtual void Clear()
        {
            try
            {
                UnsetHooks();

                Application.Current.Dispatcher.Invoke(() =>
                {
                    foreach (var overlayWindow in overlayWindows.Values)
                    {
                        overlayWindow.CloseWindow();
                    }
                });

                overlayWindows.Clear();
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, "Failed to clear data.", e);
            }
        }

        protected virtual void AttachOverlayWindow(IntPtr tableHwnd, string title)
        {
            if (!overlayWindows.TryGetValue(tableHwnd, out RDOverlayWindow overlayWindow))
            {
                try
                {
                    SetHooks(tableHwnd);

                    overlayWindow = CreateOverlayWindow();
                    Application.Current.Dispatcher.Invoke(() => overlayWindow.Initialize(tableHwnd, title));
                    overlayWindows.Add(tableHwnd, overlayWindow);

                    LogProvider.Log.Info(this, $"Attached window '{title}' to table [{tableHwnd}]");
                }
                catch (Exception e)
                {
                    LogProvider.Log.Error(this, $"Failed to attach window to table [{tableHwnd}]", e);
                }

                return;
            }

            WinApi.SetWindowText(overlayWindow.OverlayHwnd, title);
        }

        protected virtual string GetTableTitle(HandHistoryData handHistoryData)
        {
            var stacks = handHistoryData.HandHistory.GameDescription != null && handHistoryData.HandHistory.GameDescription.Limit != null ?
                $"${handHistoryData.HandHistory.GameDescription.Limit.SmallBlind}/${handHistoryData.HandHistory.GameDescription.Limit.BigBlind}" :
                "$1/$2";

            var title = handHistoryData.HandHistory.GameDescription != null && handHistoryData.HandHistory.GameDescription.IsTournament ?
                $"{handHistoryData.HandHistory.TableName} {handHistoryData.WindowHandle} | NL Hold'em | Level 1 | {stacks.Replace("$", string.Empty)}" :
                $"{handHistoryData.HandHistory.TableName} {handHistoryData.WindowHandle} | {stacks} | NL Hold'em";

            return title;
        }

        protected virtual string RemoveUnsupportedSymbols(string text)
        {
            return text.Trim().
                    Replace("#", string.Empty).
                    Replace(" ", string.Empty).
                    Replace("_", string.Empty).
                    Replace("/", string.Empty).
                    Replace("'", string.Empty).
                    Replace("[", string.Empty).
                    Replace("]", string.Empty).
                    Replace("(", string.Empty).
                    Replace(")", string.Empty).
                    Replace("-", string.Empty).
                    Replace("$", "D").
                    Replace(".", string.Empty).
                    Replace(",", string.Empty).
                    Replace("&", string.Empty).
                    Replace("|", string.Empty).
                    Replace("&amp;", string.Empty).
                    Replace("<", string.Empty).
                    Replace(">", string.Empty).
                    Replace("\"", string.Empty).
                    Replace("+", "plus");
        }

        protected virtual RDOverlayWindow CreateOverlayWindow()
        {
            return new RDOverlayWindow();
        }

        #region Hook infrastructure

        private readonly Dictionary<uint, IntPtr> moveHooks = new Dictionary<uint, IntPtr>();
        private readonly Dictionary<uint, IntPtr> closeHooks = new Dictionary<uint, IntPtr>();

        // need to ensure delegate is not collected while we're using it,
        // storing it in a class field is simplest way to do this.
        private static WinApi.WinEventDelegate moveCallback = WindowMoved;
        private static WinApi.WinEventDelegate closeCallback = WindowClosed;

        private static void WindowMoved(IntPtr hWinEventHook, uint eventType,
                IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (idObject != 0 || idChild != 0)
            {
                return;
            }

            if (overlayWindows.TryGetValue(hwnd, out RDOverlayWindow overlayWindow))
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    try
                    {
                        overlayWindow.SetSizeToTable();
                    }
                    catch (Exception ex)
                    {
                        LogProvider.Log.Error(typeof(HM2Service), "Could not resize overlaying window", ex);
                    }
                });
            }
        }

        private static void WindowClosed(IntPtr hWinEventHook, uint eventType,
               IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (idObject != 0 || idChild != 0)
            {
                return;
            }

            if (overlayWindows.TryGetValue(hwnd, out RDOverlayWindow overlayWindow))
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    try
                    {
                        overlayWindow.CloseWindow();
                    }
                    catch (Exception ex)
                    {
                        LogProvider.Log.Error(typeof(HM2Service), "Could not close overlaying window", ex);
                    }
                });

                overlayWindows.Remove(hwnd);

                LogProvider.Log.Info(typeof(HM2Service), $"Window '{overlayWindow.Title}' was closed externally. [{hwnd}]");
            }
        }

        private const uint EVENT_OBJECT_LOCATIONCHANGE = 0x800B;
        private const uint EVENT_OBJECT_DESTROY = 0x8001;
        private const uint WINEVENT_OUTOFCONTEXT = 0;

        private void SetHooks(IntPtr hwnd)
        {
            WinApi.GetWindowThreadProcessId(hwnd, out uint processId);

            if (processId == 0)
            {
                return;
            }

            if (!moveHooks.ContainsKey(processId))
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    var moveHook = WinApi.SetWinEventHook(EVENT_OBJECT_LOCATIONCHANGE, EVENT_OBJECT_LOCATIONCHANGE, IntPtr.Zero,
                        moveCallback, processId, 0, WINEVENT_OUTOFCONTEXT);

                    moveHooks.Add(processId, moveHook);
                });
            }

            if (!closeHooks.ContainsKey(processId))
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    var closeHook = WinApi.SetWinEventHook(EVENT_OBJECT_DESTROY, EVENT_OBJECT_DESTROY, IntPtr.Zero,
                    closeCallback, processId, 0, WINEVENT_OUTOFCONTEXT);

                    closeHooks.Add(processId, closeHook);
                });
            }
        }

        private void UnsetHooks()
        {
            moveHooks.Values.ForEach(moveHook => WinApi.UnhookWinEvent(moveHook));
            closeHooks.Values.ForEach(closeHook => WinApi.UnhookWinEvent(closeHook));
        }

        #endregion
    }
}