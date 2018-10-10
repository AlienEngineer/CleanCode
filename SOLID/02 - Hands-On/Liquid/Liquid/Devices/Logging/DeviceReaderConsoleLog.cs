using System;
using Liquid.Models;

namespace Liquid.Devices.Logging
{
    internal class DeviceReaderConsoleLog : IDeviceReader
    {
        private readonly IDeviceReader device;

        public DeviceReaderConsoleLog(IDeviceReader device)
        {
            this.device = device;
        }

        public Data ReadData()
        {
            Console.WriteLine("Reading data from device A");
            var data = device.ReadData();
            Console.WriteLine("this is really: {0}", data.Content);

            return data;
        }
    }
}
