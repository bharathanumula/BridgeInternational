using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeInternationalAcademies.Models.BatteryUsage
{
    public class BatteryUsageDetails
    {
        public int AcademyId { get; set; }

        public decimal BatteryLevel { get; set; }

        public string EmployeeId { get; set; }

        public string SerialNumber { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
