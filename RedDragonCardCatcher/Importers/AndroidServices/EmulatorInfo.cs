//-----------------------------------------------------------------------
// <copyright file="EmulatorInfo.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.Common.Log;
using RedDragonCardCatcher.Common.WinApi;
using System;
using System.Diagnostics;
using System.IO;

namespace RedDragonCardCatcher.Importers
{
    internal sealed class EmulatorInfo
    {
        public Process Process { get; set; }

        public Process EmulatorProcess { get; set; }

        public IntPtr WindowHandle { get; set; }

        public IEmulatorProvider Provider { get; set; }

        public IntPtr ProcessHandle { get; set; }

        public ProcessModule InjectedProcessModule { get; set; }

        public string AdbIdentifier { get; set; }

        public int PokerProcessId { get; set; }

        public bool IsPatched { get; set; }

        public bool IsHooked { get; set; }

        public IPipeServerJob PipeJob { get; set; }

        public bool IsInjected => InjectedProcessModule != null;

        public bool IsIdentified => !string.IsNullOrEmpty(AdbIdentifier);

        public string GetAdbPath()
        {
            if (EmulatorProcess == null || Provider == null)
            {
                return null;
            }

            try
            {
                var emulatorPath = WinApi.GetMainModuleFileName(EmulatorProcess);
                return Path.Combine(Path.GetDirectoryName(emulatorPath), Provider.GetAdbLocation());
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to get path to adb for instance of '{Provider.EmulatorName}' with pid {Process.Id}.", e);
            }

            return null;
        }
    }
}