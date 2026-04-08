using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityBacnet.POC.Domain;

namespace UnityBacnet.POC.Infrastructure.Parsers
{
    // Infrastructure/Parsers/DeviceListParser.cs
    public class DeviceListParser
    {
        public List<BacnetDevice> Parse(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var devices = new List<BacnetDevice>();

            int lineNumber = 0;

            foreach (var line in lines.Skip(1))
            {
                lineNumber++;

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = Regex.Split(line.Trim(), @"\s{2,}");

                try
                {
                    if (parts.Length < 3)
                    {
                        Console.WriteLine($"[WARN] Line {lineNumber}: Not enough data");
                        continue;
                    }

                    var device = new BacnetDevice
                    {
                        DeviceId = int.TryParse(parts[0], out var id) ? id : 0,
                        Name = parts.Length > 1 ? parts[1] : "UNKNOWN",
                        Model = parts.Length > 2 ? parts[2] : "UNKNOWN",
                        Status = parts.Length > 6 ? parts[6] : "UNKNOWN",
                        Network = parts.Length > 7 ? parts.Last() : "UNKNOWN"
                    };

                    devices.Add(device);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Line {lineNumber}: {ex.Message}");
                }
            }

            return devices;
        }
    }
}
