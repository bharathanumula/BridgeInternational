using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BridgeInternationalAcademies.BAL.Interfaces;
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
        public async Task<IEnumerable<DailyBatteryUsage>> GetAsync()
        {
            return await _batteryUsageService.GetAvgDailyBatteryUsage();
        }

        // GET: api/BatteryUsage/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BatteryUsage
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/BatteryUsage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
