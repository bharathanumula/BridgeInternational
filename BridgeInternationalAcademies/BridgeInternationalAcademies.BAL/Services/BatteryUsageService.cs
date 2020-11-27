using BridgeInternationalAcademies.BAL.Interfaces;
using BridgeInternationalAcademies.Common.JsonConverter;
using BridgeInternationalAcademies.Data;
using BridgeInternationalAcademies.Models.BatteryUsage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeInternationalAcademies.BAL.Services
{
    public class BatteryUsageService: IBatteryUsageService
    {
        private readonly IJsonConverter _jsonConverter;

        public BatteryUsageService(IJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

        public async Task<IEnumerable<DailyBatteryUsage>> GetAvgDailyBatteryUsage()
        {
            var dailyBatteryUsageList = new List<DailyBatteryUsage>();
            //dailyBatteryUsageList.Add(new DailyBatteryUsage
            //{
            //    SerialNumber = "A123",
            //    AvgDailyBatteryUsage = 1.5m
            //});

            //Convert json to list
            var batteryUsageDetailsList = await _jsonConverter.MapJsonFileToObject(Constants.BATTERY_USAGE_JSON_FILE_PATH);

            // Aggregate the list based on Serial Number
            var batteryUsageListByDevice = batteryUsageDetailsList.OrderBy(x => x.SerialNumber).ThenBy(x => x.Timestamp).GroupBy(x => x.SerialNumber).ToArray();

            foreach (var deviceList in batteryUsageListByDevice)
            {
                var dailyBatteryUsage = new DailyBatteryUsage();
                dailyBatteryUsage.SerialNumber = deviceList.Key;
                var xyz = deviceList.ToList();
                xyz.Skip(1).Where(x => x.BatteryLevel >= xyz.IndexOf(x));
            }

            //For each group, get average data

            return await Task.FromResult(dailyBatteryUsageList);
        }
    }
}
