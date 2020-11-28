using BridgeInternationalAcademies.BAL.Services;
using BridgeInternationalAcademies.Models.BatteryUsage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeInternationalAcademies.BAL.Tests.Services
{
    [TestClass]
    public class BatteryUsageServiceTest
    {
        private Mock<BridgeInternationalAcademies.Common.JsonConverter.IJsonConverter> _jsonConverter;
        private BatteryUsageService _batteryUsageService;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            _jsonConverter = new Mock<BridgeInternationalAcademies.Common.JsonConverter.IJsonConverter>();
            _batteryUsageService = new BatteryUsageService(_jsonConverter.Object);
        }

        [TestMethod]
        public async Task GetBatteryUsageDetails_Ok()
        {
            //Arrange
            var batteryUsageDetailsList = new List<BatteryUsageDetails>();
            batteryUsageDetailsList.Add(new BatteryUsageDetails
            {
                AcademyId = 1,
                SerialNumber = "A123",
                BatteryLevel = 1,
                EmployeeId = "123",
                Timestamp = DateTime.Now
            });

            _jsonConverter.Setup(x => x.MapJsonFileToObject(string.Empty)).Returns(Task.FromResult((IEnumerable<BatteryUsageDetails>)batteryUsageDetailsList));

            //Act
            var result = await _batteryUsageService.GetAvgDailyBatteryUsage();

            //Assert
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public async Task GetBatteryUsageDetails_OnlyOneRecord_ReturnsNULL()
        {
            //Arrange
            var batteryUsageDetailsList = new List<BatteryUsageDetails>();
            batteryUsageDetailsList.Add(new BatteryUsageDetails
            {
                AcademyId = 1,
                BatteryLevel = 1,
                EmployeeId = "123",
                SerialNumber = "A123",
                Timestamp = DateTime.Now
            });

            _jsonConverter.Setup(x => x.MapJsonFileToObject(It.IsAny<string>())).ReturnsAsync(batteryUsageDetailsList);

            //Act
            var result = await _batteryUsageService.GetAvgDailyBatteryUsage();

            //Assert
            Assert.IsNotNull(result.Data);
            Assert.IsNull(result.Data.FirstOrDefault().AvgDailyBatteryUsage);
        }

        [TestMethod]
        public async Task GetBatteryUsageDetails_ValidRecords_ReturnsAppropriateValue()
        {
            //Arrange
            var batteryUsageDetailsList = new List<BatteryUsageDetails>();
            batteryUsageDetailsList.Add(new BatteryUsageDetails
            {
                AcademyId = 1,
                BatteryLevel = 1,
                EmployeeId = "123",
                SerialNumber = "A123",
                Timestamp = new DateTime(2019,5,19,1,0,0)
            });;
            batteryUsageDetailsList.Add(new BatteryUsageDetails
            {
                AcademyId = 1,
                BatteryLevel = 0.9,
                EmployeeId = "123",
                SerialNumber = "A123",
                Timestamp = new DateTime(2019, 5, 19, 2, 0, 0)
            });
            batteryUsageDetailsList.Add(new BatteryUsageDetails
            {
                AcademyId = 1,
                BatteryLevel = 1,
                EmployeeId = "123",
                SerialNumber = "A123",
                Timestamp = new DateTime(2019, 5, 19, 3, 0, 0)
            });
            batteryUsageDetailsList.Add(new BatteryUsageDetails
            {
                AcademyId = 1,
                BatteryLevel = 0.7,
                EmployeeId = "123",
                SerialNumber = "A123",
                Timestamp = new DateTime(2019, 5, 19, 4, 0, 0)
            });

            _jsonConverter.Setup(x => x.MapJsonFileToObject(It.IsAny<string>())).ReturnsAsync(batteryUsageDetailsList);

            //Act
            var result = await _batteryUsageService.GetAvgDailyBatteryUsage();

            //Assert
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(3.2, result.Data.FirstOrDefault().AvgDailyBatteryUsage);
        }
    }
}
