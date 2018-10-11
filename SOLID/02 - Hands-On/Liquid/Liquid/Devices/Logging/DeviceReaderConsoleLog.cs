using System;
using Liquid.Devices.Readers;
using Liquid.Models;

namespace Liquid.Devices.Logging
{
    internal class DeviceReaderConsoleLog : DeviceConsoleLog, IDeviceReaderFacade
    {
        private readonly IDeviceReader device;

        public DeviceReaderConsoleLog(IDeviceReaderFacade device)
            : base(device)
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
