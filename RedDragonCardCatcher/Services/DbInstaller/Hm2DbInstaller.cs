//-----------------------------------------------------------------------
// <copyright file="Hm2DbInstaller.cs" company="Ace Poker Solutions">
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace RedDragonCardCatcher.DbInstallers
{
    internal class Hm2DbInstaller : IDbInstaller
    {
        private const byte Hm2PokerStarsCode = 4;
        private const byte Hm2IPokerCode = 16;

        private static readonly byte[] Hm2DatabaseCodes = new[] { Hm2PokerStarsCode, Hm2IPokerCode };

        private const string Hm2HandHistoryPattern = @"{0},True,C:\HM2Archive,True,True,{1}";

        public bool CanInstall(out string[] warnings)
        {
            warnings = null;

            if (IsHm2Opened())
            {
                warnings = new[] { "Common_Settings_HM2OpenedWarning" };
                return false;
            }

            return true;
        }

        public void Install()
        {
            LogProvider.Log.Info(this, "Updating HM2 settings.");

            var assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var handhistoriesPath = Path.Combine(assemblyPath, "HandHistories");

            var settingsFilePath = DBHelper.GetHM2ConfigurationFile();

            var settingsFilePathBak = settingsFilePath + ".bak";

            if (File.Exists(settingsFilePathBak))
            {
                File.Delete(settingsFilePathBak);
            }

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(settingsFilePath);

            var autoImportNode = xmlDocument.SelectSingleNode("//Section[@Name='Import']/Key[@Name='AutoImportFolders']");

            // create nodes if they are missed
            if (autoImportNode == null)
            {
                var importSectionNode = xmlDocument.SelectSingleNode("//Section[@Name='Import']");

                if (importSectionNode == null)
                {
                    importSectionNode = xmlDocument.CreateNode(XmlNodeType.Element, "Section", string.Empty);

                    var importSectionNameAttr = xmlDocument.CreateAttribute("Name");
                    importSectionNameAttr.Value = "Import";

                    importSectionNode.Attributes.Append(importSectionNameAttr);

                    xmlDocument.DocumentElement.AppendChild(importSectionNode);
                }

                autoImportNode = xmlDocument.CreateNode(XmlNodeType.Element, "Key", string.Empty);

                var autoImportNameAttr = xmlDocument.CreateAttribute("Name");
                autoImportNameAttr.Value = "AutoImportFolders";

                autoImportNode.Attributes.Append(autoImportNameAttr);

                importSectionNode.InsertBefore(autoImportNode, importSectionNode.FirstChild);
            }

            var autoImportValueAttr = autoImportNode.Attributes["Value"];

            if (autoImportValueAttr == null)
            {
                autoImportValueAttr = xmlDocument.CreateAttribute("Value");
                autoImportNode.Attributes.Append(autoImportValueAttr);
            }

            var autoImportFolders = string.IsNullOrWhiteSpace(autoImportValueAttr.Value) ?
                                        new string[0] :
                                        autoImportValueAttr.Value.Split('|');

            var hm2HandHistories = (from Hm2DatabaseCode in Hm2DatabaseCodes
                                    select new
                                    {
                                        DbCode = Hm2DatabaseCode,
                                        HandHistory = string.Format(Hm2HandHistoryPattern, handhistoriesPath, Hm2DatabaseCode)
                                    }).ToDictionary(x => x.DbCode, x => x.HandHistory);

            var hhPathToAdd = hm2HandHistories[Hm2IPokerCode];
            var hhPathsToAdd = new[] { hhPathToAdd };

            autoImportFolders = autoImportFolders.Except(hm2HandHistories.Values.ToArray()).ToArray();

            autoImportFolders = autoImportFolders.Length > 0 ? autoImportFolders.Concat(hhPathsToAdd).ToArray() : hhPathsToAdd;

            autoImportValueAttr.Value = string.Join("|", autoImportFolders);

            xmlDocument.Save(settingsFilePath);

            LogProvider.Log.Info(this, "HM2 settings have been updated.");
        }

        private static bool IsHm2Opened()
        {
            var processes = Process.GetProcesses();

            var hm2Process = processes.FirstOrDefault(x => x.ProcessName.Contains("HoldemManager"));

            if (hm2Process != null)
            {
                return true;
            }

            return false;
        }
    }
}