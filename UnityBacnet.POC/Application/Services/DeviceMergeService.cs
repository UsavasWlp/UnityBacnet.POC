using System;
using System.Collections.Generic;
using System.Text;
using UnityBacnet.POC.Domain;

namespace UnityBacnet.POC.Application.Services
{
    public class DeviceMergeService
    {
        public List<DeviceWithReading> Merge(
            List<BacnetDevice> devices,
            List<BacnetReading> readings)
        {
            return devices.Join(
                readings,
                d => d.DeviceId,
                r => r.DeviceId,
                (d, r) => new DeviceWithReading
                {
                    DeviceId = d.DeviceId,
                    Name = d.Name,
                    Temperature = r.Temperature,
                    HasAlarm = r.HasAlarm,
                    AlarmType = r.AlarmType
                }).ToList();
        }
    }
}
