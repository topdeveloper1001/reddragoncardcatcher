//-----------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Ace Poker Solutions">
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
using RedDragonCardCatcher.Common.Utils;
using RedDragonCardCatcher.Common.WinApi;
using RedDragonCardCatcher.Common.Wpf.Mvvm;
using RedDragonCardCatcher.Events;
using RedDragonCardCatcher.Importers;
using RedDragonCardCatcher.Licensing;
using RedDragonCardCatcher.Settings;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace RedDragonCardCatcher.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IImporterService importerService;
        private IEventAggregator eventAggregator;

        public MainWindowViewModel()
        {
            Initialize();
        }

        #region Properties

        public InteractionRequest<INotification> SettingsNotificationRequest { get; private set; }

        public InteractionRequest<INotification> RegistrationNotificationRequest { get; private set; }

        public InteractionRequest<INotification> UpdateNotificationRequest { get; private set; }

        public InteractionRequest<INotification> NotificationRequest { get; private set; }

        public InteractionRequest<INotification> DBSelectionRequest { get; private set; }

        public string Version
        {
            get
            {
                return string.Format(CommonResourceManager.Instance.GetResourceString("Common_Version"), App.Version);
            }
        }

        private bool isRunning;

        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref isRunning, value);
            }
        }

        private bool isTrial;

        public bool IsTrial
        {
            get
            {
                return isTrial;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref isTrial, value);
            }
        }

        private bool isUpgradable;

        public bool IsUpgradable
        {
            get
            {
                return isUpgradable;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref isUpgradable, value);
            }
        }

        public string LicenseText
        {
            get
            {
                var licenseService = ServiceLocator.Current.GetInstance<ILicenseService>();

                IEnumerable<string> licenseStrings;

                if (licenseService.LicenseInfos.Any(x => x.IsRegistered && !x.IsTrial))
                {
                    licenseStrings = licenseService.LicenseInfos
                        .Where(x => x.IsRegistered && !x.IsTrial)
                        .Select(x => x.License.Edition);
                }
                else
                {
                    licenseStrings = licenseService.LicenseInfos
                        .Where(x => x.IsRegistered)
                        .Select(x => x.License.Edition);
                }

                return string.Join(" + ", licenseStrings);
            }
        }

        #endregion

        #region Commands

        public ICommand StartStopCommand { get; private set; }

        public ReactiveCommand SettingsCommand { get; private set; }

        public ReactiveCommand TroubleshootCommand { get; private set; }

        public ReactiveCommand OnlineManualCommand { get; private set; }

        public ReactiveCommand UpgradeCommand { get; private set; }

        #endregion

        public void RefreshLicenseText()
        {
            RaisePropertyChanged(() => LicenseText);
        }

        public void ShowUpdateView()
        {
            var updatePopupRequestInfo = new UpdatePopupRequestInfo(App.UpdateApplicationInfo);
            UpdateNotificationRequest.Raise(updatePopupRequestInfo);
        }

        public void CheckAndShowDBSelection()
        {
            var settingsService = ServiceLocator.Current.GetInstance<ISettingsService>();
            var settings = settingsService.GetSettings();

            if (settings.IsFirstLaunch)
            {
                var dbSelectionPopupRequestInfo = new DBSelectionPopupRequestInfo();
                DBSelectionRequest.Raise(dbSelectionPopupRequestInfo);

                settings = settingsService.GetSettings();
                settings.IsFirstLaunch = false;
                settingsService.SaveSettings(settings);
            }
        }

        private void Initialize()
        {
            SettingsNotificationRequest = new InteractionRequest<INotification>();
            RegistrationNotificationRequest = new InteractionRequest<INotification>();
            UpdateNotificationRequest = new InteractionRequest<INotification>();
            NotificationRequest = new InteractionRequest<INotification>();
            DBSelectionRequest = new InteractionRequest<INotification>();

            importerService = ServiceLocator.Current.GetInstance<IImporterService>();
            importerService.ImportingStopped += OnImportingStopped;

            eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator.GetEvent<ShowWarningEvent>().Subscribe(OnShowWarning, ThreadOption.UIThread);

            InitializeCommands();
        }

        private void OnImportingStopped(object sender, EventArgs e)
        {
            IsRunning = false;
            System.Windows.Application.Current?.Dispatcher.Invoke(() => RefreshCommandsCanExecute());
        }

        private void RefreshCommandsCanExecute()
        {
            (StartStopCommand as DelegateCommand)?.RaiseCanExecuteChanged();
        }

        private void InitializeCommands()
        {
            StartStopCommand = new DelegateCommand(() =>
            {
                if (IsRunning)
                {
                    importerService.StopImport();
                    IsRunning = false;
                }
                else
                {
                    IsRunning = true;
                    importerService.StartImport();
                }

                RefreshCommandsCanExecute();

            }, () => !importerService.IsStarted && !isRunning || importerService.IsStarted && isRunning);

            SettingsCommand = ReactiveCommand.Create(() =>
            {
                var requestInfo = new SettingsPopupRequestInfo();
                SettingsNotificationRequest.Raise(requestInfo);
            });

            TroubleshootCommand = ReactiveCommand.Create(() =>
            {
                try
                {
                    Process.Start(BrowserHelper.GetDefaultBrowserPath(), CommonResourceManager.Instance.GetResourceString("Common_TroubleshootLink"));
                }
                catch (Exception ex)
                {
                    LogProvider.Log.Error(this, "Could not open troubleshoot link", ex);
                }
            });

            OnlineManualCommand = ReactiveCommand.Create(() =>
            {
                try
                {
                    Process.Start(BrowserHelper.GetDefaultBrowserPath(), CommonResourceManager.Instance.GetResourceString("Common_ManualLink"));
                }
                catch (Exception ex)
                {
                    LogProvider.Log.Error(this, "Could not open online manual link", ex);
                }
            });

            UpgradeCommand = ReactiveCommand.Create(() => Upgrade());
        }

        private void Upgrade()
        {
            var registrationPopupRequestInfo = new RegistrationPopupRequestInfo(true);

            RegistrationNotificationRequest.Raise(registrationPopupRequestInfo);

            var licenseService = ServiceLocator.Current.GetInstance<ILicenseService>();

            IsTrial = licenseService.IsTrial;
            IsUpgradable = licenseService.IsUpgradable;

            RefreshLicenseText();
        }

        private void OnShowWarning(ShowWarningEventArgs args)
        {
            var message = args.WarningText;

            if (args.WindowHandle != IntPtr.Zero && WinApi.IsWindow(args.WindowHandle))
            {
                var windowTitle = WinApi.GetWindowText(args.WindowHandle);
                message = $"{message} [{windowTitle}]";
            }

            var notificationViewModelInfo = new NotificationViewModelInfo
            {
                Title = CommonResourceManager.Instance.GetResourceString("Common_Warning"),
                Notification = message,
                Buttons = MessageBoxButtons.OK
            };

            var notificationRequestInfo = new NotificationPopupRequestInfo(notificationViewModelInfo);
            NotificationRequest.Raise(notificationRequestInfo);
        }
    }
}