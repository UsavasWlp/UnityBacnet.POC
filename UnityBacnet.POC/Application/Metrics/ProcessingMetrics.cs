using System;
using System.Collections.Generic;
using System.Text;

namespace UnityBacnet.POC.Application.Metrics
{
    public class ProcessingMetrics
    {
        public int TotalDevices { get; set; }
        public int ParsedDevices { get; set; }
        public int MappedDevices { get; set; }
        public int ErrorCount { get; set; }
        public long ProcessingTimeMs { get; set; }
    }
}
