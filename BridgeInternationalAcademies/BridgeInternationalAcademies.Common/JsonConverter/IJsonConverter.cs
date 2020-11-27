using BridgeInternationalAcademies.Models.BatteryUsage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BridgeInternationalAcademies.Common.JsonConverter
{
    public interface IJsonConverter
    {
        Task<IEnumerable<BatteryUsageDetails>> MapJsonFileToObject(string fileName);
    }
}
