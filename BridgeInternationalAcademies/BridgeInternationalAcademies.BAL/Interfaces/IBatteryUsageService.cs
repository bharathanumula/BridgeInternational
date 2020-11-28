using BridgeInternationalAcademies.Data.Core.Interfaces;
using BridgeInternationalAcademies.Models.BatteryUsage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BridgeInternationalAcademies.BAL.Interfaces
{
    public interface IBatteryUsageService
    {
        Task<IDataResult<IEnumerable<DailyBatteryUsage>>> GetAvgDailyBatteryUsage();
    }
}
