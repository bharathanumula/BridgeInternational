using BridgeInternationalAcademies.Models.BatteryUsage;
using System;
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
            try
            {
                using (FileStream fs = File.OpenRead(fileName))
                {
                    batteryUsageDetailsList = await JsonSerializer.DeserializeAsync<IList<BatteryUsageDetails>>(fs);
                }
            }
            catch(FileNotFoundException ex)
            {
                throw new Exception($"Error while coverting the json: {ex.Message}");
            }
            catch(Exception ex)
            {
                throw;
            }
            
            return batteryUsageDetailsList;
        }
    }
}
