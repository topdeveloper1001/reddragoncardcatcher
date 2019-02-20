//-----------------------------------------------------------------------
// <copyright file="PipeReaderService.cs" company="Ace Poker Solutions">
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
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace RedDragonCardCatcher.Importers
{
    internal sealed class PipeReaderService : BaseImporter, IPipeReaderService
    {
        private const string pipeName = @"\\.\pipe\RedDragon";

        private IProtectedLogger protectedLogger;
        private IntPtr pipeServerHandle;

        public PipeReaderService()
        {
            InitializeLogger();
        }

        private uint BufferSize => 8192;

        private int PipeReadingTimeout => 2500;

        #region Infrastructure

        private void InitializeLogger()
        {
            var protectedLoggerConfiguration = CreateProtectedLoggerConfiguration();

            protectedLogger = ServiceLocator.Current.GetInstance<IProtectedLogger>();
            protectedLogger.Initialize(protectedLoggerConfiguration);
        }

        /// <summary>
        /// Creates logger to log pipe data
        /// </summary>
        /// <returns></returns>
        private ProtectedLoggerConfiguration CreateProtectedLoggerConfiguration()
        {
            var logger = new ProtectedLoggerConfiguration
            {
                DateFormat = "yyy-MM-dd",
                DateTimeFormat = "HH:mm:ss",
                LogCleanupTemplate = "rdc-games-*-*-*.log",
                LogDirectory = "Logs",
                LogTemplate = "rdc-games-{0}.log",
                MessagesInBuffer = 30
            };

            return logger;
        }

        /// <summary>
        /// Create pipe server to get data from catcher
        /// </summary>
        private IntPtr CreatePipeServer()
        {
            LogProvider.Log.Info(this, "Creating pipe server to get data.");

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
                pipeName,
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
                LogProvider.Log.Error(this, string.Format(CultureInfo.InvariantCulture, "Unable to create named pipe {0} w/ error 0x{1:X}", pipeName, WinApi.GetLastError()));
                return IntPtr.Zero;
            }

            LogProvider.Log.Info(this, "Pipe server has been created.");

            return pipeServerHandle;
        }

        /// <summary>
        /// Close pipe server
        /// </summary>        
        private void ClosePipe()
        {
            if (pipeServerHandle == IntPtr.Zero)
            {
                return;
            }

            if (!WinApi.FlushFileBuffers(pipeServerHandle))
            {
                LogProvider.Log.Warn(this, string.Format(CultureInfo.InvariantCulture, "Flushing pipe buffer failed with code 0x{0:X}.", WinApi.GetLastError()));
            }

            if (!WinApi.DisconnectNamedPipe(pipeServerHandle))
            {
                LogProvider.Log.Warn(this, string.Format(CultureInfo.InvariantCulture, "Disconnecting pipe failed with code 0x{0:X}.", WinApi.GetLastError()));
            }

            if (!WinApi.CloseHandle(pipeServerHandle))
            {
                LogProvider.Log.Warn(this, string.Format(CultureInfo.InvariantCulture, "Closing pipe handle failed with code 0x{0:X}.", WinApi.GetLastError()));
            }

            pipeServerHandle = IntPtr.Zero;
        }

        #endregion

        #region BaseImporter Implementation

        public override string ImporterName => "Pipe importer";

        protected override void DoImport()
        {
            var dataManager = ServiceLocator.Current.GetInstance<IDataManager>();
            dataManager.Initialize(protectedLogger);

            protectedLogger?.CleanLogs();
            protectedLogger?.StartLogging();

            pipeServerHandle = IntPtr.Zero;

            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    if (pipeServerHandle == IntPtr.Zero)
                    {
                        pipeServerHandle = CreatePipeServer();

                        // If pipe hasn't been created then exit from task
                        if (pipeServerHandle == IntPtr.Zero)
                        {
                            LogProvider.Log.Error(this, "Pipe server has not been created. Stopping pipe importer.");
                            RaiseProcessStopped();
                            return;
                        }
                    }

                    var totalBuffer = new List<byte>();

                    bool readResult = false;
                    uint numberOfBytesRead = 0;

                    do
                    {
                        // Buffer for pipe data
                        var lbBuffer = new byte[BufferSize];                        

                        // Read data from the pipe.
                        readResult = WinApi.ReadFile(
                            pipeServerHandle,
                            lbBuffer,
                            BufferSize,
                            out numberOfBytesRead,
                            IntPtr.Zero);                        

                        if (numberOfBytesRead > 0)
                        {
                            totalBuffer.AddRange(lbBuffer.Take((int)numberOfBytesRead));
                        }

                    } while (!readResult && numberOfBytesRead != 0 && !cancellationTokenSource.IsCancellationRequested);

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

                    // process pipe's data
                    dataManager.ProcessData(totalBuffer.ToArray());
                }
                catch (Exception e)
                {
                    LogProvider.Log.Error(this, "Failed to process pipe data", e);
                }
            }

            ClosePipe();

            LogProvider.Log.Info(this, "Pipe server was closed.");

            protectedLogger?.StopLogging();

            RaiseProcessStopped();
        }

        #endregion
    }
}