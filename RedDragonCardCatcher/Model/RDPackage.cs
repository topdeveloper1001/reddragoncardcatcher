//-----------------------------------------------------------------------
// <copyright file="IRDImporter.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using ProtoBuf;
using System;
using System.Linq;
using System.Text;

namespace RedDragonCardCatcher.Model
{
    [ProtoContract]
    internal class RDPackage
    {
        [ProtoMember(1)]
        public RDPackageType PackageType { get; set; }

        [ProtoMember(2)]
        public byte[] Body { get; set; }

        public static bool TryParse(byte[] data, out RDPackage package)
        {
            package = null;

            if (data == null ||
                data.Length < 6)
            {
                return false;
            }

            try
            {
                var payloadLengthBytes = data.Take(4).ToArray();

                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(payloadLengthBytes);
                }

                var payloadLength = BitConverter.ToInt32(payloadLengthBytes, 0);

                // 5th bytes contains length of package type
                var packageTypeLength = data[4];

                if (data.Length < packageTypeLength + payloadLength + 5)
                {
                    return false;
                }

                var packageTypeBytes = data.Skip(5).Take(packageTypeLength).ToArray();
                var packageTypeString = Encoding.ASCII.GetString(packageTypeBytes);

                if (!Enum.TryParse(packageTypeString, out RDPackageType packageType))
                {
                    return false;
                }

                var body = data.Skip(5 + packageTypeLength).Take(payloadLength).ToArray();

                package = new RDPackage
                {
                    PackageType = packageType,
                    Body = body
                };

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}