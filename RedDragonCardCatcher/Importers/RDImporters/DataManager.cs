//-----------------------------------------------------------------------
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
        private const string key = "82yz1tqyodnl7wlk";
        private const string iv = "8gw9gz6cknqgvqsw";
        private readonly AesManaged aesCryptoProvider;
        private readonly ICryptoTransform decryptor;

        public DataManager()
        {
            aesCryptoProvider = new AesManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                IV = Encoding.UTF8.GetBytes(iv)
            };

            decryptor = aesCryptoProvider.CreateDecryptor();
        }

        public byte[] ProcessData(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                return null;
            }

            try
            {
                var dataBase64String = Encoding.UTF8.GetString(data).Trim();

                try
                {
                    var decryptedBase64String = Decrypt(dataBase64String);
                    return Convert.FromBase64String(decryptedBase64String);
                }
                catch (FormatException e)
                {
#if DEBUG
                    LogProvider.Log.Error(this, $"Failed to process data '{dataBase64String}'.", e);
#endif                
                    return null;
                }
            }
            catch (Exception e)
            {
                LogProvider.Log.Error(this, $"Failed to process data.", e);
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
            return encryptedText;

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
                LogProvider.Log.Error($"Failed to decrypt data: {encryptedText}");
#else
                LogProvider.Log.Error("Failed to decrypt data.");
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