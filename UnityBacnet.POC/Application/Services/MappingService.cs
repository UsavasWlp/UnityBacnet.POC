using System;
using System.Collections.Generic;
using System.Text;
using UnityBacnet.POC.Domain;

namespace UnityBacnet.POC.Application.Services
{
    public class MappingService
    {
        public UnityAssetReading Map(DeviceWithReading device)
        {
            return new UnityAssetReading
            {
                AssetId = device.DeviceId, // for now direct
                AssetType = MapDeviceType(device.Name),
                Value = device.Temperature,
                ReadingType = "Temperature",
                HasAlarm = device.HasAlarm
            };
        }

        private string MapDeviceType(string name)
        {
            if (name.Contains("RTU"))
                return "HVAC";

            if (name.Contains("GEN"))
                return "Generator";

            if (name.Contains("VAV"))
                return "Ventilation";

            return "Unknown";
        }
    }
}
