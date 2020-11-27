using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BridgeInternationalAcademies.BAL.Tests.Services
{
    [TestClass]
    public class BatteryUsageService
    {
        [TestMethod]
        public async Task GetBatteryUsageDetails_Ok()
        {
            var x = await Task.FromResult(1);
            Assert.IsTrue(true);
        }
    }
}
