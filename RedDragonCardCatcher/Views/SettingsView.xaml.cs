//-----------------------------------------------------------------------
// <copyright file="SettingsView.xaml.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.Common.Wpf.Actions;
using RedDragonCardCatcher.ViewModels;
using System;
using System.Windows.Controls;

namespace RedDragonCardCatcher.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl, IViewModelContainer<ISettingsViewModel>
    {
        public SettingsView(ISettingsViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.Initialized += ViewModel_Initialized;

            InitializeComponent();
        }

        private void ViewModel_Initialized(object sender, EventArgs e)
        {
            DataContext = ViewModel;
            ViewModel.Initialized -= ViewModel_Initialized;
        }

        public ISettingsViewModel ViewModel
        {
            get;
            private set;
        }
    }
}