using BridgeInternationalAcademies.Models.BatteryUsage;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BridgeInternationalAcademies.Common.JsonConverter
{
    public class JsonConverter: IJsonConverter
    {
        public async Task<IEnumerable<BatteryUsageDetails>> MapJsonFileToObject(string fileName)
        {
            IEnumerable<BatteryUsageDetails> batteryUsageDetailsList;
            using (FileStream fs = File.OpenRead(fileName))
            {
                batteryUsageDetailsList = await JsonSerializer.DeserializeAsync<IList<BatteryUsageDetails>>(fs);
            }
            return batteryUsageDetailsList;
        }
    }
}
