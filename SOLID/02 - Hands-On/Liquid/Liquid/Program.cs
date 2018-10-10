using System;
using Liquid.Devices;
using Liquid.Models;

namespace Liquid
{
    // this system uses two devices, one that has data and another one that only analyzes data.
    // data analyzes is a success if any analyzer succeeds.
    //
    // client 1 : uses DeviceA to get data and Devices B and C to analyze the data.
    // client 2 : uses DeviceA to get data and all supported devices to analyze data.
    //
    // fix: all devices should only be used when they in Connected state.
    // fix: any exception should be logged
    // feature: when a device throws 3 exceptions in a row we should stop using that device.
    // 
    // What principles are being violated here?
    // 
    // 
    internal class Program
    {
        private static void Main(string[] args)
        {
            var deviceA = new DeviceA();
            var deviceB = new DeviceB();

            Console.Write("Connecting to device A: ");
            deviceA.Connect();
            Console.WriteLine("Connected!");

            Console.Write("Connecting to device B: ");
            deviceB.Connect();
            Console.WriteLine("Connected!");

            
            Console.Write("Reading data from device A");
            var data = deviceA.ReadData();

            Console.WriteLine("this is really: {0}", data.Content);

            Console.Write("Analyzing data with device B");

            var success = deviceB.Analyze(new DataToAnalyze
            {
                Something = data.Content
            });

            if (success)
            {
                Console.WriteLine("Yep, it really is: {0}", data.Content);
            }

            Console.Write("Disconnecting device A: ");
            deviceA.Disconnect();
            Console.WriteLine("Done!");

            Console.Write("Disconnecting device B: ");
            deviceB.Disconnect();
            Console.WriteLine("Done!");

        }
    }
}
