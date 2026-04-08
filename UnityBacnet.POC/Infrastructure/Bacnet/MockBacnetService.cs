using System;
using System.Collections.Generic;
using System.Text;
using UnityBacnet.POC.Domain;

namespace UnityBacnet.POC.Infrastructure.Bacnet
{
    public class MockBacnetService
    {
        public List<BacnetReading> GenerateReadings(List<BacnetDevice> devices)
        {
            var random = new Random();

            return devices.Select(d => new BacnetReading
            {
                DeviceId = d.DeviceId,
                Temperature = random.Next(18, 40),
                HasAlarm = random.Next(0, 10) > 7,
                AlarmType = "HIGH_TEMP"
            }).ToList();
        }
    }
}
