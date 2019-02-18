//-----------------------------------------------------------------------
// <copyright file="SettingsViewModel.cs" company="Ace Poker Solutions">
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
using RedDragonCardCatcher.Importers;
using RedDragonCardCatcher.Services;
using RedDragonCardCatcher.Settings;
using Prism.Interactivity.InteractionRequest;
using ReactiveUI;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace RedDragonCardCatcher.ViewModels
{
    public class SettingsViewModel : PopupWindowViewModel, ISettingsViewModel
    {
        private readonly ISettingsService settingsService;

        private SettingsModel settingsModel;

        public SettingsViewModel()
        {
            settingsService = ServiceLocator.Current.GetInstance<ISettingsService>();
        }

        #region Properties

        public InteractionRequest<INotification> NotificationRequest { get; private set; }

        public bool IsAdvancedLoggingEnabled
        {
            get
            {
                return settingsModel.IsAdvancedLoggingEnabled;
            }
            set
            {
                if (settingsModel.IsAdvancedLoggingEnabled == value)
                {
                    return;
                }

                settingsModel.IsAdvancedLoggingEnabled = value;

                this.RaisePropertyChanged();
            }
        }

        public bool AutomaticUpdatingEnabled
        {
            get
            {
                return settingsModel.AutomaticUpdatingEnabled;
            }
            set
            {
                if (settingsModel.AutomaticUpdatingEnabled == value)
                {
                    return;
                }

                settingsModel.AutomaticUpdatingEnabled = value;

                this.RaisePropertyChanged();
            }
        }

        public DatabaseType Database
        {
            get
            {
                return settingsModel.Database;
            }
            set
            {
                if (settingsModel.Database == value)
                {
                    return;
                }

                settingsModel.Database = value;

                this.RaisePropertyChanged();
            }
        }

        public bool DisableWarnings
        {
            get
            {
                return settingsModel.DisableWarnings;
            }
            set
            {
                if (settingsModel.DisableWarnings == value)
                {
                    return;
                }

                settingsModel.DisableWarnings = value;

                this.RaisePropertyChanged();
            }
        }

        public bool UsePlayerId
        {
            get
            {
                return settingsModel.UsePlayerId;
            }
            set
            {
                if (settingsModel.UsePlayerId == value)
                {
                    return;
                }

                settingsModel.UsePlayerId = value;

                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands        

        public ReactiveCommand ApplyCommand { get; private set; }

        public ReactiveCommand CancelCommand { get; private set; }

        public ReactiveCommand CreateLogsCommand { get; private set; }

        #endregion

        public override void Configure(object viewModelInfo)
        {
            Initialize();
            OnInitialized();
        }

        private void Initialize()
        {
            NotificationRequest = new InteractionRequest<INotification>();

            settingsModel = settingsService.GetSettings();

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            var importerService = ServiceLocator.Current.GetInstance<IImporterService>();

            var canReset = Observable.Return(!importerService.IsStarted);

            ApplyCommand = ReactiveCommand.Create(() => Apply());
            CancelCommand = ReactiveCommand.Create(() => OnClosed());
            CreateLogsCommand = ReactiveCommand.Create(() => CreateLogs());
        }

        private void Apply()
        {
            var existingSettings = settingsService.GetSettings();

            // db was changed
            if (existingSettings.Database != Database)
            {
                var dbInstaller = ServiceLocator.Current.GetInstance<IDbInstaller>(Database.ToString());

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
                            Database = existingSettings.Database;
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
                    LogProvider.Log.Error(this, $"Failed to update db settings [{Database}].", e);
                }

                if (Database == DatabaseType.PT4)
                {
                    ShowPT4InstallationDialogs();
                }

                LogProvider.Log.Info($"Database has been changed from {existingSettings.Database} to {Database}");
            }

            settingsService.SaveSettings(settingsModel);

            if (IsRestartRequired(existingSettings, settingsModel))
            {
                ShowImporterRunningWarning();
            }

            OnClosed();
        }

        private void CreateLogs()
        {
            var logCollector = ServiceLocator.Current.GetInstance<ILogCollector>();

            StartAsyncOperation(() => logCollector.CollectAllLogs(), () =>
            {
                var notificationViewModelInfo = new NotificationViewModelInfo
                {
                    Title = CommonResourceManager.Instance.GetResourceString("Common_Settings_LogsCreatedTitle"),
                    Notification = CommonResourceManager.Instance.GetResourceString("Common_Settings_LogsCreatedText"),
                    Buttons = MessageBoxButtons.OKCancel,
                    OKAction = () => OpenAppFolderInExplorer()
                };

                var notificationRequestInfo = new NotificationPopupRequestInfo(notificationViewModelInfo);
                NotificationRequest.Raise(notificationRequestInfo);
            });
        }

        private void ShowImporterRunningWarning()
        {
            var importerService = ServiceLocator.Current.GetInstance<IImporterService>();

            if (!importerService.IsStarted)
            {
                return;
            }

            var notificationViewModelInfo = new NotificationViewModelInfo
            {
                Title = CommonResourceManager.Instance.GetResourceString("Common_Settings_ImporterRunningWarningTitle"),
                Notification = CommonResourceManager.Instance.GetResourceString("Common_Settings_ImporterRunningWarning"),
                Buttons = MessageBoxButtons.OK
            };

            var notificationRequestInfo = new NotificationPopupRequestInfo(notificationViewModelInfo);
            NotificationRequest.Raise(notificationRequestInfo);
        }

        private void OpenAppFolderInExplorer()
        {
            try
            {
                Process.Start(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, "Failed to open current app folder in file explorer.", e);
            }
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

        private bool IsRestartRequired(SettingsModel oldSettings, SettingsModel newSettings)
        {
            return oldSettings.Database != newSettings.Database ||
                oldSettings.IsAdvancedLoggingEnabled != newSettings.IsAdvancedLoggingEnabled;
        }
    }
}