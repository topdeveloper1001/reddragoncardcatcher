//-----------------------------------------------------------------------
// <copyright file="BaseTest.cs" company="Ace Poker Solutions">
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
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using NSubstitute;
using NUnit.Framework;
using RedDragonCardCatcher.Licensing;
using RedDragonCardCatcher.Settings;
using RedDragonCardCatcher.Tests.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RedDragonCardCatcher.Tests
{
    internal abstract class BaseTest
    {
        protected const string TestDataFolder = @"..\..\TestData";  

        [OneTimeSetUp]
        public virtual void SetUp()
        {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;

            var unityContainer = new UnityContainer();

            var licenseService = Substitute.For<ILicenseService>();
            licenseService.IsMatch(Arg.Any<HandHistory>()).Returns(true);

            unityContainer.RegisterInstance(licenseService);

            var settingsService = Substitute.For<ISettingsService>();
            settingsService.GetSettings().Returns(x => new SettingsModel());

            unityContainer.RegisterInstance(settingsService);

            var locator = new UnityServiceLocator(unityContainer);

            ServiceLocator.SetLocatorProvider(() => locator);
        }

        protected List<byte[]> ReadCapturedPackets(string file, string dateFormat)
        {
            file = Path.Combine(TestDataFolder, file);
            return PacketsUtils.ReadCapturedPackets(file, dateFormat);
        }

        protected byte[] ReadPacketFile(string file)
        {
            file = Path.Combine(TestDataFolder, file);

            FileAssert.Exists(file, $"{file} doesn't exist");

            var fileText = File.ReadAllText(file);

            Assert.IsNotEmpty(fileText, $"{file} is empty");

            var bytes = fileText.FromHexStringToBytes();
            return bytes;
        }

        protected List<T> GetPackageTypeList<T>(string file)
        {
            file = Path.Combine(TestDataFolder, file);

            FileAssert.Exists(file);

            var commands = File.ReadAllLines(file)
                .Select(x => (T)Enum.Parse(typeof(T), x))
                .ToList();

            return commands;
        }
    }
}