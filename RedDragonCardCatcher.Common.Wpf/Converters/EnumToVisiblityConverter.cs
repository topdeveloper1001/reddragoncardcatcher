﻿//-----------------------------------------------------------------------
// <copyright file="EnumToVisibilityConverter.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RedDragonCardCatcher.Common.Wpf.Converters
{
    /// <summary>
    /// EnumToVisibilityConverter
    /// </summary>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class EnumToVisibilityConverter : MarkupExtensionConverterBase
    {
        public EnumToVisibilityConverter()
        {
            HiddenVisibility = Visibility.Hidden;
        }

        public Visibility HiddenVisibility { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return HiddenVisibility;
            }

            if (value.GetType() == parameter.GetType())
            {
                return value.Equals(parameter) ? Visibility.Visible : HiddenVisibility;
            }

            var strParameter = parameter.ToString().Trim();

            if (string.IsNullOrEmpty(strParameter))
            {
                return HiddenVisibility;
            }

            try
            {
                return Enum.Parse(value.GetType(), strParameter).Equals(value) ? Visibility.Visible : HiddenVisibility;
            }
            catch
            {
            }

            return HiddenVisibility;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class EnumToVisibilityConverterCollapsedByDef : EnumToVisibilityConverter
    {
        public EnumToVisibilityConverterCollapsedByDef()
            : base()
        {
            HiddenVisibility = Visibility.Collapsed;
        }
    }
}