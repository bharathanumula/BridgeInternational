using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace BridgeInternationalAcademies.Common.Tests.JsonConverter
{
    [TestClass]
    public class JsonConverterTest
    {
        [TestMethod]
        public async Task MapJsonFileToObject_ValidJsonFile_Ok()
        {
            //Arrange
            var jsonConverter = new Common.JsonConverter.JsonConverter();
            const string VALID_JSON_FILE_PATH = "../../../../BridgeInternationalAcademies.Data/JsonData/BatteryUsage/battery.json";
            //Act
            var result = await jsonConverter.MapJsonFileToObject(VALID_JSON_FILE_PATH);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task MapJsonFileToObject_InvalidJsonFilePath_ThrowException()
        {
            //Arrange
            var jsonConverter = new Common.JsonConverter.JsonConverter();
            const string INVALID_JSON_FILE_PATH = "abc.json";

            //Act
            var result = await jsonConverter.MapJsonFileToObject(INVALID_JSON_FILE_PATH);
        }
    }
}
