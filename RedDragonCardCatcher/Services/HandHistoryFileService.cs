//-----------------------------------------------------------------------
// <copyright file="HandHistoryFileService.cs" company="Ace Poker Solutions">
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
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Xml;

namespace RedDragonCardCatcher.Services
{
    internal class HandHistoryFileService : IHandHistoryFileService
    {
        public const string HandHistoryFolder = "HandHistories";
        public const string HandHistoryExtension = "xml";

        private readonly object locker = new object();

        private ConcurrentDictionary<string, XmlDocument> handHistoriesCache;

        public HandHistoryFileService()
        {
            handHistoriesCache = new ConcurrentDictionary<string, XmlDocument>();
        }

        public void Save(HandHistoryFileInfo handHistoryFileInfo)
        {
            if (handHistoryFileInfo == null)
            {
                return;
            }

            lock (locker)
            {
                var handHistoryFile = Path.Combine(HandHistoryFolder, string.Format("{0}.{1}", handHistoryFileInfo.FileName, HandHistoryExtension));

                try
                {
                    var directoryInfo = new DirectoryInfo(HandHistoryFolder);

                    if (!directoryInfo.Exists)
                    {
                        directoryInfo.Create();
                    }

                    var existing = GetExistingHandHistory(handHistoryFile);

                    // if new file
                    if (existing == null)
                    {
                        File.WriteAllText(handHistoryFile, handHistoryFileInfo.HandHistoryXml.InnerXml);
                        LogProvider.Log.Info(this, $"Hand #{handHistoryFileInfo.HandNumber} written to '{handHistoryFile}'.");
                        return;
                    }

                    var current = handHistoryFileInfo.HandHistoryXml;
                    current.PreserveWhitespace = true;

                    var game = current.SelectSingleNode("//game");

                    UpdateExistingNodeText(current, existing, "//buyin");
                    UpdateExistingNodeText(current, existing, "//totalbuyin");
                    UpdateExistingNodeText(current, existing, "//nickname");
                    UpdateExistingNodeText(current, existing, "//place");
                    UpdateExistingNodeText(current, existing, "//win");

                    if (!HandExists(existing, handHistoryFileInfo.HandNumber))
                    {
                        var gameXmlNodeImported = existing.ImportNode(game, true);
                        existing.DocumentElement.AppendChild(gameXmlNodeImported);
                    }

                    handHistoriesCache.AddOrUpdate(handHistoryFile, existing, (key, existingValue) => existing);

                    File.WriteAllText(handHistoryFile, existing.InnerXml);
                    LogProvider.Log.Info(this, $"Hand #{handHistoryFileInfo.HandNumber} appended to '{handHistoryFile}'.");
                }
                catch (Exception e)
                {
                    LogProvider.Log.Error(this, $"Hand history '{handHistoryFile}' could not be saved.", e);
                }
            }
        }

        public void ResetCache()
        {
            handHistoriesCache.Clear();
        }

        private XmlDocument GetExistingHandHistory(string handHistoryFile)
        {
            if (handHistoriesCache.ContainsKey(handHistoryFile))
            {
                return handHistoriesCache[handHistoryFile];
            }

            if (File.Exists(handHistoryFile))
            {
                var existing = new XmlDocument();
                existing.PreserveWhitespace = true;
                existing.Load(handHistoryFile);

                return existing;
            }

            return null;
        }

        private static void UpdateExistingNodeText(XmlDocument xmlDocument, XmlDocument existingXmlDocument, string tagName)
        {
            var node = xmlDocument.SelectSingleNode(tagName);
            var existingNode = existingXmlDocument.SelectSingleNode(tagName);

            if (node != null && existingNode != null && !node.InnerText.Equals(existingNode.InnerText, StringComparison.Ordinal))
            {
                existingNode.InnerText = node.InnerText;
            }
        }

        private static bool HandExists(XmlDocument handHistory, string handNumber)
        {
            var xpath = string.Format("//session/game[@gamecode='{0}']", handNumber);

            var gameNode = handHistory.SelectSingleNode(xpath);

            return gameNode != null;
        }
    }
}