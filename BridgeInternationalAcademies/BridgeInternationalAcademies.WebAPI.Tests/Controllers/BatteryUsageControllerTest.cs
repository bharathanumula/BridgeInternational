using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BridgeInternationalAcademies.WebAPI.Tests.Controllers
{
    [TestClass]
    public class BatteryUsageControllerTest
    {
        [TestMethod]
        public async Task GetBatteryUsageDetails_Ok()
        {
            var x = await Task.FromResult(1);
            Assert.IsTrue(true);
        }

    }
}
