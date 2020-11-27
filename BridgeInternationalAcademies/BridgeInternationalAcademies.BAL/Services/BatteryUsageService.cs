using BridgeInternationalAcademies.BAL.Interfaces;
using BridgeInternationalAcademies.Models.BatteryUsage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BridgeInternationalAcademies.BAL.Services
{
    public class BatteryUsageService: IBatteryUsageService
    {
        public BatteryUsageService()
        {

        }

        public async Task<IEnumerable<DailyBatteryUsage>> GetAvgDailyBatteryUsage()
        {
            var dailyBatteryUsageList = new List<DailyBatteryUsage>();
            dailyBatteryUsageList.Add(new DailyBatteryUsage
            {
                SerialNumber = "A123",
                AvgDailyBatteryUsage = 1.5m
            });

            //Convert json to list
            // Aggregate the list based on Serial Number
            //For each group, get average data

            return await Task.FromResult(dailyBatteryUsageList);
        }
    }
}
