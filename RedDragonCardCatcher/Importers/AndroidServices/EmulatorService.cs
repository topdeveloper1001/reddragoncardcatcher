//-----------------------------------------------------------------------
// <copyright file="EmulatorService.cs" company="Ace Poker Solutions">
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
using RedDragonCardCatcher.Common.Extensions;
using RedDragonCardCatcher.Common.Linq;
using RedDragonCardCatcher.Common.Log;
using RedDragonCardCatcher.Common.Utils.Network;
using RedDragonCardCatcher.Common.WinApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RedDragonCardCatcher.Importers
{
    internal class EmulatorService : BaseImporter, IEmulatorService
    {
        private static readonly IEmulatorProvider[] emulatorProviders = new[]
        {
            new MomoEmulatorProvider()
        };

        private const int ExitTimeout = 7000;

        /// <summary>
        /// Path to libraries
        /// </summary>
        private const string LibPath = "Lib";

        /// <summary>
        /// Name of dll for injection into emulator
        /// </summary>
        private const string DllToInject = "HereBeDragons.dll";

        /// <summary>
        /// Path to the temp folder on emulator
        /// </summary>
        private const string EmulatorTempDataFolder = "/data/local/tmp";

        /// <summary>
        /// The name of poker process
        /// </summary>
        private const string PokerProcessName = "com.hipoker.psPoker";

        /// <summary>
        /// Timeout 
        /// </summary>
        private const int EjectDllTimeout = 2000;

        /// <summary>
        /// Interval between main job runs 
        /// </summary>
        private const int MainJobInterval = 5000;

        public override string ImporterName => "Emulators Service";

        protected readonly Dictionary<int, EmulatorInfo> activeEmulators = new Dictionary<int, EmulatorInfo>();

        protected override void DoImport()
        {
            try
            {
                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    UpdateEmulators();
                    IdentifyEmulators();
                    PatchEmulators();
                    HookPokerClients();
                    InjectDllIntoEmulators();

                    try
                    {
                        Task.Delay(MainJobInterval).Wait(cancellationTokenSource.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, "Failed to execute emulator service job.", e);
            }

            activeEmulators.Values.ForEach(emulator =>
            {
                emulator.PipeJob?.Close();
                EjectDll(emulator);
            });

            activeEmulators.Clear();

            RaiseProcessStopped();
        }

        /// <summary>
        /// Finds active emulators and updates internal dictionary
        /// </summary>
        protected void UpdateEmulators()
        {
            RemoveInactiveEmulators();

            foreach (var process in Process.GetProcesses())
            {
                if (activeEmulators.ContainsKey(process.Id))
                {
                    continue;
                }

                foreach (var emulatorProvider in emulatorProviders)
                {
                    if (!emulatorProvider.CanProvide(process))
                    {
                        continue;
                    }

                    var emulatorWindowHandle = emulatorProvider.GetProcessWindowHandle(process, out Process emulatorProcess);

                    if (emulatorWindowHandle != IntPtr.Zero && emulatorProcess != null)
                    {
                        var emulatorInfo = new EmulatorInfo
                        {
                            Process = process,
                            EmulatorProcess = emulatorProcess,
                            WindowHandle = emulatorWindowHandle,
                            Provider = emulatorProvider
                        };

                        activeEmulators.Add(process.Id, emulatorInfo);

                        LogProvider.Log.Info(this, $"Added the instance of '{emulatorProvider.EmulatorName}' emulator with pid {process.Id} and main window {emulatorWindowHandle} to tracker.");
                    }
                }
            }
        }

        /// <summary>
        /// Checks the dictionary of emulators and removes inactive
        /// </summary>
        protected void RemoveInactiveEmulators()
        {
            foreach (var activeEmulator in activeEmulators.ToArray())
            {
                try
                {
                    if (!activeEmulator.Value.Process.HasExited)
                    {
                        continue;
                    }

                    activeEmulators.Remove(activeEmulator.Key);

                    // remove pipe associated with that emulator
                    activeEmulator.Value.PipeJob?.Close();

                    LogProvider.Log.Info(this, $"The instance of '{activeEmulator.Value.Provider.EmulatorName}' emulator with pid {activeEmulator.Key} has exited and was removed from tracker.");
                }
                catch (Exception e)
                {
                    LogProvider.Log.Error(this, $"Failed to remove the instance of '{activeEmulator.Value.Provider.EmulatorName}' emulator.", e);
                }
            }
        }

        /// <summary>
        /// Injects dll into emulators
        /// </summary>
        protected void InjectDllIntoEmulators()
        {
            activeEmulators.Values
                   .Where(x => !x.IsInjected)
                   .ForEach(emulatorInfo =>
                   {
                       try
                       {
                           var pipeJob = ServiceLocator.Current.GetInstance<IPipeServerJob>();
                           pipeJob.Initialize(emulatorInfo);

                           if (pipeJob.IsInitialized)
                           {
                               emulatorInfo.PipeJob = pipeJob;
                               InjectDll(emulatorInfo);
                           }
                       }
                       catch (Exception e)
                       {
                           LogProvider.Log.Error(this, $"Failed to inject into the instance of '{emulatorInfo.Provider.EmulatorName}' emulator with pid '{emulatorInfo.Process.Id}'", e);
                       }
                   });
        }

        /// <summary>
        /// Identify emulators
        /// </summary>
        protected void IdentifyEmulators()
        {
            // get adb 
            var emulatorsByAdb = activeEmulators.Values
                .Where(x => string.IsNullOrEmpty(x.AdbIdentifier))
                .GroupBy(x => x.GetAdbPath())
                .Where(x => !string.IsNullOrEmpty(x.Key))
                .ToDictionary(x => x.Key, x => x.ToArray());

            if (emulatorsByAdb.Count == 0)
            {
                // all emulators are identified
                return;
            }

            // run adb devices (count if not match re-run with kill command)
            var deviceInfos = new List<DeviceInfo>();

            foreach (var emulatorAdb in emulatorsByAdb.Keys)
            {
                var devices = GetAdbDevices(emulatorAdb);

                if (devices.Length != emulatorsByAdb[emulatorAdb].Length)
                {
                    LogProvider.Log.Warn(this, $"Expected number of devices {emulatorsByAdb[emulatorAdb].Length} doesn't match actual number {devices.Length}. Trying to kill server and run command again with {emulatorAdb}.");
                    AdbKillServer(emulatorAdb);
                    Task.Delay(MainJobInterval).Wait();

                    var repeatDevices = GetAdbDevices(emulatorAdb);

                    if (repeatDevices.Length != emulatorsByAdb[emulatorAdb].Length)
                    {
                        LogProvider.Log.Warn(this, $"Expected number of devices {emulatorsByAdb[emulatorAdb].Length} still doesn't match actual number {devices.Length}.");
                        devices = devices.Concat(repeatDevices).Distinct().ToArray();
                    }
                    else
                    {
                        devices = repeatDevices;
                    }
                }

                devices.ForEach(device =>
                {
                    if (TryParsePort(device, out int port))
                    {
                        deviceInfos.Add(new DeviceInfo
                        {
                            AdbIdentifier = device,
                            Port = port
                        });
                    }
                });
            }

            // get all tcp connection                  
            var processAdbIdentifiers = (from tcpConnection in NetworkUtils.GetAllTcpConnections().Where(x => x.LocalAddress.Address.Equals(IPAddress.Loopback))
                                         join deviceInfo in deviceInfos on tcpConnection.LocalAddress.Port equals deviceInfo.Port
                                         group deviceInfo by tcpConnection.ProcessId into deviceInfosByProcessId
                                         select new { ProcessId = deviceInfosByProcessId.Key, deviceInfosByProcessId.First().AdbIdentifier }).ToArray();

            var emulatorsToUpdate = (from emulator in activeEmulators.Values.Where(x => string.IsNullOrEmpty(x.AdbIdentifier))
                                     join processAdbIdentifier in processAdbIdentifiers on emulator.Process.Id equals (int)processAdbIdentifier.ProcessId
                                     select new { EmulatorInfo = emulator, processAdbIdentifier.AdbIdentifier }).ToArray();

            emulatorsToUpdate.ForEach(emulator =>
            {
                LogProvider.Log.Info(this, $"Set {emulator.AdbIdentifier} identifier for instance of '{emulator.EmulatorInfo.Provider.EmulatorName}' emulator with pid {emulator.EmulatorInfo.Process.Id}");
                emulator.EmulatorInfo.AdbIdentifier = emulator.AdbIdentifier;
            });
        }

        /// <summary>
        /// Patches emulators
        /// </summary>
        protected void PatchEmulators()
        {
            var injector = new FileInfo(Path.Combine(LibPath, "injector"));

            if (!injector.Exists)
            {
                throw new FileNotFoundException("Injector file not found.", injector.FullName);
            }

            var hook = new FileInfo(Path.Combine(LibPath, "libhookimpl.so"));

            if (!hook.Exists)
            {
                throw new FileNotFoundException("Hook file not found.", hook.FullName);
            }

            foreach (var emulator in activeEmulators.Values.Where(x => x.IsIdentified && !x.IsPatched))
            {
                LogProvider.Log.Info(this, $"Patching the instance of '{emulator.Provider.EmulatorName}' emulator with pid {emulator.Process.Id}.");

                if (!PushFileToEmulator(emulator, injector, EmulatorTempDataFolder) ||
                    !PushFileToEmulator(emulator, hook, EmulatorTempDataFolder) ||
                    !SetExecutableRightsToFile(emulator, $"{EmulatorTempDataFolder}/injector"))
                {
                    continue;
                }

                emulator.IsPatched = true;

                LogProvider.Log.Info(this, $"Patched succefully the instance of '{emulator.Provider.EmulatorName}' emulator with pid {emulator.Process.Id}.");
            }
        }

        protected void HookPokerClients()
        {
            foreach (var emulator in activeEmulators.Values.Where(x => x.IsPatched))
            {
                var pidofResult = ExecuteAdbCommand(emulator,
                    "shell",
                    $"\"pidof {PokerProcessName}\"");

                if (string.IsNullOrEmpty(pidofResult) ||
                    !int.TryParse(pidofResult, out int pokerProcessId))
                {
                    if (emulator.PokerProcessId != 0)
                    {
                        LogProvider.Log.Info(this, $"Poker client pid {emulator.PokerProcessId} was stopped on the instance of '{emulator.Provider.EmulatorName}' emulator with pid {emulator.Process.Id}.");
                    }

                    emulator.PokerProcessId = 0;
                    emulator.IsHooked = false;
                    continue;
                }

                if (emulator.IsHooked && emulator.PokerProcessId == pokerProcessId)
                {
                    // process is hooked
                    continue;
                }

                emulator.PokerProcessId = pokerProcessId;

                var hookResult = ExecuteAdbCommand(emulator,
                    "shell",
                    $"\"{EmulatorTempDataFolder}/injector $(pidof {PokerProcessName}) {EmulatorTempDataFolder}/libhookimpl.so\"");

                if (!string.IsNullOrEmpty(hookResult) && hookResult.ContainsIgnoreCase("success"))
                {
                    emulator.IsHooked = true;
                    LogProvider.Log.Info(this, $"Hooked the client succefully on the instance of '{emulator.Provider.EmulatorName}' emulator with pid {emulator.Process.Id}.");
                    continue;
                }

                LogProvider.Log.Info(this, $"Failed to hook the client with result '{hookResult}' on the instance of '{emulator.Provider.EmulatorName}' emulator with pid {emulator.Process.Id}.");
            }
        }

        private bool PushFileToEmulator(EmulatorInfo emulator, FileInfo source, string destination)
        {
            var pushResult = ExecuteAdbCommand(emulator,
                "push",
                source.FullName,
                destination);

            if (string.IsNullOrEmpty(pushResult) ||
                !pushResult.ContainsIgnoreCase(source.Length.ToString()))
            {
                LogProvider.Log.Error(this, $"Failed to push file '{source.FullName}' to '{destination}' on the instance of '{emulator.Provider.EmulatorName}' emulator with pid {emulator.Process.Id}.");
                return false;
            }

            return true;
        }

        private bool SetExecutableRightsToFile(EmulatorInfo emulator, string file)
        {
            ExecuteAdbCommand(emulator,
                   "shell",
                   $"\"chmod 755 {file}\"");

            var checkChmodResult = ExecuteAdbCommand(emulator,
                "shell",
                $"\"ls -l {file}\"");

            if (string.IsNullOrEmpty(checkChmodResult) ||
                !checkChmodResult.ContainsIgnoreCase("rwxr-xr-x"))
            {
                LogProvider.Log.Error(this, $"Failed to set chmod for file '{file}' on the instance of '{emulator.Provider.EmulatorName}' emulator with pid {emulator.Process.Id}.");
                return false;
            }

            return true;
        }

        #region DLL Injection        

        /// <summary>
        /// Inject DLL in the specified process
        /// </summary>
        private void InjectDll(EmulatorInfo emulatorInfo)
        {
            LogProvider.Log.Info(this, $"Injecting into the instance of '{emulatorInfo.Provider.EmulatorName}' emulator with pid '{emulatorInfo.Process.Id}'");

            // Enter in debug mode to be able to manipulate with processes
            Process.EnterDebugMode();

            // Required access to client process
            var requiredAccess = ProcessAccessFlags.QueryInformation | ProcessAccessFlags.CreateThread | ProcessAccessFlags.VMOperation |
                                    ProcessAccessFlags.VMWrite | ProcessAccessFlags.VMRead;

            // Open client process and get its handle
            emulatorInfo.ProcessHandle = WinApi.OpenProcess(requiredAccess, false, emulatorInfo.Process.Id);

            if (emulatorInfo.ProcessHandle == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            var dllPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), LibPath, DllToInject);

            if (!File.Exists(dllPath))
            {
                throw new FileNotFoundException(string.Format("Dll {0} is missing", dllPath));
            }

            var injectedDllProcessAddress = GetInjectedDllProcessAddress(emulatorInfo.Process);

            // Eject dll from client process
            if (injectedDllProcessAddress != IntPtr.Zero)
            {
                LogProvider.Log.Info(this, $"Found already injected dll in the instance of '{emulatorInfo.Provider.EmulatorName}' emulator with pid '{emulatorInfo.Process.Id}'. Dll will be ejected.");

                EjectDll(emulatorInfo, injectedDllProcessAddress);
                Task.Delay(EjectDllTimeout).Wait();
            }

            // pointer to allocated memory of lib path string
            IntPtr pLibRemote = IntPtr.Zero;

            // handle to thread from CreateRemoteThread
            IntPtr hThread = IntPtr.Zero;

            // unmanaged C-String pointer
            IntPtr pLibFullPathUnmanaged = Marshal.StringToHGlobalUni(dllPath);

            try
            {
                uint sizeUni = (uint)Encoding.Unicode.GetByteCount(dllPath);

                // Get Handle to Kernel32.dll and pointer to LoadLibraryW
                IntPtr hKernel32 = WinApi.GetModuleHandle("Kernel32");

                if (hKernel32 == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Kernel32 not found");
                }

                IntPtr hLoadLib = WinApi.GetProcAddress(hKernel32, "LoadLibraryW");

                if (hLoadLib == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "FreeLibrary not found");
                }

                // allocate memory to the local process for libFullPath
                pLibRemote = WinApi.VirtualAllocEx(emulatorInfo.ProcessHandle, IntPtr.Zero, sizeUni, AllocationType.Commit, MemoryProtection.ReadWrite);

                if (pLibRemote == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Memory hasn't been allocated");
                }

                // write libFullPath to pLibPath
                if (!WinApi.WriteProcessMemory(emulatorInfo.ProcessHandle, pLibRemote, pLibFullPathUnmanaged, sizeUni, out int bytesWritten) || bytesWritten != (int)sizeUni)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Couldn't write data in process memory");
                }

                // load dll via call to LoadLibrary using CreateRemoteThread
                hThread = WinApi.CreateRemoteThread(emulatorInfo.ProcessHandle, IntPtr.Zero, 0, hLoadLib, pLibRemote, 0, IntPtr.Zero);

                if (hThread == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Couldn't create remote thread");
                }

                if (WinApi.WaitForSingleObject(hThread, (uint)ThreadWaitValue.Infinite) != (uint)ThreadWaitValue.Object0)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "WaitForSingleObject return wrong code");
                }

                // get address of loaded module - this doesn't work in x64, so just iterate module list to find injected module
                if (!WinApi.GetExitCodeThread(hThread, out IntPtr hLibModule))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Couldn't obtain exit code");
                }

                if (hLibModule == IntPtr.Zero)
                {
                    throw new Exception("Code executed properly, but unable to get an appropriate module handle, possible Win32Exception", new Win32Exception(Marshal.GetLastWin32Error()));
                }

                emulatorInfo.Process.Refresh();

                // iterate modules in target process to find our newly injected module                
                foreach (ProcessModule module in emulatorInfo.Process.Modules)
                {
                    if (module.ModuleName == DllToInject)
                    {
                        emulatorInfo.InjectedProcessModule = module;
                        break;
                    }
                }

                if (emulatorInfo.InjectedProcessModule == null)
                {
                    throw new Exception("Injected module could not be found within the target process!");
                }

                LogProvider.Log.Info(this, $"Successfully injected in the instance of '{emulatorInfo.Provider.EmulatorName}' emulator with pid '{emulatorInfo.Process.Id}'");
            }
            finally
            {
                Marshal.FreeHGlobal(pLibFullPathUnmanaged);
                WinApi.CloseHandle(hThread);
                WinApi.VirtualFreeEx(emulatorInfo.Process.Handle, pLibRemote, 0, AllocationType.Release);
            }
        }

        private void EjectDll(EmulatorInfo emulatorInfo)
        {
            try
            {
                if (emulatorInfo.Process != null && !emulatorInfo.Process.HasExited)
                {
                    if (emulatorInfo.InjectedProcessModule != null)
                    {
                        try
                        {
                            EjectDll(emulatorInfo, emulatorInfo.InjectedProcessModule.BaseAddress);
                        }
                        catch (Exception e)
                        {
                            LogProvider.Log.Error(this, $"Ejecting from the instance of '{emulatorInfo.Provider.EmulatorName}' emulator with pid '{emulatorInfo.Process.Id}' failed.", e);
                        }
                    }

                    emulatorInfo.ProcessHandle = IntPtr.Zero;
                }
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Could not eject dll from the instance of '{emulatorInfo.Provider.EmulatorName}' emulator with pid '{emulatorInfo.Process.Id}'", e);
            }
        }

        private void EjectDll(EmulatorInfo emulatorInfo, IntPtr injectedProcessAddress)
        {
            LogProvider.Log.Info(this, $"Ejecting from the instance of '{emulatorInfo.Provider.EmulatorName}' emulator with pid '{emulatorInfo.Process.Id}'");

            IntPtr hThread = IntPtr.Zero;

            try
            {
                // get handle to kernel32 and FreeLibrary
                IntPtr hKernel32 = WinApi.GetModuleHandle("Kernel32");

                if (hKernel32 == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Kernel32 not found");
                }

                IntPtr hFreeLib = WinApi.GetProcAddress(hKernel32, "FreeLibrary");

                if (hFreeLib == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "FreeLibrary not found");
                }

                hThread = WinApi.CreateRemoteThread(emulatorInfo.ProcessHandle, IntPtr.Zero, 0, hFreeLib, injectedProcessAddress, 0, IntPtr.Zero);

                if (hThread == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Couldn't create remote thread");
                }

                if (WinApi.WaitForSingleObject(hThread, (uint)ThreadWaitValue.Infinite) != (uint)ThreadWaitValue.Object0)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "WaitForSingleObject return wrong code");
                }

                if (!WinApi.GetExitCodeThread(hThread, out IntPtr pFreeLibRet))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Couldn't obtain exit code");
                }

                if (pFreeLibRet == IntPtr.Zero)
                {
                    throw new Exception("FreeLibrary failed in remote process");
                }

                LogProvider.Log.Info(this, $"Successfully ejected from the instance of '{emulatorInfo.Provider.EmulatorName}' emulator with pid '{emulatorInfo.Process.Id}'.");
            }
            finally
            {
                WinApi.CloseHandle(hThread);
                emulatorInfo.InjectedProcessModule = null;
            }
        }

        private IntPtr GetInjectedDllProcessAddress(Process process)
        {
            process.Refresh();

            foreach (ProcessModule module in process.Modules)
            {
                if (module.ModuleName.Equals(DllToInject))
                {
                    return module.BaseAddress;
                }
            }

            return IntPtr.Zero;
        }

        #endregion

        #region Adb methods

        private string[] GetAdbDevices(string adb)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = adb,
                    Arguments = "devices",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                using (var process = new Process())
                {
                    var devices = new List<string>();
                    var outputLines = new List<string>();

                    process.StartInfo = processInfo;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;

                    process.OutputDataReceived += (s, a) =>
                    {
                        if (!string.IsNullOrEmpty(a.Data))
                        {
                            outputLines.Add(a.Data);
                        }
                    };

                    process.ErrorDataReceived += (s, a) =>
                    {
                        if (!string.IsNullOrEmpty(a.Data))
                        {
                            outputLines.Add(a.Data);
                        }
                    };

                    process.Start();

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    process.WaitForExit(ExitTimeout);

                    if (outputLines.Count == 0)
                    {
                        return new string[0];
                    }

                    foreach (var line in outputLines.Where(x => !x.StartsWith("*", StringComparison.OrdinalIgnoreCase)).Skip(1))
                    {
                        if (line.ContainsIgnoreCase("offline"))
                        {
                            continue;
                        }

                        var endIndex = line.IndexOf("\t");

                        if (endIndex >= 0)
                        {
                            var device = line.Substring(0, endIndex);
                            devices.Add(device);
                        }
                    }

                    return devices.ToArray();
                }
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to read the list of devices with {adb}.", e);
            }

            return new string[0];
        }

        private void AdbKillServer(string adb)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = adb,
                    Arguments = "kill-server",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                using (var process = new Process())
                {
                    process.StartInfo = processInfo;
                    process.Start();

                    process.WaitForExit(ExitTimeout);
                }
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to execute kill server command with {adb}.", e);
            }
        }

        private bool TryParsePort(string adbDevice, out int port)
        {
            port = 0;

            if (string.IsNullOrEmpty(adbDevice))
            {
                return false;
            }

            bool InternalTryParsePort(string prePortSymbol, out int internalPort)
            {
                internalPort = 0;

                var prePortSymbolIndex = adbDevice.LastIndexOf(prePortSymbol);

                if (prePortSymbolIndex > 0 && prePortSymbolIndex != adbDevice.Length - 1)
                {
                    var portText = adbDevice.Substring(prePortSymbolIndex + 1);
                    var result = int.TryParse(portText, out internalPort);

                    if (internalPort % 2 == 0)
                    {
                        internalPort++;
                    }

                    return result;
                }

                return false;
            }

            return InternalTryParsePort(":", out port) ||
                InternalTryParsePort("-", out port);
        }

        /// <summary>
        /// Executes adb command with specified args on the specified emulator
        /// </summary>
        /// <param name="emulator">Emulator where adb command is executed</param>
        /// <param name="args">Adb command arguments</param>
        /// <returns>Ouput of adb command if it's run succesfully; othewise - null</returns>
        private string ExecuteAdbCommand(EmulatorInfo emulator, params string[] args)
        {
            string result = null;

            var processInfo = new ProcessStartInfo
            {
                FileName = emulator.GetAdbPath(),
                Arguments = $"-s {emulator.AdbIdentifier} {string.Join(" ", args)}",
                CreateNoWindow = true,
                UseShellExecute = false
            };

            if (string.IsNullOrEmpty(emulator.AdbIdentifier))
            {
                LogProvider.Log.Error(this, $"Command '{processInfo.FileName} {processInfo.Arguments}' can't be executed on the instance of '{emulator.Provider.EmulatorName}' emulator with pid {emulator.Process.Id} because identifier is unknown.");
                return result;
            }

            try
            {
                using (var adbProcess = new Process())
                {
                    var resultBuilder = new StringBuilder();

                    adbProcess.StartInfo = processInfo;
                    adbProcess.StartInfo.RedirectStandardOutput = true;
                    adbProcess.StartInfo.RedirectStandardError = true;
                    adbProcess.OutputDataReceived += (s, a) =>
                    {
                        if (!string.IsNullOrEmpty(a.Data))
                            resultBuilder.AppendLine(a.Data);
                    };

                    adbProcess.ErrorDataReceived += (s, a) =>
                    {
                        if (!string.IsNullOrEmpty(a.Data))
                            resultBuilder.AppendLine(a.Data);
                    };

                    adbProcess.Start();

                    adbProcess.BeginOutputReadLine();
                    adbProcess.BeginErrorReadLine();

                    adbProcess.WaitForExit(ExitTimeout);

                    var output = resultBuilder.ToString();

                    if (string.IsNullOrEmpty(output) || !output.StartsWith("error:", StringComparison.OrdinalIgnoreCase) &&
                        !output.StartsWith("*", StringComparison.OrdinalIgnoreCase))
                    {
                        result = output;
                    }
                    else
                    {
                        LogProvider.Log.Error(this, $"Command '{processInfo.FileName} {processInfo.Arguments}' returned an error '{output}' on the instance of '{emulator.Provider.EmulatorName}' emulator with pid {emulator.Process.Id}.");
                    }
                }
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to run command '{processInfo.FileName} {processInfo.Arguments}' on the instance of '{emulator.Provider.EmulatorName}' emulator with pid {emulator.Process.Id}.", e);
            }

            return result;
        }

        private class DeviceInfo
        {
            public int Port { get; set; }

            public string AdbIdentifier { get; set; }
        }

        #endregion
    }
}