//-----------------------------------------------------------------------
// <copyright file="ErrorBox.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.ViewModels;
using System.Windows.Forms;

namespace RedDragonCardCatcher.Views
{
    public class ErrorBox
    {
        public static void Show(string title, string notification, MessageBoxButtons buttons)
        {
            var notificationViewModelInfo = new NotificationViewModelInfo
            {
                Title = title,
                Notification = notification,
                Buttons = buttons
            };

            var notificationViewModel = new NotificationViewModel();
            notificationViewModel.Configure(notificationViewModelInfo);

            var notificationView = new ErrorView
            {
                DataContext = notificationViewModel,
                Owner = System.Windows.Application.Current.MainWindow
            };

            notificationViewModel.Closed += (s, a) => notificationView?.Close();

            notificationView.ShowDialog();
        }
    }
}