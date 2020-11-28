using BridgeInternationalAcademies.BAL.Interfaces;
using BridgeInternationalAcademies.BAL.Services;
using BridgeInternationalAcademies.Common.JsonConverter;
using BridgeInternationalAcademies.Data;
using BridgeInternationalAcademies.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BridgeInternationalAcademies.WebAPI.Tests.Controllers
{
    [TestClass]
    public class BatteryUsageControllerTest
    {

        private Mock<IBatteryUsageService> _batteryUsageService;
        private BatteryUsageController _controller;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            _batteryUsageService = new Mock<IBatteryUsageService>();
            _controller = new BatteryUsageController(_batteryUsageService.Object);
        }

        [TestMethod]
        public async Task GetBatteryUsageDetails_Ok()
        {
            //Arrange
            var jsonConverter = new JsonConverter();
            var batteryUsageService = new BatteryUsageService(jsonConverter);
            var batteryUsageController = new BatteryUsageController(batteryUsageService);

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "BridgeInternationalAcademies.Data/JsonData/BatteryUsage"));
            var sourcePath = Path.GetFullPath("../../../../BridgeInternationalAcademies.Data/JsonData/BatteryUsage");
            var targetPath = Path.Combine(Directory.GetCurrentDirectory(), "../BridgeInternationalAcademies.Data/JsonData/BatteryUsage");

            string sourceFile = System.IO.Path.Combine(sourcePath, "battery.json");
            string destFile = System.IO.Path.Combine(targetPath, "battery.json");

            File.Copy(sourceFile, destFile, true);

            //Act
            var result = await batteryUsageController.GetAsync();

            //Assert
            Assert.IsTrue(result.Info.ResultCode == Data.Core.Enums.ResultCode.Success);
        }

    }
}
