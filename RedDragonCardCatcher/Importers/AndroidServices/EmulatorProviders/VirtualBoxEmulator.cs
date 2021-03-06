﻿//-----------------------------------------------------------------------
// <copyright file="VirtualBoxEmulator.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.Common.Extensions;
using RedDragonCardCatcher.Common.Log;
using System;
using System.Diagnostics;
using System.Linq;

namespace RedDragonCardCatcher.Importers
{
    internal abstract class VirtualBoxEmulator : IEmulatorProvider
    {
        public abstract string EmulatorName { get; }

        protected abstract string ProcessName { get; }

        protected abstract string VbProcessName { get; }

        protected abstract string InstanceArgumentPrefix { get; }

        protected abstract string VbInstanceArgumentPrefix { get; }

        protected virtual int? VbEmptyInstanceNumber { get { return 0; } }

        protected virtual int? EmptyInstanceNumber { get { return null; } }

        public bool CanProvide(Process process)
        {
            try
            {
                var result = process != null && process.ProcessName.StartsWith(VbProcessName, StringComparison.OrdinalIgnoreCase);                
                return result;
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to check if process is associated with {EmulatorName} emulator {process.Id}", e);
                return false;
            }
        }

        public IntPtr GetProcessWindowHandle(Process process, out Process emulatorProcess)
        {
            emulatorProcess = null;

            try
            {
                if (process == null || process.HasExited)
                {
                    return IntPtr.Zero;
                }

                var cmd = process.GetCommandLine();

                var instanceNumber = GetInstanceNumber(cmd, VbInstanceArgumentPrefix, null);

                LogProvider.Log.Info(this, $"Check command line of '{process?.ProcessName}': '{cmd}'. Instance: {instanceNumber} [{EmulatorName}]");

                emulatorProcess = Process.GetProcesses().
                    FirstOrDefault(x =>
                    {
                        if (!x.ProcessName.Equals(ProcessName, StringComparison.OrdinalIgnoreCase) || x.Id == process.Id)
                        {
                            return false;
                        }

                        var cmdLine = x.GetCommandLine();

                        var currentInstanceNumber = GetInstanceNumber(cmdLine, InstanceArgumentPrefix, EmptyInstanceNumber);

                        return instanceNumber.HasValue ?
                            currentInstanceNumber == instanceNumber :
                            (!currentInstanceNumber.HasValue ||
                                (currentInstanceNumber.HasValue && VbEmptyInstanceNumber == currentInstanceNumber));
                    });

                if (emulatorProcess != null)
                {
                    LogProvider.Log.Info(this, $"Found emulator process '{emulatorProcess.ProcessName}'. MainWindow={emulatorProcess.MainWindowHandle} [{EmulatorName}]");

                    if (emulatorProcess.MainWindowHandle == IntPtr.Zero)
                    {
                        emulatorProcess.Refresh();
                    }

                    return emulatorProcess.MainWindowHandle;
                }
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to get window handle of {EmulatorName} emulator for process {process.Id}", e);
            }

            return IntPtr.Zero;
        }

        private int? GetInstanceNumber(string cmd, string argumentPrefix, int? emptyInstanceNumber)
        {
            int? instanceNumber = emptyInstanceNumber;

            var instanceArgumentPrefixLength = argumentPrefix.Length;
            var instanceIndex = cmd.IndexOf(argumentPrefix, StringComparison.OrdinalIgnoreCase);

            if (instanceIndex > 0)
            {
                var spaceAfterInstanceIndex = instanceIndex + instanceArgumentPrefixLength < cmd.Length ?
                    cmd.IndexOf(' ', instanceIndex + instanceArgumentPrefixLength) :
                    cmd.IndexOf(' ', instanceIndex);

                var instanceIndexText = spaceAfterInstanceIndex > 0 ?
                    cmd.Substring(instanceIndex + instanceArgumentPrefixLength, spaceAfterInstanceIndex - instanceIndex - instanceArgumentPrefixLength) :
                    cmd.Substring(instanceIndex + instanceArgumentPrefixLength);

                instanceIndexText = ExtractInstanceNumber(instanceIndexText);

                if (int.TryParse(instanceIndexText, out int parsedIntanceNumber))
                {
                    instanceNumber = parsedIntanceNumber;
                }
            }

            return instanceNumber;
        }

        protected virtual string ExtractInstanceNumber(string instanceIndexText)
        {
            return instanceIndexText;
        }

        public abstract string GetAdbLocation();

        public virtual int GetNumberOfRunningInstances()
        {
            try
            {
                return Process.GetProcesses().
                           Count(x => x.ProcessName.Equals(ProcessName, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to get number of running instances of {EmulatorName} emulator.", e);
            }

            return 0;
        }      
    }
}