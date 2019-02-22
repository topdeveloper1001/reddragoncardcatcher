//-----------------------------------------------------------------------
// <copyright file="PacketsUtils.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using NUnit.Framework;
using RedDragonCardCatcher.Tests.Utils;
using System.Collections.Generic;
using System.IO;

namespace RedDragonCardCatcher.Tests
{
    internal class PacketsUtils
    {
        public static List<byte[]> ReadCapturedPackets(string file, string dateFormat)
        {
            FileAssert.Exists(file);

            var lines = File.ReadAllLines(file);

            bool isBody = false;

            var capturedPackets = new List<byte[]>();

            foreach (var line in lines)
            {               
                if (line.IndexOf("-body begin-") > 0)
                {
                    isBody = true;
                    continue;
                }

                if (line.IndexOf("-body end-") > 0)
                {
                    isBody = false;
                    continue;
                }

                if (isBody)
                {
                    capturedPackets.Add(line.FromHexStringToBytes());                    
                }           
            }
          
            return capturedPackets;
        }     
    }
}