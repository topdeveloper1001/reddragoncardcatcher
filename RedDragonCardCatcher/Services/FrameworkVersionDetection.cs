//-----------------------------------------------------------------------
// <copyright file="FrameworkVersionDetection.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using Microsoft.Win32;
using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace RedDragonCardCatcher.Services
{
    #region class FrameworkVersionDetection
    /// <summary>
    /// Provides support for determining if a specific version of the .NET
    /// Framework runtime is installed and the service pack level for the
    /// runtime version.
    /// </summary>
    internal static class FrameworkVersionDetection
    {
        #region events

        #endregion

        #region class-wide fields

        // Constants representing registry key names and value names
        private const string Netfx10RegKeyName = "Software\\Microsoft\\.NETFramework\\Policy\\v1.0";
        private const string Netfx10RegKeyValue = "3705";
        private const string Netfx10SPxMSIRegKeyName = "Software\\Microsoft\\Active Setup\\Installed Components\\{78705f0d-e8db-4b2d-8193-982bdda15ecd}";
        private const string Netfx10SPxOCMRegKeyName = "Software\\Microsoft\\Active Setup\\Installed Components\\{FDC11A6F-17D1-48f9-9EA3-9051954BAA24}";
        private const string Netfx11RegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v1.1.4322";
        private const string Netfx20RegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v2.0.50727";
        private const string Netfx30RegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v3.0\\Setup";
        private const string Netfx30SpRegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v3.0";
        private const string Netfx30RegValueName = "InstallSuccess";
        private const string Netfx35RegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v3.5";
        private const string Netfx40ClientRegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v4.0\\Client";
        private const string Netfx40FullRegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v4.0\\Full";
        private const string Netfx4xFullRegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full";

        private const string NetfxStandardRegValueName = "Install";
        private const string NetfxStandrdSpxRegValueName = "SP";
        private const string NetfxStandardVersionRegValueName = "Version";
        private const string NetfxReleaseVersionRegValueName = "Release";

        private const string Netfx20PlusBuildRegValueName = "Increment";
        private const string Netfx35PlusBuildRegValueName = "Build";

        private const string NetfxInstallRootRegKeyName = "Software\\Microsoft\\.NETFramework";
        private const string NetFxInstallRootRegValueName = "InstallRoot";

        private static readonly Version Netfx10Version = new Version(1, 0, 3705, 0);
        private static readonly Version Netfx11Version = new Version(1, 1, 4322, 573);
        private static readonly Version Netfx20Version = new Version(2, 0, 50727, 42);
        private static readonly Version Netfx30Version = new Version(3, 0, 4506, 26);
        private static readonly Version Netfx35Version = new Version(3, 5, 21022, 8);
        private static readonly Version Netfx45Version = new Version(4, 5, 0, 0);
        private static readonly Version Netfx451Version = new Version(4, 5, 1, 0);
        private static readonly Version Netfx452Version = new Version(4, 5, 2, 0);
        private static readonly Version Netfx46Version = new Version(4, 6, 0, 0);
        private static readonly Version Netfx461Version = new Version(4, 6, 1, 0);

        private const string Netfx10VersionString = "v1.0.3705";
        private const string Netfx11VersionString = "v1.1.4322";
        private const string Netfx20VersionString = "v2.0.50727";
        private const string NetfxMscorwks = "mscorwks.dll";
        #endregion

        #region private and internal properties and methods

        #region properties

        #endregion

        #region methods

        #region CheckFxVersion

        /// <summary>
        /// Retrieves the .NET Framework version number from the registry
        /// and validates that it is not a pre-release version number.
        /// </summary>
        /// <param name="frameworkVersion"></param>
        /// <returns><see langword="true"/> if the build number is greater than the 
        /// requested version; otherwise <see langword="false"/>.
        /// </returns>
        /// <remarks>If mscorwks.dll can be found the version number of the DLL (looking
        /// at the ProductVersion field) is also used.
        /// </remarks>
        private static bool CheckFxVersion(FrameworkVersion frameworkVersion)
        {
            bool valid = false;
            string installPath = GetMscorwksPath(frameworkVersion);
            FileVersionInfo fvi = null;
            Version fxVersion;

            if (!String.IsNullOrEmpty(installPath))
            {
                fvi = FileVersionInfo.GetVersionInfo(installPath);
            }

            switch (frameworkVersion)
            {
                case FrameworkVersion.Fx10:
                    fxVersion = GetNetfx10ExactVersion();
                    valid = (fvi != null) ? ((fxVersion >= Netfx10Version) && (new Version(fvi.ProductVersion) >= Netfx10Version)) : (fxVersion >= Netfx10Version);
                    break;
                case FrameworkVersion.Fx11:
                    fxVersion = GetNetfx11ExactVersion();
                    valid = (fvi != null) ? ((fxVersion >= Netfx11Version) && (new Version(fvi.ProductVersion) >= Netfx11Version)) : (fxVersion >= Netfx11Version);
                    break;
                case FrameworkVersion.Fx20:
                    fxVersion = GetNetfx20ExactVersion();
                    valid = (fvi != null) ? ((fxVersion >= Netfx20Version) && (new Version(fvi.ProductVersion) >= Netfx20Version)) : (fxVersion >= Netfx20Version);
                    break;
                case FrameworkVersion.Fx30:
                    fxVersion = GetNetfxExactVersion(Netfx30RegKeyName, NetfxStandardVersionRegValueName);
                    valid = (fvi != null) ? ((fxVersion >= Netfx30Version) && (new Version(fvi.ProductVersion) >= Netfx20Version)) : (fxVersion >= Netfx30Version);
                    break;
                case FrameworkVersion.Fx35:
                    fxVersion = GetNetfxExactVersion(Netfx35RegKeyName, NetfxStandardVersionRegValueName);
                    valid = (fvi != null) ? ((fxVersion >= Netfx35Version) && (new Version(fvi.ProductVersion) >= Netfx20Version)) : (fxVersion >= Netfx35Version);
                    break;
                default:
                    valid = false;
                    break;
            }

            return valid;
        }

        #endregion

        #region GetInstallRoot

        /// <summary>
        /// Gets the installation root path for the .NET Framework.
        /// </summary>
        /// <returns>A <see cref="String"/> representing the installation root 
        /// path for the .NET Framework.</returns>
        private static string GetInstallRoot()
        {
            string installRoot = String.Empty;

            if (!GetRegistryValue(RegistryHive.LocalMachine, NetfxInstallRootRegKeyName, NetFxInstallRootRegValueName, RegistryValueKind.String, out installRoot))
            {
                throw new DirectoryNotFoundException("Unable to determine the install root path for the .NET Framework.");
            }

            return installRoot;
        }
        #endregion

        #region GetMscorwksPath

        /// <summary>
        /// Gets the path to the Mscorwks.DLL file.
        /// </summary>
        /// <param name="frameworkVersion"></param>
        /// <returns>The fully qualified path to the Mscorwks.DLL for the specified .NET
        /// Framework.
        /// </returns>
        private static string GetMscorwksPath(FrameworkVersion frameworkVersion)
        {
            string ret = String.Empty;

            switch (frameworkVersion)
            {
                case FrameworkVersion.Fx10:
                    ret = Path.Combine(Path.Combine(GetInstallRoot(), Netfx10VersionString), NetfxMscorwks);
                    break;

                case FrameworkVersion.Fx11:
                    ret = Path.Combine(Path.Combine(GetInstallRoot(), Netfx11VersionString), NetfxMscorwks);
                    break;

                case FrameworkVersion.Fx20:
                case FrameworkVersion.Fx30:
                case FrameworkVersion.Fx35:
                    ret = Path.Combine(Path.Combine(GetInstallRoot(), Netfx20VersionString), NetfxMscorwks);
                    break;

                default:
                    break;
            }

            return ret;
        }

        #endregion

        #region GetNetfxSPLevel functions

        #region GetNetfx10SPLevel

        /// <summary>
        /// Detects the service pack level for the .NET Framework 1.0.
        /// </summary>
        /// <returns>An <see cref="Int32"/> representing the service pack 
        /// level for the .NET Framework.</returns>
        /// <remarks>Uses the detection method recommended at
        /// http://blogs.msdn.com/astebner/archive/2004/09/14/229802.aspx 
        /// to determine what service pack for the .NET Framework 1.0 is 
        /// installed on the machine.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "System.Int32.TryParse(System.String,System.Int32@)")]
        private static int GetNetfx10SPLevel()
        {
            bool foundKey = false;
            int servicePackLevel = -1;
            string regValue;


            foundKey = GetRegistryValue(RegistryHive.LocalMachine, Netfx10SPxMSIRegKeyName, NetfxStandardVersionRegValueName, RegistryValueKind.String, out regValue);


            if (foundKey)
            {
                // This registry value should be of the format
                // #,#,#####,# where the last # is the SP level
                // Try to parse off the last # here
                int index = regValue.LastIndexOf(',');
                if (index > 0)
                {
                    Int32.TryParse(regValue.Substring(index + 1), out servicePackLevel);
                }
            }

            return servicePackLevel;
        }

        #endregion

        #region GetNetfxSPLevel

        /// <summary>
        /// Detects the service pack level for a version of .NET Framework.
        /// </summary>
        /// <param name="key">The registry key name.</param>
        /// <param name="value">The registry value name.</param>
        /// <returns>An <see cref="Int32"/> representing the service pack 
        /// level for the .NET Framework.</returns>
        private static int GetNetfxSPLevel(string key, string value)
        {
            int regValue = 0;

            // We can only get -1 if the .NET Framework is not
            // installed or there was some kind of error retrieving
            // the data from the registry
            int servicePackLevel = -1;

            if (GetRegistryValue(RegistryHive.LocalMachine, key, value, RegistryValueKind.DWord, out regValue))
            {
                servicePackLevel = regValue;
            }

            return servicePackLevel;
        }

        #endregion

        #endregion

        #region GetNetfxExactVersion functions

        #region GetNetfx10ExactVersion

        private static Version GetNetfx10ExactVersion()
        {
            bool foundKey = false;
            Version fxVersion = new Version();
            string regValue;

            foundKey = GetRegistryValue(RegistryHive.LocalMachine, Netfx10SPxMSIRegKeyName, NetfxStandardVersionRegValueName, RegistryValueKind.String, out regValue);

            if (foundKey)
            {
                // This registry value should be of the format
                // #,#,#####,# where the last # is the SP level
                // Try to parse off the last # here
                int index = regValue.LastIndexOf(',');
                if (index > 0)
                {
                    string[] tokens = regValue.Substring(0, index).Split(',');
                    if (tokens.Length == 3)
                    {
                        fxVersion = new Version(Convert.ToInt32(tokens[0], NumberFormatInfo.InvariantInfo), Convert.ToInt32(tokens[1], NumberFormatInfo.InvariantInfo), Convert.ToInt32(tokens[2], NumberFormatInfo.InvariantInfo));
                    }
                }
            }

            return fxVersion;
        }

        #endregion

        #region GetNetfx11ExactVersion

        private static Version GetNetfx11ExactVersion()
        {
            int regValue = 0;

            // We can only get -1 if the .NET Framework is not
            // installed or there was some kind of error retrieving
            // the data from the registry
            Version fxVersion = new Version();

            if (GetRegistryValue(RegistryHive.LocalMachine, Netfx11RegKeyName, NetfxStandardRegValueName, RegistryValueKind.DWord, out regValue))
            {
                if (regValue == 1)
                {
                    // In the strict sense, we are cheating here, but the registry key name itself
                    // contains the version number.
                    string[] tokens = Netfx11RegKeyName.Split(new string[] { "NDP\\v" }, StringSplitOptions.None);
                    if (tokens.Length == 2)
                    {
                        fxVersion = new Version(tokens[1]);
                    }
                }
            }

            return fxVersion;
        }

        #endregion

        #region GetNetfx20ExactVersion

        private static Version GetNetfx20ExactVersion()
        {
            string regValue = String.Empty;

            // We can only get -1 if the .NET Framework is not
            // installed or there was some kind of error retrieving
            // the data from the registry
            Version fxVersion = new Version();

            // If we have a Version registry value, use that.
            try
            {
                fxVersion = GetNetfxExactVersion(Netfx20RegKeyName, NetfxStandardVersionRegValueName);
            }
            catch (IOException)
            {
                // If we hit an exception here, the Version registry key probably doesn't exist so try
                // to get the version based on the registry key name itself.
                if (GetRegistryValue(RegistryHive.LocalMachine, Netfx20RegKeyName, Netfx20PlusBuildRegValueName, RegistryValueKind.String, out regValue))
                {
                    if (!String.IsNullOrEmpty(regValue))
                    {
                        string[] versionTokens = Netfx20RegKeyName.Split(new string[] { "NDP\\v" }, StringSplitOptions.None);
                        if (versionTokens.Length == 2)
                        {
                            string[] tokens = versionTokens[1].Split('.');
                            if (tokens.Length == 3)
                            {
                                fxVersion = new Version(Convert.ToInt32(tokens[0], NumberFormatInfo.InvariantInfo), Convert.ToInt32(tokens[1], NumberFormatInfo.InvariantInfo), Convert.ToInt32(tokens[2], NumberFormatInfo.InvariantInfo), Convert.ToInt32(regValue, NumberFormatInfo.InvariantInfo));
                            }
                        }
                    }
                }
            }

            return fxVersion;
        }

        #endregion

        #region GetNetfxExactVersion

        /// <summary>
        /// Retrieves the .NET Framework version number from the registry.
        /// </summary>
        /// <param name="key">The registry key name.</param>
        /// <param name="value">The registry value name.</param>
        /// <returns>A <see cref="Version"/> that represents the .NET 
        /// Framework version.</returns>
        private static Version GetNetfxExactVersion(string key, string value)
        {
            string regValue = String.Empty;

            // We can only get the default version if the .NET Framework
            // is not installed or there was some kind of error retrieving
            // the data from the registry
            Version fxVersion = new Version();

            if (GetRegistryValue(RegistryHive.LocalMachine, key, value, RegistryValueKind.String, out regValue))
            {
                if (!String.IsNullOrEmpty(regValue))
                {
                    fxVersion = new Version(regValue);
                }
            }

            return fxVersion;
        }

        private static string GetNetfx4xExactVersion(string key, string value)
        {
            int regValue = 0;

            // We can only get the default version if the .NET Framework
            // is not installed or there was some kind of error retrieving
            // the data from the registry
            Version fxVersion = new Version();

            if (GetRegistryValue(RegistryHive.LocalMachine, key, value, RegistryValueKind.DWord, out regValue))
            {
                if (regValue != 0)
                {
                    if (regValue >= 393295)
                    {
                        fxVersion = Netfx46Version;
                    }
                    else if ((regValue >= 379893))
                    {
                        fxVersion = Netfx452Version;
                    }
                    else if ((regValue >= 378675))
                    {
                        fxVersion = Netfx451Version;
                    }
                    else if ((regValue >= 378389))
                    {
                        fxVersion = Netfx45Version;
                    }
                }
            }

            return string.Format("{0} ({1})", fxVersion, regValue);
        }

        #endregion

        #endregion

        #region GetRegistryValue

        public static bool GetRegistryValue<T>(RegistryHive hive, string key, string value, RegistryValueKind kind, out T data)
        {
            bool success = false;
            data = default(T);

            using (RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(hive, String.Empty))
            {
                if (baseKey != null)
                {
                    using (RegistryKey registryKey = baseKey.OpenSubKey(key, RegistryKeyPermissionCheck.ReadSubTree))
                    {
                        if (registryKey != null)
                        {
                            object regValue = registryKey.GetValue(value, null);

                            if (regValue != null)
                            {
                                // If the key was opened, try to retrieve the value.
                                RegistryValueKind kindFound = registryKey.GetValueKind(value);

                                if (kindFound == kind)
                                {
                                    data = (T)Convert.ChangeType(regValue, typeof(T), CultureInfo.InvariantCulture);
                                    success = true;
                                }
                            }
                        }
                    }
                }
            }

            return success;
        }

        #endregion

        #region IsNetfxInstalled functions

        #region IsNetfx10Installed

        /// <summary>
        /// Detects if the .NET 1.0 Framework is installed.
        /// </summary>
        /// <returns><see langword="true"/> if the .NET Framework 1.0 is 
        /// installed; otherwise <see langword="false"/></returns>
        /// <remarks>Uses the detection method recommended at
        /// http://msdn.microsoft.com/library/ms994349.aspx to determine
        /// whether the .NET Framework 1.0 is installed on the machine.
        /// </remarks>
        private static bool IsNetfx10Installed()
        {
            bool found = false;
            string regValue = string.Empty;
            found = GetRegistryValue(RegistryHive.LocalMachine, Netfx10RegKeyName, Netfx10RegKeyValue, RegistryValueKind.String, out regValue);

            return (found && CheckFxVersion(FrameworkVersion.Fx10));
        }

        #endregion

        #region IsNetfx11Installed

        /// <summary>
        /// Detects if the .NET 1.1 Framework is installed.
        /// </summary>
        /// <returns><see langword="true"/> if the .NET Framework 1.1 is 
        /// installed; otherwise <see langword="false"/></returns>
        /// <remarks>Uses the detection method recommended at
        /// http://msdn.microsoft.com/library/ms994339.aspx to determine
        /// whether the .NET Framework 1.1 is installed on the machine.
        /// </remarks>
        private static bool IsNetfx11Installed()
        {
            bool found = false;
            int regValue = 0;

            if (GetRegistryValue(RegistryHive.LocalMachine, Netfx11RegKeyName, NetfxStandardRegValueName, RegistryValueKind.DWord, out regValue))
            {
                if (regValue == 1)
                {
                    found = true;
                }
            }

            return (found && CheckFxVersion(FrameworkVersion.Fx11));
        }

        #endregion

        #region IsNetfx20Installed

        /// <summary>
        /// Detects if the .NET 2.0 Framework is installed.
        /// </summary>
        /// <returns><see langword="true"/> if the .NET Framework 2.0 is 
        /// installed; otherwise <see langword="false"/></returns>
        /// <remarks>Uses the detection method recommended at
        /// http://msdn.microsoft.com/library/aa480243.aspx to determine
        /// whether the .NET Framework 2.0 is installed on the machine.
        /// </remarks>
        private static bool IsNetfx20Installed()
        {
            bool found = false;
            int regValue = 0;

            if (GetRegistryValue(RegistryHive.LocalMachine, Netfx20RegKeyName, NetfxStandardRegValueName, RegistryValueKind.DWord, out regValue))
            {
                if (regValue == 1)
                {
                    found = true;
                }
            }

            return (found && CheckFxVersion(FrameworkVersion.Fx20));
        }

        #endregion

        #region IsNetfx30Installed

        /// <summary>
        /// Detects if the .NET 3.0 Framework is installed.
        /// </summary>
        /// <returns><see langword="true"/> if the .NET Framework 3.0 is 
        /// installed; otherwise <see langword="false"/></returns>
        /// <remarks>Uses the detection method recommended at
        /// http://msdn.microsoft.com/library/aa964979.aspx to determine
        /// whether the .NET Framework 3.0 is installed on the machine.
        /// </remarks>
        private static bool IsNetfx30Installed()
        {
            bool found = false;
            int regValue = 0;

            // The .NET Framework 3.0 is an add-in that installs on top of
            // the .NET Framework 2.0, so validate that both 2.0 and 3.0
            // are installed.
            if (IsNetfx20Installed())
            {
                // Check that the InstallSuccess registry value exists and equals 1.
                if (GetRegistryValue(RegistryHive.LocalMachine, Netfx30RegKeyName, Netfx30RegValueName, RegistryValueKind.DWord, out regValue))
                {
                    if (regValue == 1)
                    {
                        found = true;
                    }
                }
            }

            // A system with a pre-release version of the .NET Fx 3.0 can have
            // the InstallSuccess value. As an added verification, check the
            // version number listed in the registry.
            return (found && CheckFxVersion(FrameworkVersion.Fx30));
        }

        #endregion

        #region IsNetfx35Installed

        /// <summary>
        /// Detects if the .NET 3.5 Framework is installed.
        /// </summary>
        /// <returns><see langword="true"/> if the .NET Framework 3.5 is 
        /// installed; otherwise <see langword="false"/></returns>
        /// <remarks>Uses the detection method recommended at
        /// http://msdn.microsoft.com/library/cc160716.aspx to determine
        /// whether the .NET Framework 3.5 is installed on the machine.
        /// Also uses the method described at 
        /// http://blogs.msdn.com/astebner/archive/2008/07/13/8729636.aspx.
        /// </remarks>
        private static bool IsNetfx35Installed()
        {
            bool found = false;
            int regValue = 0;

            // The .NET Framework 3.0 is an add-in that installs on top of
            // the .NET Framework 2.0 and 3.0, so validate that 2.0, 3.0,
            // and 3.5 are installed.
            if (IsNetfx20Installed() && IsNetfx30Installed())
            {
                // Check that the Install registry value exists and equals 1.
                if (GetRegistryValue(RegistryHive.LocalMachine, Netfx35RegKeyName, NetfxStandardRegValueName, RegistryValueKind.DWord, out regValue))
                {
                    if (regValue == 1)
                    {
                        found = true;
                    }
                }
            }

            // A system with a pre-release version of the .NET Fx 3.5 can have
            // the InstallSuccess value. As an added verification, check the
            // version number listed in the registry.
            return (found && CheckFxVersion(FrameworkVersion.Fx35));
        }

        #endregion

        #region IsNetfx40Installed

        private static bool IsNetfx40ClientInstalled()
        {
            bool found = false;
            int regValue = 0;

            if (GetRegistryValue(RegistryHive.LocalMachine, Netfx40ClientRegKeyName, NetfxStandardRegValueName, RegistryValueKind.DWord, out regValue))
            {
                if (regValue == 1)
                {
                    found = true;
                }
            }

            return found;
        }

        private static bool IsNetfx40FullInstalled()
        {
            bool found = false;
            int regValue = 0;

            if (GetRegistryValue(RegistryHive.LocalMachine, Netfx40FullRegKeyName, NetfxStandardRegValueName, RegistryValueKind.DWord, out regValue))
            {
                if (regValue == 1)
                {
                    found = true;
                }
            }

            return found;
        }

        private static bool IsNetfx4xInstalled()
        {
            bool found = false;
            int regValue = 0;

            if (GetRegistryValue(RegistryHive.LocalMachine, Netfx4xFullRegKeyName, NetfxReleaseVersionRegValueName, RegistryValueKind.DWord, out regValue))
            {
                if (regValue > 0)
                {
                    found = true;
                }
            }

            return found;
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region public properties and methods

        #region properties

        #region InstalledFrameworkVersions
        /// <summary>
        /// Gets an <see cref="IEnumerable"/> list of the installed .NET Framework 
        /// versions.
        /// </summary>
        public static IEnumerable InstalledFrameworkVersions
        {
            get
            {
                if (IsInstalled(FrameworkVersion.Fx10))
                {
                    yield return GetExactVersion(FrameworkVersion.Fx10);
                }
                if (IsInstalled(FrameworkVersion.Fx11))
                {
                    yield return GetExactVersion(FrameworkVersion.Fx11);
                }
                if (IsInstalled(FrameworkVersion.Fx20))
                {
                    yield return GetExactVersion(FrameworkVersion.Fx20);
                }
                if (IsInstalled(FrameworkVersion.Fx30))
                {
                    yield return GetExactVersion(FrameworkVersion.Fx30);
                }
                if (IsInstalled(FrameworkVersion.Fx35))
                {
                    yield return GetExactVersion(FrameworkVersion.Fx35);
                }
                if (IsInstalled(FrameworkVersion.Fx40Client))
                {
                    yield return GetExactVersion(FrameworkVersion.Fx40Client);
                }
                if (IsInstalled(FrameworkVersion.Fx40Full))
                {
                    yield return GetExactVersion(FrameworkVersion.Fx40Full);
                }
                if (IsInstalled(FrameworkVersion.Fx4x))
                {
                    yield return GetExactVersion(FrameworkVersion.Fx4x);
                }
            }
        }
        #endregion

        #endregion

        #region methods

        #region IsInstalled

        #region IsInstalled(FrameworkVersion frameworkVersion)

        ///<overloads>
        /// Determines if the specified .NET Framework or Foundation Library is 
        /// installed on the local computer.
        ///</overloads>
        /// <summary>
        /// Determines if the specified .NET Framework version is installed
        /// on the local computer.
        /// </summary>
        /// <param name="frameworkVersion">The version of the .NET Framework to test.
        /// </param>
        /// <returns><see langword="true"/> if the specified .NET Framework
        /// version is installed; otherwise <see langword="false"/>.</returns>
        public static bool IsInstalled(FrameworkVersion frameworkVersion)
        {
            bool ret = false;

            switch (frameworkVersion)
            {
                case FrameworkVersion.Fx10:
                    ret = IsNetfx10Installed();
                    break;

                case FrameworkVersion.Fx11:
                    ret = IsNetfx11Installed();
                    break;

                case FrameworkVersion.Fx20:
                    ret = IsNetfx20Installed();
                    break;

                case FrameworkVersion.Fx30:
                    ret = IsNetfx30Installed();
                    break;

                case FrameworkVersion.Fx35:
                    ret = IsNetfx35Installed();
                    break;

                case FrameworkVersion.Fx40Client:
                    ret = IsNetfx40ClientInstalled();
                    break;

                case FrameworkVersion.Fx40Full:
                    ret = IsNetfx40FullInstalled();
                    break;

                case FrameworkVersion.Fx4x:
                    ret = IsNetfx4xInstalled();
                    break;

                default:
                    break;
            }

            return ret;
        }

        #endregion

        #endregion

        #region GetServicePackLevel

        #region GetServicePackLevel(FrameworkVersion frameworkVersion)

        ///<overloads>
        /// Retrieves the service pack level for the specified .NET Framework or  
        /// Foundation Library.
        ///</overloads>
        /// <summary>
        /// Retrieves the service pack level for the specified .NET Framework
        /// version.
        /// </summary>
        /// <param name="frameworkVersion">The .NET Framework whose service pack 
        /// level should be retrieved.</param>
        /// <returns>An <see cref="Int32">integer</see> value representing
        /// the service pack level for the specified .NET Framework version. If
        /// the specified .NET Frameowrk version is not found, -1 is returned.
        /// </returns>
        public static int GetServicePackLevel(FrameworkVersion frameworkVersion)
        {
            int servicePackLevel = -1;

            switch (frameworkVersion)
            {
                case FrameworkVersion.Fx10:
                    servicePackLevel = GetNetfx10SPLevel();
                    break;

                case FrameworkVersion.Fx11:
                    servicePackLevel = GetNetfxSPLevel(Netfx11RegKeyName, NetfxStandrdSpxRegValueName);
                    break;

                case FrameworkVersion.Fx20:
                    servicePackLevel = GetNetfxSPLevel(Netfx20RegKeyName, NetfxStandrdSpxRegValueName);
                    break;

                case FrameworkVersion.Fx30:
                    servicePackLevel = GetNetfxSPLevel(Netfx30SpRegKeyName, NetfxStandrdSpxRegValueName);
                    break;

                case FrameworkVersion.Fx35:
                    servicePackLevel = GetNetfxSPLevel(Netfx35RegKeyName, NetfxStandrdSpxRegValueName);
                    break;

                default:
                    break;
            }

            return servicePackLevel;
        }

        #endregion

        #endregion

        #region GetExactVersion

        #region GetExactVersion(FrameworkVersion frameworkVersion)

        ///<overloads>
        /// Retrieves the exact version number for the specified .NET Framework or
        /// Foundation Library.
        ///</overloads>
        /// <summary>
        /// Retrieves the exact version number for the specified .NET Framework
        /// version.
        /// </summary>
        /// <param name="frameworkVersion">The .NET Framework whose version should be 
        /// retrieved.</param>
        /// <returns>A <see cref="Version">version</see> representing
        /// the exact version number for the specified .NET Framework version.
        /// If the specified .NET Frameowrk version is not found, a 
        /// <see cref="Version"/> is returned that represents a 0.0.0.0 version
        /// number.
        /// </returns>
        public static string GetExactVersion(FrameworkVersion frameworkVersion)
        {
            Version fxVersion = new Version();

            switch (frameworkVersion)
            {
                case FrameworkVersion.Fx10:
                    fxVersion = GetNetfx10ExactVersion();
                    break;

                case FrameworkVersion.Fx11:
                    fxVersion = GetNetfx11ExactVersion();
                    break;

                case FrameworkVersion.Fx20:
                    fxVersion = GetNetfx20ExactVersion();
                    break;

                case FrameworkVersion.Fx30:
                    fxVersion = GetNetfxExactVersion(Netfx30RegKeyName, NetfxStandardVersionRegValueName);
                    break;

                case FrameworkVersion.Fx35:
                    fxVersion = GetNetfxExactVersion(Netfx35RegKeyName, NetfxStandardVersionRegValueName);
                    break;

                case FrameworkVersion.Fx40Client:
                    fxVersion = GetNetfxExactVersion(Netfx40ClientRegKeyName, NetfxStandardVersionRegValueName);
                    return string.Format("{0} (Client)", fxVersion);

                case FrameworkVersion.Fx40Full:
                    fxVersion = GetNetfxExactVersion(Netfx40FullRegKeyName, NetfxStandardVersionRegValueName);
                    return string.Format("{0} (Full)", fxVersion);

                case FrameworkVersion.Fx4x:
                    return GetNetfx4xExactVersion(Netfx4xFullRegKeyName, NetfxReleaseVersionRegValueName);

                default:
                    break;
            }

            return fxVersion.ToString();
        }

        #endregion       

        #endregion

        #endregion

        #endregion
    }
    #endregion
}