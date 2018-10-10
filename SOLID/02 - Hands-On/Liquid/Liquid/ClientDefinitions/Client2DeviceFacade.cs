using System.Collections.Generic;
using System.Linq;
using Liquid.Devices;
using Liquid.Devices.Logging;
using Liquid.Devices.Readers;
using Liquid.Devices.Writers;

namespace Liquid.ClientDefinitions
{
    internal class Client2DeviceFacade : ClientDeviceFacade
    {
        
        public Client2DeviceFacade(IDeviceReaderFacade deviceReader, IEnumerable<IDeviceWriterFacade> deviceWriters)
            : base(
                new DeviceWriterComposite(MakeLoggerWriters(deviceWriters)),
                deviceReader,
                new DeviceComposite(MakeLoggerDevices(new IDevice[] { deviceReader }.Concat(deviceWriters))))
        { }

        public Client2DeviceFacade()
            : this(new DeviceA(), new IDeviceWriterFacade[]
            {
                new DeviceB(), 
                new DeviceC(), 
                new DeviceD(), 
                new DeviceE()
            }) { }
        

        private static IEnumerable<IDeviceWriter> MakeLoggerWriters(IEnumerable<IDeviceWriterFacade> deviceWriters) => 
            deviceWriters.Select(deviceWriter => new DeviceWriterConsoleLog(deviceWriter)).ToArray();

        private static IEnumerable<IDevice> MakeLoggerDevices(IEnumerable<IDevice> devices) => 
            devices.Select(device => new DeviceConsoleLog(device)).ToArray();
    }
}