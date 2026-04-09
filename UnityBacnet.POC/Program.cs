using System;
using System.Collections.Generic;
using System.IO.BACnet;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityBacnet.POC.Application.Services;
using UnityBacnet.POC.Infrastructure.Bacnet;
using UnityBacnet.POC.Infrastructure.Parsers;

class Program
{
    static void Main(string[] args)
    {

        //Merge
        var parser = new DeviceListParser();
        var devices = parser.Parse("device-list.txt");

        var mockService = new MockBacnetService();
        var readings = mockService.GenerateReadings(devices);

        var mergeService = new DeviceMergeService();
        var merged = mergeService.Merge(devices, readings);

        foreach (var d in merged.Take(10))
        {
            Console.WriteLine($"{d.DeviceId} - {d.Name} - Temp: {d.Temperature} - Alarm: {d.HasAlarm}");
        }

        //Mapping
        var mappingService = new MappingService();

        var mapped = merged.Select(d => mappingService.Map(d)).ToList();

        foreach (var m in mapped.Take(10))
        {
            Console.WriteLine($"{m.AssetId} - {m.AssetType} - {m.Value}");
        }

        //Example parsing data
        //var parser = new DeviceListParser();
        //var devices = parser.Parse("device-list.txt");

        //foreach (var d in devices.Take(10))
        //{
        //    Console.WriteLine($"{d.DeviceId} / {d.Model} - {d.Name} / {d.Network} / {d.Status}");
        //}

        //Console.WriteLine($"Parsed: {devices.Count} devices");
        //Console.ReadKey();


        //Basic Device discovery code 
        //Console.WriteLine("Starting BACnet discovery...");

        //var client = new BacnetClient();
        //client.Start();

        //client.OnIam += (sender, address, deviceId, maxApdu, segmentation, vendorId) =>
        //{
        //    Console.WriteLine($"Device found: {deviceId} from {address}");
        //};

        //client.WhoIs();

        //Console.WriteLine("Press any key to exit...");
        //Console.ReadKey();
    }
}