using System;
using System.Collections.Generic;
using System.Text;

namespace UnityBacnet.POC.Domain
{
    public class BacnetReading
    {
        public int DeviceId { get; set; }
        public double Temperature { get; set; }

        public bool HasAlarm { get; set; }
        public string AlarmType { get; set; }
    }
}
