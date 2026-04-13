using System;
using System.Collections.Generic;
using System.Text;
using UnityBacnet.POC.Domain;

namespace UnityBacnet.POC.Application.Services
{
    public class MappingService
    {
        private readonly Dictionary<string, string> _mapping;

        public MappingService(Dictionary<string, string> mapping)
        {
            _mapping = mapping;
        }

        public UnityAssetReading Map(DeviceWithReading device)
        {
            return new UnityAssetReading
            {
                AssetId = device.DeviceId,
                AssetType = MapDeviceType(device.Name),
                Value = device.Temperature,
                ReadingType = "Temperature",
                HasAlarm = device.HasAlarm
            };
        }

        private string MapDeviceType(string name)
        {
            foreach (var key in _mapping.Keys)
            {
                if (name.Contains(key))
                    return _mapping[key];
            }

            return "Unknown";
        }
    }
}
