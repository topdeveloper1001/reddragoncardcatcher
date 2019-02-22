//-----------------------------------------------------------------------
// <copyright file="RDPackageTests.cs" company="Ace Poker Solutions">
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
using RedDragonCardCatcher.Common.Extensions;
using RedDragonCardCatcher.Model;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RedDragonCardCatcher.Tests
{
    [TestFixture]
    internal class RDPackageTests : BaseTest
    {
        private Dictionary<RDPackageType, MethodInfo> LogPackageMapping { get; } = new Dictionary<RDPackageType, MethodInfo>();

        public override void SetUp()
        {
            base.SetUp();

            RDPackageTypeEnumerator.ForEach((RDPackageType enumValue, Type packageObjectType) =>
            {
                Action<RDPackage> action = AssertPackage<HeartbeatResponse>;
                MethodInfo method = action.Method.GetGenericMethodDefinition();
                MethodInfo generic = method.MakeGenericMethod(packageObjectType);

                LogPackageMapping[enumValue] = generic;
            });
        }

        [TestCase(@"Packets\PlayerCallResponse.txt", RDPackageType.PlayerCallResponse, 56)]
        public void TestParseSingleTest(string file, RDPackageType packageType, int expectedPayloadLength)
        {
            var data = ReadPacketFile(file);

            Assert.True(RDPackage.TryParse(data, out RDPackage package), $"Data must be parsed");
            Assert.That(package.PackageType, Is.EqualTo(packageType));
            Assert.That(package.Body.Length, Is.EqualTo(expectedPayloadLength));
        }

        [TestCase(@"Packets\Raw-Log-1.txt", @"Packets\Raw-Log-1-pkg.txt")]
        public void TryParseTest(string file, string expectedPackageTypesFile)
        {
            var packets = ReadCapturedPackets(file, null);

            var expectedPackageTypes = !string.IsNullOrEmpty(expectedPackageTypesFile) ?
                    GetPackageTypeList<RDPackageType>(expectedPackageTypesFile) :
                    new List<RDPackageType>();

            var expectedCommandsIndex = 0;

            foreach (var packet in packets)
            {
                if (RDPackage.TryParse(packet, out RDPackage package))
                {
                    Console.WriteLine(package.PackageType);

                    if (expectedPackageTypes.Count > 0)
                    {
                        Assert.That(package.PackageType, Is.EqualTo(expectedPackageTypes[expectedCommandsIndex++]));
                        AssertPackage(package);
                    }
                }
            }
        }

        private void AssertPackage(RDPackage package)
        {
            switch (package.PackageType)
            {

                //case PackageType.LeaveRoomRSP:
                //    AssertPackage<LeaveRoomRSP>(package, capturedPacket);
                //    break;
            }
        }

        private void AssertPackage<T>(RDPackage package)
        {
            Assert.IsTrue(
                SerializationHelper.TryDeserialize(package.Body, out T packageContent),
                $"Failed to deserialize {package.PackageType} package");
        }
    }
}