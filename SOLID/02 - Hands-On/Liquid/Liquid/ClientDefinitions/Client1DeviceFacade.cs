using Liquid.Devices;
using Liquid.Devices.Logging;
using Liquid.Devices.Readers;
using Liquid.Devices.Writers;

namespace Liquid.ClientDefinitions
{
    internal class Client1DeviceFacade : ClientDeviceFacade
    {
        public Client1DeviceFacade(IDeviceReaderFacade deviceReader, IDeviceWriterFacade deviceWriter)
            : base(
                new DeviceWriterComposite(new IDeviceWriter[]
                {
                    new DeviceWriterConsoleLog(deviceWriter)
                }),
                deviceReader,
                new DeviceComposite(new IDevice[]
                {
                    new DeviceConsoleLog(deviceReader),
                    new DeviceConsoleLog(deviceWriter)
                }))
        { }

        public Client1DeviceFacade()
            : this(new DeviceA(), new DeviceB()) { }
    }
}