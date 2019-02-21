//-----------------------------------------------------------------------
// <copyright file="PipeJob.cs" company="Ace Poker Solutions">
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
using RedDragonCardCatcher.Common.WinApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace RedDragonCardCatcher.Importers
{
    internal sealed class PipeServerJob : IPipeServerJob
    {
        private const string PipeName = @"\\.\pipe\RedDragon";

        private const uint BufferSize = 4096;

        private const int PipeReadingTimeout = 2500;
        private CancellationTokenSource cancellationTokenSource;
        private readonly IRDImporter importer;
        private IntPtr windowHandle;

        public PipeServerJob()
        {
            cancellationTokenSource = new CancellationTokenSource();

            var importerService = ServiceLocator.Current.GetInstance<IImporterService>();
            importer = importerService.GetImporter<IRDImporter>();
        }

        public bool IsInitialized => PipeServerHandle != IntPtr.Zero;

        public IntPtr PipeServerHandle { get; private set; }

        public void Initialize(EmulatorInfo emulator)
        {
            windowHandle = emulator.WindowHandle;

            PipeServerHandle = CreatePipeServer(emulator);

            if (!IsInitialized)
            {
                return;
            }

            Task.Run(() => DoJob());
        }

        public void Close()
        {
            cancellationTokenSource?.Cancel();
        }

        private void DoJob()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    var totalBuffer = new List<byte>();

                    bool readResult = false;
                    uint numberOfBytesRead = 0;

                    do
                    {
                        // Buffer for pipe data
                        var lbBuffer = new byte[BufferSize];

                        // Read data from the pipe.
                        readResult = WinApi.ReadFile(
                            PipeServerHandle,
                            lbBuffer,
                            BufferSize,
                            out numberOfBytesRead,
                            IntPtr.Zero);

                        if (numberOfBytesRead > 0)
                        {
                            totalBuffer.AddRange(lbBuffer.Take((int)numberOfBytesRead));
                        }

                    } while (!readResult && numberOfBytesRead != 0);

                    // If client is not connected, or no data in raw
                    if (!readResult || numberOfBytesRead == 0)
                    {
                        try
                        {
                            Task.Delay(PipeReadingTimeout).Wait(cancellationTokenSource.Token);
                        }
                        catch (OperationCanceledException)
                        {
                            break;
                        }

                        continue;
                    }

                    var pipeData = new PipeData
                    {
                        WindowHandle = windowHandle,
                        Data = totalBuffer.ToArray()
                    };

                    // process pipe's data
                    importer.AddPackage(pipeData);
                }
                catch (Exception e)
                {
                    LogProvider.Log.Error(this, $"Failed to process pipe {PipeServerHandle} data.", e);
                }
            }

            ClosePipe();
        }

        /// <summary>
        /// Create pipe server to get data from catcher
        /// </summary>
        private IntPtr CreatePipeServer(EmulatorInfo emulator)
        {
            LogProvider.Log.Info(this, $"Creating pipe server for the instance of '{emulator.Provider.EmulatorName}' with pid {emulator.Process.Id}.");

            // Create and initialize security descriptor
            WinApi.InitializeSecurityDescriptor(out SecurityDescriptor sd, 1);
            WinApi.SetSecurityDescriptorDacl(ref sd, true, IntPtr.Zero, false);

            // Create security attributes
            var sa = new SecurityAttributes
            {
                lpSecurityDescriptor = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SecurityDescriptor))),
                bInheritHandle = false,
                nLength = Marshal.SizeOf(typeof(SecurityAttributes))
            };

            // Marshal security descriptor structure to unmanaged block
            Marshal.StructureToPtr(sd, sa.lpSecurityDescriptor, false);

            // Allocate memory in unmanaged block for security attributes structure
            var pSa = Marshal.AllocHGlobal(sa.nLength);

            // Marshal security attributes structure to unmanaged block
            Marshal.StructureToPtr(sa, pSa, false);

            // Create the named pipe            
            var pipeServerHandle = WinApi.CreateNamedPipe(
                PipeName,
                PipeOpenMode.PIPE_ACCESS_DUPLEX,
                PipeMode.PIPE_TYPE_MESSAGE |
                PipeMode.PIPE_READMODE_MESSAGE |
                PipeMode.PIPE_WAIT,
                PipeNative.PIPE_UNLIMITED_INSTANCES,
                BufferSize,
                BufferSize,
                PipeNative.NMPWAIT_USE_DEFAULT_WAIT,
                pSa);

            if (pipeServerHandle.ToInt32() == PipeNative.INVALID_HANDLE_VALUE)
            {
                LogProvider.Log.Error(this, $"Unable to create named pipe {PipeName} w/ error 0x{WinApi.GetLastError():X} for the instance of '{emulator.Provider.EmulatorName}' with pid {emulator.Process.Id}.");
                return IntPtr.Zero;
            }

            LogProvider.Log.Info(this, $"Pipe server {pipeServerHandle} has been created for the instance of '{emulator.Provider.EmulatorName}' with pid {emulator.Process.Id}.");

            return pipeServerHandle;
        }

        /// <summary>
        /// Close pipe server
        /// </summary>        
        private void ClosePipe()
        {
            if (PipeServerHandle == IntPtr.Zero)
            {
                return;
            }

            if (!WinApi.FlushFileBuffers(PipeServerHandle))
            {
                LogProvider.Log.Warn(this, $"Flushing pipe buffer failed with code 0x{WinApi.GetLastError():X}.");
            }

            if (!WinApi.DisconnectNamedPipe(PipeServerHandle))
            {
                LogProvider.Log.Warn(this, $"Disconnecting pipe failed with code 0x{WinApi.GetLastError():X}.");
            }

            if (!WinApi.CloseHandle(PipeServerHandle))
            {
                LogProvider.Log.Warn(this, $"Closing pipe handle failed with code 0x{WinApi.GetLastError():X}.");
            }

            LogProvider.Log.Info(this, $"Pipe server {PipeServerHandle} closed.");

            PipeServerHandle = IntPtr.Zero;
        }
    }
}