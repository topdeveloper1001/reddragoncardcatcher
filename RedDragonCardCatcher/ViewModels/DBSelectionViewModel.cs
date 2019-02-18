//-----------------------------------------------------------------------
// <copyright file="DBSelectionViewModel.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using Microsoft.Practices.ServiceLocation;
using RedDragonCardCatcher.Common.Log;
using RedDragonCardCatcher.Common.Resources;
using RedDragonCardCatcher.Common.Wpf.Mvvm;
using RedDragonCardCatcher.DbInstallers;
using RedDragonCardCatcher.Entities;
using RedDragonCardCatcher.Settings;
using Prism.Interactivity.InteractionRequest;
using ReactiveUI;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RedDragonCardCatcher.ViewModels
{
    public class DBSelectionViewModel : PopupWindowViewModel, IDBSelectionViewModel
    {
        private readonly ISettingsService settingsService;

        private SettingsModel settingsModel;

        public DBSelectionViewModel()
        {
            settingsService = ServiceLocator.Current.GetInstance<ISettingsService>();
        }

        public override void Configure(object viewModelInfo)
        {
            NotificationRequest = new InteractionRequest<INotification>();

            settingsModel = settingsService.GetSettings();

            SelectCommand = ReactiveCommand.Create<DatabaseType>(db => SelectDatabase(db));

            OnInitialized();
        }

        public InteractionRequest<INotification> NotificationRequest { get; private set; }

        public ReactiveCommand SelectCommand { get; private set; }

        private void SelectDatabase(DatabaseType databaseType)
        {
            var dbInstaller = ServiceLocator.Current.GetInstance<IDbInstaller>(databaseType.ToString());

            try
            {
                if (!dbInstaller.CanInstall(out string[] warnings))
                {
                    var isCancel = false;

                    var notificationViewModelInfo = new NotificationViewModelInfo
                    {
                        Title = CommonResourceManager.Instance.GetResourceString("Common_Settings_DbInstallWarning"),
                        Notification = string.Join(Environment.NewLine, warnings.Select(x => CommonResourceManager.Instance.GetResourceString(x))),
                        Buttons = MessageBoxButtons.OKCancel,
                        OKAction = () => dbInstaller.Install(),
                        CancelAction = () => isCancel = true
                    };

                    var notificationRequestInfo = new NotificationPopupRequestInfo(notificationViewModelInfo);
                    NotificationRequest.Raise(notificationRequestInfo);

                    if (isCancel)
                    {
                        return;
                    }
                }
                else
                {
                    dbInstaller.Install();
                }
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to install database [{databaseType}].", e);
            }

            settingsModel.Database = databaseType;
            settingsService.SaveSettings(settingsModel);

            if (databaseType == DatabaseType.PT4)
            {
                ShowPT4InstallationDialogs();
            }

            LogProvider.Log.Info(this, $"{databaseType} has been selected.");

            OnClosed();
        }

        private void ShowPT4InstallationDialogs()
        {
            var pt4Configurator = ServiceLocator.Current.GetInstance<IPT4Configurator>();

            if (!pt4Configurator.IsPredefinedHUDInstalled())
            {
                var notificationViewModelInfo = new NotificationViewModelInfo
                {
                    Title = CommonResourceManager.Instance.GetResourceString("Common_Settings_PT4HUDInstallation"),
                    Notification = CommonResourceManager.Instance.GetResourceString("Common_Settings_PT4HUDInstallationText"),
                    Buttons = MessageBoxButtons.YesNo,
                    YesAction = () => pt4Configurator.InstallPredefinedHUD(),
                };

                var notificationRequestInfo = new NotificationPopupRequestInfo(notificationViewModelInfo);
                NotificationRequest.Raise(notificationRequestInfo);
            }

            if (!pt4Configurator.IsScalingDisabled())
            {
                var notificationViewModelInfo = new NotificationViewModelInfo
                {
                    Title = CommonResourceManager.Instance.GetResourceString("Common_Settings_PT4Configuration"),
                    Notification = CommonResourceManager.Instance.GetResourceString("Common_Settings_PT4ConfigurationText"),
                    Buttons = MessageBoxButtons.YesNo,
                    YesAction = () => pt4Configurator.DisableScaling(),
                };

                var notificationRequestInfo = new NotificationPopupRequestInfo(notificationViewModelInfo);
                NotificationRequest.Raise(notificationRequestInfo);
            }
        }
    }
}