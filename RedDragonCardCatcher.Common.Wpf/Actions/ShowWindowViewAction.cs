//-----------------------------------------------------------------------
// <copyright file="ShowWindowViewAction.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.Common.Wpf.Controls;
using RedDragonCardCatcher.Common.Wpf.Interactivity;
using Microsoft.Practices.ServiceLocation;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Windows;

namespace RedDragonCardCatcher.Common.Wpf.Actions
{
    public class ShowWindowViewAction : ShowViewActionBase<RDCCWindow>
    {
        protected override void Activate(RDCCWindow window)
        {
            if (window == null)
            {
                return;
            }

            if (!window.IsVisible)
            {
                window.Show();
                return;
            }

            window.Activate();
        }

        protected override void CloseWindow(RDCCWindow window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        protected override RDCCWindow CreateWindow(INotification context)
        {
            var window = new RDCCWindow
            {
                Title = context != null ? context.Title : string.Empty
            };

            if (StartupLocation == StartupLocationOption.CenterScreen)
            {
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

            return window;
        }

        protected override void OnClosed(RDCCWindow window, Action callback)
        {
            EventHandler handler = null;

            handler = (o, e) =>
            {
                NonTopmostPopup.DisableTopMost = false;
                window.Closed -= handler;
                window.Content = null;

                if (SingleOnly)
                {
                    var windowController = ServiceLocator.Current.GetInstance<IWindowController>();
                    windowController.RemoveWindow(ViewName);
                }

                callback?.Invoke();
            };

            window.Closed += handler;
        }

        protected override void SetWindowPosition(RDCCWindow window, double left, double top)
        {
            if (window == null)
            {
                return;
            }

            window.Left = left;
            window.Top = top;
        }

        protected override void Show(RDCCWindow window)
        {
            NonTopmostPopup.DisableTopMost = true;

            if (SingleOnly)
            {
                var windowController = ServiceLocator.Current.GetInstance<IWindowController>();
                windowController.AddWindow(ViewName, window, () => window.Close());
            }

            if (IsModal)
            {
                window.Owner = Application.Current.MainWindow;
                window.ShowDialog();
                return;
            }

            window.Show();
        }
    }
}