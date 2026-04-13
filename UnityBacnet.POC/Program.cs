using System;
using System.Collections.Generic;
using System.IO.BACnet;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using UnityBacnet.POC.Application.Metrics;
using UnityBacnet.POC.Application.Services;
using UnityBacnet.POC.Domain;
using UnityBacnet.POC.Infrastructure.Bacnet;
using UnityBacnet.POC.Infrastructure.Config;
using UnityBacnet.POC.Infrastructure.Parsers;

class Program
{
    static void Main(string[] args)
    {
        //Timer
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        int errorCount = 0;

        //Example parsing data
        var parser = new DeviceListParser();
        var devices = parser.Parse("device-list.txt");
       
        //Mock Data
        var mockService = new MockBacnetService();
        var readings = mockService.GenerateReadings(devices);

        //Merge
        var mergeService = new DeviceMergeService();
        var merged = mergeService.Merge(devices, readings);



        //Mapping and config loader
        var configLoader = new MappingConfigLoader();
        var mappingDict = configLoader.Load("mapping.json");

        var mappingService = new MappingService(mappingDict);
        var mapped = new List<UnityAssetReading>();

        foreach (var device in merged) {

            try
            {
                mapped.Add(mappingService.Map(device));
                
            }
            catch (Exception e)
            {
                errorCount++;
                Console.WriteLine(e.ToString());
            }
        }
        //stop timer
        stopwatch.Stop();

        //create metrics
        var metrics = new ProcessingMetrics
        {
            TotalDevices = devices.Count,
            ParsedDevices = devices.Count,
            MappedDevices = mapped.Count,
            ErrorCount = errorCount,
            ProcessingTimeMs = stopwatch.ElapsedMilliseconds
        };

        Console.WriteLine("----- METRICS -----");
        Console.WriteLine($"Total Devices: {metrics.TotalDevices}");
        Console.WriteLine($"Mapped: {metrics.MappedDevices}");
        Console.WriteLine($"Errors: {metrics.ErrorCount}");
        Console.WriteLine($"Time: {metrics.ProcessingTimeMs} ms");
        double successRate = (double)mapped.Count / devices.Count * 100;
        Console.WriteLine($"Success Rate: {successRate}%");



        //Basic Device discovery code for BACNET

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