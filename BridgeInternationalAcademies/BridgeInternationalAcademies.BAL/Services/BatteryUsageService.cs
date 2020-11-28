using BridgeInternationalAcademies.BAL.Interfaces;
using BridgeInternationalAcademies.Common.JsonConverter;
using BridgeInternationalAcademies.Data;
using BridgeInternationalAcademies.Data.Core.Interfaces;
using BridgeInternationalAcademies.Data.Core.Models;
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

        public async Task<IDataResult<IEnumerable<DailyBatteryUsage>>> GetAvgDailyBatteryUsage()
        {

            try
            {
                var batteryUsageDetailsList = await _jsonConverter.MapJsonFileToObject(Constants.BATTERY_USAGE_JSON_FILE_PATH);
                var dailyBatteryUsageList = await CalculateAvgDailyBatteryUsage(batteryUsageDetailsList);
                return new DataResult<IEnumerable<DailyBatteryUsage>>(dailyBatteryUsageList);
            }
            catch(Exception ex)
            {
                return new DataResult<IEnumerable<DailyBatteryUsage>>(Data.Core.Enums.ResultCode.Error, ex.Message, null);
            }
            
        }

        private async Task<IEnumerable<DailyBatteryUsage>> CalculateAvgDailyBatteryUsage(IEnumerable<BatteryUsageDetails> batteryUsageDetailsList)
        {
            var dailyBatteryUsageList = new List<DailyBatteryUsage>();

            // Sort and Aggregate the list based on Serial Number
            var batteryUsageListByDevice = batteryUsageDetailsList.OrderBy(x => x.SerialNumber).ThenBy(x => x.Timestamp)
                                                .GroupBy(x => x.SerialNumber)
                                                .Select(grp => new
                                                {
                                                    SerialNumber = grp.Key,
                                                    BatterySnapshots = grp.ToList()
                                                });

            foreach (var device in batteryUsageListByDevice)
            {
                var dailyBatteryUsage = new DailyBatteryUsage();

                dailyBatteryUsage.SerialNumber = device.SerialNumber;
                dailyBatteryUsage.AvgDailyBatteryUsage = device.BatterySnapshots.Count > 1 ? await GetAvgBatteryUsagePerDevice(device.BatterySnapshots) : null;

                dailyBatteryUsageList.Add(dailyBatteryUsage);
            }
            return dailyBatteryUsageList;
        }

        private async Task<double?> GetAvgBatteryUsagePerDevice(IEnumerable<BatteryUsageDetails> batterySnapshotsByDevice)
        {
            double batteryUsed = 0;
            DateTime initialTimestamp, finalTimestamp;
            BatteryUsageDetails lastRecordedSnapshot = null;

            initialTimestamp = finalTimestamp = batterySnapshotsByDevice.FirstOrDefault().Timestamp;
            foreach (var snapshot in batterySnapshotsByDevice)
            {
                if (lastRecordedSnapshot != null)
                {
                    if (lastRecordedSnapshot.BatteryLevel > snapshot.BatteryLevel)
                    {
                        batteryUsed += lastRecordedSnapshot.BatteryLevel - snapshot.BatteryLevel;
                        finalTimestamp = snapshot.Timestamp;
                    }
                }
                lastRecordedSnapshot = snapshot;
            }
            var hourslogged = (finalTimestamp - initialTimestamp).TotalHours;
            return await Task.FromResult(hourslogged != 0 ? (double?)Math.Round(batteryUsed / hourslogged * 24, 2, MidpointRounding.AwayFromZero) : null);
        }
    }
}
