using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BridgeInternationalAcademies.BAL.Interfaces;
using BridgeInternationalAcademies.Data.Core.Interfaces;
using BridgeInternationalAcademies.Models.BatteryUsage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BridgeInternationalAcademies.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteryUsageController : ControllerBase
    {
        private readonly IBatteryUsageService _batteryUsageService;

        public BatteryUsageController(IBatteryUsageService batteryUsageService)
        {
            _batteryUsageService = batteryUsageService;
        }

        // GET: api/BatteryUsage
        [HttpGet]
        public async Task<IDataResult<IEnumerable<DailyBatteryUsage>>> GetAsync()
        {
            return await _batteryUsageService.GetAvgDailyBatteryUsage();
        }
    }
}
