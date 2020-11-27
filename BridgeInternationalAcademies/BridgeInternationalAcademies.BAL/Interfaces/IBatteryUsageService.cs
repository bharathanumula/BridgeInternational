using BridgeInternationalAcademies.Models.BatteryUsage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BridgeInternationalAcademies.BAL.Interfaces
{
    public interface IBatteryUsageService
    {
        Task<IEnumerable<DailyBatteryUsage>> GetAvgDailyBatteryUsage();
    }
}
