//-----------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="Ace Poker Solutions">
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
using Microsoft.Practices.Unity;
using Prism.Unity;
using RedDragonCardCatcher.Common.Log;
using RedDragonCardCatcher.Common.Wpf.Actions;
using RedDragonCardCatcher.Common.Wpf.Interactivity;
using RedDragonCardCatcher.DbInstallers;
using RedDragonCardCatcher.Entities;
using RedDragonCardCatcher.Importers;
using RedDragonCardCatcher.Licensing;
using RedDragonCardCatcher.Security;
using RedDragonCardCatcher.Services;
using RedDragonCardCatcher.Settings;
using RedDragonCardCatcher.ViewModels;
using RedDragonCardCatcher.Views;
using System;
using System.Windows;

namespace RedDragonCardCatcher
{
    internal class Bootstrapper : UnityBootstrapper
    {
        private MainWindowViewModel mainWindowViewModel;

        private bool isLicenseValid;

        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog.AddModule(null);
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<ISettingsService, SettingsService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ILicenseService, LicenseService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IWindowController, WindowController>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IImporterService, ImporterService>(new ContainerControlledLifetimeManager());

            Container.RegisterType<ILogCollector, LogCollector>();
            Container.RegisterType<IHandHistoryFileService, HandHistoryFileService>();
      
            Container.RegisterType<IEmulatorService, EmulatorService>();
            Container.RegisterType<IPipeServerJob, PipeServerJob>();
            Container.RegisterType<IDataManager, DataManager>();
            Container.RegisterType<IRDImporter, RDImporter>();
            Container.RegisterType<IRDHandBuilder, RDHandBuilder>();

            Container.RegisterType<IPT4Configurator, PT4Configurator>();

            Container.RegisterType<IDatabaseService, DHService>(DatabaseType.DH.ToString());
            Container.RegisterType<IDatabaseService, HM2Service>(DatabaseType.HM2.ToString());
            Container.RegisterType<IDatabaseService, HM2Service>(DatabaseType.HM3.ToString());
            Container.RegisterType<IDatabaseService, PT4Service>(DatabaseType.PT4.ToString());

            Container.RegisterType<IDbInstaller, Hm2DbInstaller>(DatabaseType.HM2.ToString());
            Container.RegisterType<IDbInstaller, PT4DbInstaller>(DatabaseType.PT4.ToString());
            Container.RegisterType<IDbInstaller, EmptyDbInstaller>(DatabaseType.DH.ToString());
            Container.RegisterType<IDbInstaller, EmptyDbInstaller>(DatabaseType.HM3.ToString());

            // licenses
            Container.RegisterType<ILicenseManager, RDTReg>(LicenseType.Trial.ToString());
            Container.RegisterType<ILicenseManager, RDSReg>(LicenseType.Normal.ToString());

            // views
            Container.RegisterType<IViewModelContainer, SettingsView>(RegionViewNames.SettingsPopupView);
            Container.RegisterType<IViewModelContainer, RegistrationView>(RegionViewNames.RegistrationPopupView);
            Container.RegisterType<IViewModelContainer, NotificationView>(RegionViewNames.NotificationPopupView);
            Container.RegisterType<IViewModelContainer, UpdateView>(RegionViewNames.UpdatePopupView);
            Container.RegisterType<IViewModelContainer, DBSelectionView>(RegionViewNames.DBSelectionView);

            // view models
            Container.RegisterType<ISettingsViewModel, SettingsViewModel>();
            Container.RegisterType<IRegistrationViewModel, RegistrationViewModel>();
            Container.RegisterType<INotificationViewModel, NotificationViewModel>();
            Container.RegisterType<IUpdateViewModel, UpdateViewModel>();
            Container.RegisterType<IDBSelectionViewModel, DBSelectionViewModel>();

            // loggers
            Container.RegisterType<IProtectedLogger, ProtectedLogger>();
        }

        protected override void ConfigureServiceLocator()
        {
            base.ConfigureServiceLocator();
            ConfigureImporters();
        }

        protected override void InitializeShell()
        {
            var licenseService = ServiceLocator.Current.GetInstance<ILicenseService>();
            isLicenseValid = licenseService.Validate();

            try
            {
                mainWindowViewModel = new MainWindowViewModel();

                ((Window)Shell).DataContext = mainWindowViewModel;
                ((Window)Shell).Topmost = true;
                ((Window)Shell).Show();
                ((Window)Shell).Topmost = false;

                if (App.IsUpdateAvailable)
                {
                    mainWindowViewModel.ShowUpdateView();
                }

                if (!isLicenseValid || licenseService.IsTrial ||
                    (licenseService.IsRegistered && licenseService.IsExpiringSoon) ||
                    !licenseService.IsRegistered)
                {
                    var registrationPopupRequestInfo = new RegistrationPopupRequestInfo(false);
                    mainWindowViewModel.RegistrationNotificationRequest.Raise(registrationPopupRequestInfo);

                    mainWindowViewModel.RefreshLicenseText();
                }

                if (!licenseService.IsRegistered)
                {
                    Application.Current.Shutdown();
                }

                mainWindowViewModel.IsTrial = licenseService.IsTrial;
                mainWindowViewModel.IsUpgradable = licenseService.IsUpgradable;

                mainWindowViewModel.CheckAndShowDBSelection();
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, "Could not launch main window.", e);
            }
        }     

        private void ConfigureImporters()
        {
            var importerService = ServiceLocator.Current.GetInstance<IImporterService>();
            importerService.Register<IEmulatorService>();
            importerService.Register<IRDImporter>();
        }
    }
}