using System;
using System.Collections.Generic;
using System.Text;

namespace UnityBacnet.POC.Domain
{
    public class BacnetDevice
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Network { get; set; }
        public string Status { get; set; }
    }
}
