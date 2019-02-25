//-----------------------------------------------------------------------
// <copyright file="RDHandBuilderTests.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using HandHistories.Objects.Hand;
using Microsoft.QualityTools.Testing.Fakes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using ProtoBuf;
using RedDragonCardCatcher.Common.Extensions;
using RedDragonCardCatcher.Common.Linq;
using RedDragonCardCatcher.Common.Log;
using RedDragonCardCatcher.Importers;
using RedDragonCardCatcher.Model;
using RedDragonCardCatcher.Services;
using RedDragonCardCatcher.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Fakes;
using System.IO;
using System.Reflection;

namespace RedDragonCardCatcher.Tests
{
    [TestFixture]
    class RDHandBuilderTests : BaseTest
    {
        private const string SourceJsonFile = "Source.json";
        private const string ExpectedResultFile = "Result.xml";

        private IRDCCLog testLogger;

        private Dictionary<RDPackageType, MethodInfo> BuildPackageMapping { get; } = new Dictionary<RDPackageType, MethodInfo>();

        public override void SetUp()
        {
            base.SetUp();

            testLogger = new TestLogger();
            LogProvider.SetCustomLogger(testLogger);

            RDPackageTypeEnumerator.ForEach((RDPackageType enumValue, Type packageObjectType) =>
            {
                Func<RDTestSourcePacket, RDPackage> func = BuildPackage<JoinRoomResponse>;
                MethodInfo method = func.Method.GetGenericMethodDefinition();
                MethodInfo generic = method.MakeGenericMethod(packageObjectType);

                BuildPackageMapping[enumValue] = generic;
            });

            try
            {
                if (Directory.Exists(HandHistoryFileService.HandHistoryFolder))
                {
                    Directory.EnumerateFiles(HandHistoryFileService.HandHistoryFolder).ForEach(x => File.Delete(x));
                }
            }
            catch
            {
            }
        }

        [TestCase(@"HandsRawData\nlh-9-max-no-hero")]
        public void TryBuildTest(string testFolder)
        {
            var packages = ReadPackages(testFolder);

            CollectionAssert.IsNotEmpty(packages, $"Packages collection must be not empty for {testFolder}");

            var handBuilder = new RDHandBuilder();

            Build(handBuilder, packages, out HandHistory actual);

            Assert.IsNotNull(actual, $"Actual HandHistory must be not null for {testFolder}");

            var expected = ReadExpectedHandHistory(testFolder);

            Assert.IsNotNull(expected, $"Expected HandHistory must be not null for {testFolder}");

            AssertionUtils.AssertHandHistory(actual, expected);
        }

        private void Build(RDHandBuilder builder, IEnumerable<RDPackage> packages, out HandHistory history)
        {
            history = null;

            var hwnd = new IntPtr(1101);

            foreach (var package in packages)
            {
                using (ShimsContext.Create())
                {
                    ShimDateTime.UtcNowGet = () => package.Timestamp;

                    if (builder.TryBuild(package, hwnd, out history))
                    {
                        break;
                    }
                }
            }
        }

        private HandHistory ReadExpectedHandHistory(string folder)
        {
            var xmlFile = Path.Combine(TestDataFolder, folder, ExpectedResultFile);

            FileAssert.Exists(xmlFile);

            try
            {
                var handHistoryText = File.ReadAllText(xmlFile);
                return SerializationHelper.DeserializeObject<HandHistory>(handHistoryText);
            }
            catch (Exception e)
            {
                Assert.Fail($"{ExpectedResultFile} in {folder} has not been deserialized: {e}");
            }

            return null;
        }

        private IEnumerable<RDPackage> ReadPackages(string folder)
        {
            var packages = new List<RDPackage>();

            var jsonFile = Path.Combine(TestDataFolder, folder, SourceJsonFile);

            FileAssert.Exists(jsonFile);

            RDTestSourceObject testSourceObject = null;

            try
            {
                var jsonFileContent = File.ReadAllText(jsonFile);
                testSourceObject = JsonConvert.DeserializeObject<RDTestSourceObject>(jsonFileContent, new StringEnumConverter());
            }
            catch (Exception e)
            {
                Assert.Fail($"{ExpectedResultFile} in {folder} has not been deserialized: {e}");
            }

            Assert.IsNotNull(testSourceObject);

            foreach (var packet in testSourceObject.Packets)
            {
                RDPackage package = null;

                if (BuildPackageMapping.ContainsKey(packet.PackageType))
                {
                    package = (RDPackage)BuildPackageMapping[packet.PackageType].Invoke(this, new object[] { packet });
                    package.Timestamp = packet.Time.ToUniversalTime();
                }

                Assert.IsNotNull(package);

                packages.Add(package);
            }

            return packages;
        }

        private RDPackage BuildPackage<T>(RDTestSourcePacket packet)
        {
            var contentObject = JsonConvert.DeserializeObject<T>(packet.Content.ToString(), new StringEnumConverter());

            Assert.IsNotNull(contentObject, $"Content object of {typeof(T)} must be not null.");

            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, contentObject);
                var bytes = ms.ToArray();

                var package = new RDPackage
                {
                    PackageType = packet.PackageType,
                    Body = bytes,
                    Timestamp = packet.Time.ToUniversalTime()
                };

                return package;
            }
        }

        private class RDTestSourceObject
        {
            public IEnumerable<RDTestSourcePacket> Packets { get; set; }
        }

        private class RDTestSourcePacket
        {
            public RDPackageType PackageType { get; set; }

            public DateTime Time { get; set; }

            public object Content { get; set; }
        }

        private class TestLogger : IRDCCLog
        {
            public void Log(Type senderType, object message, LogMessageType logMessageType)
            {
                Console.WriteLine(message);
            }

            public void Log(Type senderType, object message, Exception exception, LogMessageType logMessageType)
            {
                Console.WriteLine(message);
                Console.WriteLine(exception);
            }

            public void Log(string loggerName, object message, LogMessageType logMessageType)
            {
                Console.WriteLine(message);
            }

            public void Log(string loggerName, object message, Exception exception, LogMessageType logMessageType)
            {
                Console.WriteLine(message);
            }
        }
    }
}