//-----------------------------------------------------------------------
// <copyright file="LogCollector.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using RedDragonCardCatcher.Common.Log;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RedDragonCardCatcher.Services
{
    internal class LogCollector : ILogCollector
    {
        private const string systeInformationFile = "systeminfo.log";

        private readonly string[] pt4Files = new string[]
        {
            @"Logs\PokerTracker4.log",
            @"Logs\PokerTrackerHud4.log",
            @"Config\iPoker.cfg",
            @"Config\PokerTracker.cfg",
            @"Data\HudProfiles.pt4",
            @"Data\Layouts.pt4"
        };

        private readonly string[] hm2Files = new string[]
        {
            "HoldemManager.config",
            "log.txt",
            @"Config\*.xml"
        };

        private readonly string[] pccFiles = new string[]
        {
            @"Logs\*.*",
            @"Settings.xml"
        };

        /// <summary>
        /// Collect logs
        /// </summary>
        public void CollectAllLogs()
        {
            var tempDirectoryPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Temp");

            try
            {
                var tempDirectory = new DirectoryInfo(tempDirectoryPath);

                if (tempDirectory.Exists)
                {
                    tempDirectory.Delete(true);
                }

                tempDirectory.Create();

                CollectPT4Logs(tempDirectory);
                CollectHM2Logs(tempDirectory);
                CollectPCCLogs(tempDirectory);
                CollectSystemInfoLogs(tempDirectory);

                ZipFolder(tempDirectory);

                tempDirectory.Delete(true);
            }
            catch (Exception ex)
            {
                LogProvider.Log.Error(this, "Error occurred during log collecting", ex);
            }
        }

        /// <summary>
        /// Collect PT4 logs
        /// </summary>
        /// <param name="tempDirectory">Directory where log will be copied</param>
        private void CollectPT4Logs(DirectoryInfo tempDirectory)
        {
            var pt4DataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PokerTracker 4");

            var pt4DataDirectoryInfo = new DirectoryInfo(pt4DataFolder);

            CopyFiles(pt4Files, pt4DataDirectoryInfo, tempDirectory);
        }

        /// <summary>
        /// Collect HM2 logs
        /// </summary>
        /// <param name="tempDirectory">Directory where log will be copied</param>
        private void CollectHM2Logs(DirectoryInfo tempDirectory)
        {
            var hm2DataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HoldemManager");

            var hm2DataDirectoryInfo = new DirectoryInfo(hm2DataFolder);

            CopyFiles(hm2Files, hm2DataDirectoryInfo, tempDirectory);
        }

        /// <summary>
        /// Collect pcc logs
        /// </summary>
        /// <param name="tempDirectory">Directory where log will be copied</param>
        private void CollectPCCLogs(DirectoryInfo tempDirectory)
        {
            var bccFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var bccDataDirectoryInfo = new DirectoryInfo(bccFolder);

            CopyFiles(pccFiles, bccDataDirectoryInfo, tempDirectory);
        }

        /// <summary>
        /// Collect system information
        /// </summary>
        /// <param name="tempDirectory">Temp directory where system information file will be placed</param>
        private void CollectSystemInfoLogs(DirectoryInfo tempDirectory)
        {
            var systemInfoProcess = new Process();

            systemInfoProcess.StartInfo.UseShellExecute = false;
            systemInfoProcess.StartInfo.FileName = "systeminfo";
            systemInfoProcess.StartInfo.CreateNoWindow = true;
            systemInfoProcess.StartInfo.RedirectStandardOutput = true;
            systemInfoProcess.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            systemInfoProcess.Start();

            var systemInformationText = systemInfoProcess.StandardOutput.ReadToEnd();

            systemInfoProcess.WaitForExit();

            var installedNetFrameworks = FrameworkVersionDetection.InstalledFrameworkVersions.Cast<string>().ToArray();

            var systemInfoStringBuilder = new StringBuilder(systemInformationText);

            var netFrameworkInfoText = ".NET Frameworks:";
            netFrameworkInfoText = netFrameworkInfoText.PadRight(netFrameworkInfoText.Length + 11);

            systemInfoStringBuilder.Append(netFrameworkInfoText);

            for (var i = 0; i < installedNetFrameworks.Length; i++)
            {
                if (i == 0)
                {
                    systemInfoStringBuilder.AppendLine(installedNetFrameworks[i]);
                }
                else
                {
                    var totalWidth = netFrameworkInfoText.Length + installedNetFrameworks[i].Length;
                    systemInfoStringBuilder.AppendLine(installedNetFrameworks[i].PadLeft(totalWidth));
                }
            }

            var systemInformationLogPath = Path.Combine(tempDirectory.FullName, systeInformationFile);

            File.AppendAllText(systemInformationLogPath, systemInfoStringBuilder.ToString());
        }

        /// <summary>
        /// Copy files from source dir to destination dir
        /// </summary>
        /// <param name="fileList">List of file paths</param>
        /// <param name="sourceDirectory">Source directory</param>
        /// <param name="destinationDirectory">Destination directory</param>
        private void CopyFiles(string[] fileList, DirectoryInfo sourceDirectory, DirectoryInfo destinationDirectory)
        {
            if (!sourceDirectory.Exists)
            {
                return;
            }

            foreach (var file in fileList)
            {
                var directories = file.Split('\\');

                var filePattern = directories.Last();
                var directoryFullName = Path.Combine(sourceDirectory.FullName, string.Join(@"\", directories.Take(directories.Length - 1).ToArray()));

                var directoryInfo = new DirectoryInfo(directoryFullName);

                if (!directoryInfo.Exists)
                {
                    continue;
                }

                foreach (var fileInDir in directoryInfo.GetFiles(filePattern))
                {
                    var destinationFullPath = Path.Combine(destinationDirectory.FullName, Path.GetFileName(fileInDir.FullName));
                    fileInDir.CopyTo(destinationFullPath);
                }
            }
        }

        /// <summary>
        /// Zip files from specified to current directory
        /// </summary>
        /// <param name="tempDirectory">Specified directory</param>
        private void ZipFolder(DirectoryInfo tempDirectory)
        {
            var outputFileName = string.Format("pcc-logs-{0:yyyy-MM-dd-HH-mm-ss}.zip", DateTime.Now);

            if (File.Exists(outputFileName))
            {
                File.Delete(outputFileName);
            }

            var fsOut = File.Create(outputFileName);
            var zipStream = new ZipOutputStream(fsOut);

            foreach (var file in tempDirectory.GetFiles())
            {
                var entryName = ZipEntry.CleanName(file.Name);

                var newEntry = new ZipEntry(entryName)
                {
                    DateTime = file.LastWriteTime,
                    Size = file.Length
                };

                zipStream.PutNextEntry(newEntry);

                var buffer = new byte[4096];

                using (var streamReader = File.OpenRead(file.FullName))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }

                zipStream.CloseEntry();
            }

            zipStream.IsStreamOwner = true;
            zipStream.Close();
        }
    }
}