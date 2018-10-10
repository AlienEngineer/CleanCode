using System;
using Liquid.Models;

namespace Liquid.Devices.Logging
{
    internal class DeviceConsoleLog : IDevice
    {
        private readonly IDevice device;

        public DeviceState State => device.State;
        public string Id => device.Id;

        public DeviceConsoleLog(IDevice device)
        {
            this.device = device;
        }

        public void Connect()
        {
            Console.Write("Connecting to device {0}: ", device.Id);
            device.Connect();
            Console.WriteLine("Connected!");
        }

        public void Disconnect()
        {
            Console.Write("Disconnecting device {0}: ", device.Id);
            device.Disconnect();
            Console.WriteLine("Done!");
        }
    }
}
