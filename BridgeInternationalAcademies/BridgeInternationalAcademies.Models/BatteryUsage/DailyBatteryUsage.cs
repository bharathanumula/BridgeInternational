using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeInternationalAcademies.Models.BatteryUsage
{
    public class DailyBatteryUsage
    {
        public string SerialNumber { get; set; }

        public decimal AvgDailyBatteryUsage { get; set; }
    }
}
