using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BridgeInternationalAcademies.Models.BatteryUsage
{
    public class BatteryUsageDetails
    {
        [JsonPropertyName("academyId")]
        public int AcademyId { get; set; }

        [JsonPropertyName("batteryLevel")]
        public double BatteryLevel { get; set; }

        [JsonPropertyName("employeeId")]
        public string EmployeeId { get; set; }

        [JsonPropertyName("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
