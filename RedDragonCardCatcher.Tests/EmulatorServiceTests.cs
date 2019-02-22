//-----------------------------------------------------------------------
// <copyright file="EmulatorServiceTests.cs" company="Ace Poker Solutions">
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
using RedDragonCardCatcher.Importers;
using System.Collections.Generic;
using System.Linq;

namespace RedDragonCardCatcher.Tests
{
    [TestFixture]
    internal class EmulatorServiceTests
    {
        /// <summary>
        /// Tests whenever emulators are correctly identified, this tests requires to run emulators manually, 
        /// then set correct pids and identifiers for test data set, so it can be used in automated test suit, but can be used for debugging purpose
        /// </summary>
        // [TestCaseSource("GetEmulatorsTestData")]
        public void EmulatorsAreIdentified(List<ExpectedEmulatorInfo> expectedEmulatorInfos)
        {
            var emulatorService = new EmulatorServiceStub();
            emulatorService.DoImport();

            Assert.Multiple(() =>
            {
                var actualEmulators = emulatorService.Emulators.OrderBy(x => x.Process.Id).ToArray();
                expectedEmulatorInfos = expectedEmulatorInfos.OrderBy(x => x.ProcessId).ToList();

                Assert.That(actualEmulators.Length, Is.EqualTo(expectedEmulatorInfos.Count));

                for (var i = 0; i < actualEmulators.Length; i++)
                {
                    Assert.That(actualEmulators[i].Process.Id, Is.EqualTo(expectedEmulatorInfos[i].ProcessId), "Processes id must match");
                    Assert.That(actualEmulators[i].EmulatorProcess.Id, Is.EqualTo(expectedEmulatorInfos[i].EmulatorProcessId), "Emulator processes id must match");
                    Assert.That(actualEmulators[i].AdbIdentifier, Is.EqualTo(expectedEmulatorInfos[i].Identifier), "Adb identifiers must match");
                }
            });
        }

        public static IEnumerable<TestCaseData> GetEmulatorsTestData()
        {
            yield return new TestCaseData(
                    new List<ExpectedEmulatorInfo>
                    {
                        // Expected emulator 1
                        new ExpectedEmulatorInfo
                        {
                            ProcessId = 27396,
                            EmulatorProcessId = 19444,
                            Identifier = "127.0.0.1:5555"
                        },
                         // Expected emulator 2
                        new ExpectedEmulatorInfo
                        {
                            ProcessId = 23392,
                            EmulatorProcessId = 5844,
                            Identifier = "127.0.0.1:5557"
                        }
                    }
                ).SetName("EmulatorsAreIdentified");
        }

        private class EmulatorServiceStub : EmulatorService
        {
            public new void DoImport()
            {
                UpdateEmulators();
                IdentifyEmulators();
            }

            public EmulatorInfo[] Emulators
            {
                get
                {
                    return activeEmulators.Values.ToArray();
                }
            }
        }

        public class ExpectedEmulatorInfo
        {
            public int ProcessId { get; set; }

            public int EmulatorProcessId { get; set; }

            public string Identifier { get; set; }
        }
    }
}