﻿//-----------------------------------------------------------------------
// <copyright file="DataManager.cs" company="Ace Poker Solutions">
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
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RedDragonCardCatcher.Importers
{
    /// <summary>
    /// Data manager to process pipe data
    /// </summary>
    internal sealed class DataManager : IDataManager
    {
        private IProtectedLogger protectedLogger;
        private readonly IRDImporter importer;

        private AesManaged aesCryptoProvider;
        private ICryptoTransform decryptor;
        private const string key = "82yz1tqyodnl7wlk";
        private const string iv = "8gw9gz6cknqgvqsw";

        public DataManager()
        {
            var importerService = ServiceLocator.Current.GetInstance<IImporterService>();
            importer = importerService.GetImporter<IRDImporter>();
        }

        /// <summary>
        /// Initializes data manager
        /// </summary>
        /// <param name="logger">External protected logger to log data</param>
        public void Initialize(IProtectedLogger logger)
        {
            protectedLogger = logger;

            if (aesCryptoProvider != null)
            {
                return;
            }

            aesCryptoProvider = new AesManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                IV = Encoding.UTF8.GetBytes(iv)
            };

            decryptor = aesCryptoProvider.CreateDecryptor();
        }

        /// <summary>
        /// Processes incoming data
        /// </summary>
        /// <param name="data">Data to process</param>
        public void ProcessData(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                return;
            }

            var decodedData = ConvertData(data);

            if (decodedData == null)
            {
                return;
            }

            // Log stream data
            protectedLogger?.Log(Convert.ToBase64String(decodedData));

            // send data to importer 
            importer.AddPackage(decodedData);
        }

        /// <summary>
        /// Converts raw data to string
        /// </summary>
        /// <param name="data">Data to convert</param>
        /// <returns>The result of conversion</returns>
        private byte[] ConvertData(byte[] data)
        {
            try
            {
                var base64String = Encoding.UTF8.GetString(data).Trim();

                try
                {
                    return Convert.FromBase64String(base64String);
                }
                catch (FormatException e)
                {
                    LogProvider.Log.Error(this, $"Failed to decode base64 string from '{base64String}'", e);
                    return null;
                }
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to convert raw data to string.", e);
                return null;
            }
        }

        /// <summary>
        /// Decrypts specified text
        /// </summary>
        /// <param name="encryptedText">Text to decrypt</param>
        /// <returns>Decrypted text</returns>
        private string Decrypt(string encryptedText)
        {
            try
            {
                var encryptedData = Convert.FromBase64String(encryptedText);

                var decryptedData = string.Empty;

                using (var msDecrypt = new MemoryStream(encryptedData))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var swDecrypt = new StreamReader(csDecrypt, Encoding.UTF8))
                        {
                            decryptedData = swDecrypt.ReadToEnd();
                        }
                    }
                }

                return decryptedData;
            }
            catch (Exception e)
            {
#if DEBUG
                LogProvider.Log.Error($"Failed to process pipe data: {encryptedText}");
#else
                LogProvider.Log.Error("Failed to process pipe data.");
#endif            
                throw e;
            }
        }

        /// <summary>
        /// Disposes managed resources
        /// </summary>
        public void Dispose()
        {
            decryptor?.Dispose();
            aesCryptoProvider?.Dispose();
        }
    }
}