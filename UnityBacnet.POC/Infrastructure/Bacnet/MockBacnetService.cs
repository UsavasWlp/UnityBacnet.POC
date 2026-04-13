using System;
using System.Collections.Generic;
using System.Text;
using UnityBacnet.POC.Domain;

namespace UnityBacnet.POC.Infrastructure.Bacnet
{
    public class MockBacnetService
    {
        private static readonly Random _random = new();

        public List<BacnetReading> GenerateReadings(List<BacnetDevice> devices)
        {

            return devices.Select(d => new BacnetReading
            {
                DeviceId = d.DeviceId,
                Temperature = _random.NextDouble() * 50
            }).ToList();

            //var random = new Random();

            //return devices.Select(d => new BacnetReading
            //{
            //    DeviceId = d.DeviceId,
            //    Temperature = random.Next(18, 40),
            //    HasAlarm = random.Next(0, 10) > 7,
            //    AlarmType = "HIGH_TEMP"
            //}).ToList();
        }
    }
}
