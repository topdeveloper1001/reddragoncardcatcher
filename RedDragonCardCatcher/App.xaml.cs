//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Ace Poker Solutions">
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
using RedDragonCardCatcher.Common.Linq;
using RedDragonCardCatcher.Common.Log;
using RedDragonCardCatcher.Common.Resources;
using RedDragonCardCatcher.Common.Security;
using RedDragonCardCatcher.Importers;
using RedDragonCardCatcher.Services;
using RedDragonCardCatcher.Settings;
using RedDragonCardCatcher.Updater.Core;
using RedDragonCardCatcher.ViewModels;
using RedDragonCardCatcher.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace RedDragonCardCatcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, ISingleInstanceApp
    {
        public static Version Version
        {
            get;
            private set;
        }

        #region ISingleInstanceApp Members

        public bool SignalExternalCommandLineArgs(IList<string> args)
        {
            if (MainWindow == null)
            {
                return false;
            }

            if (MainWindow.WindowState == WindowState.Minimized)
            {
                MainWindow.WindowState = WindowState.Normal;
            }
            else
            {
                MainWindow.Activate();
            }

            return true;
        }

        #endregion

        protected override void OnStartup(StartupEventArgs e)
        {
            InitializeApplication();

            base.OnStartup(e);

            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }

        private void InitializeApplication()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;

            Version = Assembly.GetExecutingAssembly().GetName().Version;

            LogProvider.Log.Info(string.Format("--------------- Red Dragon Card Catcher (v.{0}) ---------------", Version));
            LogProvider.Log.Info(string.Format("OsVersion: {0}", Environment.OSVersion));
            LogProvider.Log.Info(string.Format("Current Culture: {0}", Thread.CurrentThread.CurrentCulture));
            LogProvider.Log.Info(string.Format("Current UI Culture: {0}", Thread.CurrentThread.CurrentUICulture));

            //var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            //names.ForEach(x => Debug.WriteLine(x));

            ValidateLicenseAssemblies();

            ResourceRegistrator.Initialization();

            if (IsCheckForUpdates())
            {
                CheckUpdates();
            }

            LogCleaner.ClearLogsFolder();

            /* Without this user won't be able to input decimal point for float bindings if UpdateSourceTrigger set to PropertyChanged */
            FrameworkCompatibilityPreferences.KeepTextBoxDisplaySynchronizedWithTextProperty = false;
        }

        private void ValidateLicenseAssemblies()
        {
            var assemblies = new string[] { "DeployLX.Licensing.v5.dll", "RDTReg.dll", "RDSReg.dll" };
            var assembliesHashes = new string[] { "c1d67b8e8d38540630872e9d4e44450ce2944700", "b970e8974cd268bf9f0b4a4629c1c14b08b0c7c6", "cb0fc34892465d017f9222b4b7a007c3d1d2d5b5" };
            var assemblySizes = new int[] { 1032192, 8192, 8704 };

            for (var i = 0; i < assemblies.Length; i++)
            {
                var assemblyInfo = new FileInfo(assemblies[i]);

                var isValid = SecurityUtils.ValidateFileHash(assemblyInfo.FullName, assembliesHashes[i]) && assemblyInfo.Length == assemblySizes[i];

                if (!isValid)
                {
                    LogProvider.Log.Error("Application could not be initialized");
                    Current.Shutdown();
                    return;
                }
            }
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            LogProvider.Log.Error("Fatal error", e.Exception);
            HandleException(e.Exception);

            e.Handled = true;

            Current.Shutdown();
        }

        private void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            HandleException(ex);
            Current.Shutdown();
        }

        private void HandleException(Exception ex)
        {
            var errorMessage = ex != null ? ex.ToString() : "Unexpected error occurred. Please contact support.";
            ErrorBox.Show(CommonResourceManager.Instance.GetResourceString("Common_FatalError"), errorMessage, System.Windows.Forms.MessageBoxButtons.OK);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            var importService = ServiceLocator.Current.GetInstance<IImporterService>();

            if (importService != null && importService.IsStarted)
            {
                importService.StopImport();
            }

            LogProvider.Log.Info("Red Dragon Card Catcher exited.");
        }

        #region Updating        

        internal static bool IsUpdateAvailable { get; set; }

        internal static ApplicationInfo UpdateApplicationInfo { get; set; }

        private bool IsCheckForUpdates()
        {
            return new SettingsService().GetSettings().AutomaticUpdatingEnabled;
        }

        private async void CheckUpdates()
        {
            try
            {
                var httpApplicationInfoLoader = new HttpApplicationInfoLoader();

                using (var appUpdater = new AppUpdater(httpApplicationInfoLoader))
                {
                    await appUpdater.InitializeAsync();

                    var appInfo = appUpdater.CheckIsUpdateAvailable(ProgramInfo.AssemblyGuid, Assembly.GetExecutingAssembly().Location, out bool isUpdateAvailable);

                    IsUpdateAvailable = isUpdateAvailable;

                    if (IsUpdateAvailable)
                    {
                        UpdateApplicationInfo = appInfo;

                        var mainWindowViewModel = Current.MainWindow?.DataContext as MainWindowViewModel;

                        mainWindowViewModel?.ShowUpdateView();
                    }
                }
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, "Updates couldn't be checked.", e);
            }
        }

        #endregion
    }
}
