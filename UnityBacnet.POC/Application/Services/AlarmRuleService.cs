using System;
using System.Collections.Generic;
using System.Text;
using UnityBacnet.POC.Domain;

namespace UnityBacnet.POC.Application.Services
{
    public class AlarmRuleService
    {
        public BacnetReading ApplyRules(BacnetReading reading)
        {
            // Temperature rule
            if (reading.Temperature > 35)
            {
                reading.HasAlarm = true;
                reading.AlarmType = "HIGH_TEMP";
            }
            else if (reading.Temperature < 5)
            {
                reading.HasAlarm = true;
                reading.AlarmType = "LOW_TEMP";
            }
            else
            {
                reading.HasAlarm = false;
                reading.AlarmType = null;
            }

            return reading;
        }
    }
}
