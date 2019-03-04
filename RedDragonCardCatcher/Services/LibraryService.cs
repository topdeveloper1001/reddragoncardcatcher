//-----------------------------------------------------------------------
// <copyright file="LibraryService.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.Common.Exceptions;
using RedDragonCardCatcher.Common.Log;
using RedDragonCardCatcher.Common.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace RedDragonCardCatcher.Services
{
    internal class LibraryService : ILibraryService
    {
        private const string embeddedResoucePath = "RedDragonCardCatcher.Lib.";

        private static readonly object sync = new object();

        private static readonly Dictionary<LibraryType, LibraryInfo> libraryResourceNameByType = new Dictionary<LibraryType, LibraryInfo>
        {
            [LibraryType.EmulatorHelper] = new LibraryInfo($"{embeddedResoucePath}EmulatorHelper.dll"),
            [LibraryType.Injector] = new LibraryInfo($"{embeddedResoucePath}injector"),
            [LibraryType.LibHook] = new LibraryInfo($"{embeddedResoucePath}libhookimpl.so"),
        };

        public string GetLibraryPath(LibraryType libraryType)
        {
            lock (sync)
            {
                try
                {
                    var libraryFileInfo = libraryResourceNameByType[libraryType];
                    var libraryFile = Path.Combine(Path.GetTempPath(), libraryFileInfo.FileName);

                    if (File.Exists(libraryFile) && libraryFileInfo.IsInitialized)
                    {
                        return libraryFile;
                    }

                    try
                    {
                        if (File.Exists(libraryFile))
                        {
                            File.Delete(libraryFile);
                        }

                        using (var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(libraryFileInfo.ResourceName))
                        {
                            if (resourceStream == null)
                            {
                                throw new RDCCInternalException(new NonLocalizableString($"Resource {libraryFileInfo.ResourceName} not found."));
                            }

                            using (var fileStream = new FileStream(libraryFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                            {
                                resourceStream.CopyTo(fileStream);
                            }
                        }

                        libraryFileInfo.IsInitialized = true;
                    }
                    catch (Exception e)
                    {
                        LogProvider.Log.Error(this, $"Failed to prepare library '{libraryFileInfo.FileName}'. Returned default path.", e);
                    }

                    return libraryFile;
                }

                catch (Exception e)
                {
                    LogProvider.Log.Error(this, $"Failed to get path to library '{libraryType}'", e);
                    return null;
                }
            }
        }

        public void RemoveAll()
        {
            lock (sync)
            {
                foreach (var libraryFileInfo in libraryResourceNameByType.Values)
                {
                    try
                    {
                        var libraryFile = Path.Combine(Path.GetTempPath(), libraryFileInfo.FileName);

                        if (!File.Exists(libraryFile) || !libraryFileInfo.IsInitialized)
                        {
                            continue;
                        }

                        File.Delete(libraryFile);

                        libraryFileInfo.IsInitialized = false;
                    }
                    catch (Exception e)
                    {
                        LogProvider.Log.Error(this, $"Failed to delete '{libraryFileInfo.FileName}'", e);
                    }
                }
            }
        }

        private class LibraryInfo
        {
            public LibraryInfo(string resourceName)
            {
                ResourceName = resourceName;
            }

            public string ResourceName { get; }

            public string FileName => ResourceName.Substring(embeddedResoucePath.Length);

            public bool IsInitialized { get; set; }
        }
    }
}