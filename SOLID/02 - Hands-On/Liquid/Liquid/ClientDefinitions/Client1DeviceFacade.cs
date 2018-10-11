using Liquid.Devices;
using Liquid.Devices.Readers;
using Liquid.Devices.Writers;

namespace Liquid.ClientDefinitions
{
    internal class Client1DeviceFacade : ClientDeviceFacade
    {
        public Client1DeviceFacade()
            : base(new DeviceA(),new IDeviceWriterFacade[] {
                new DeviceB(), 
                new DeviceC()
            }) { }
    }
}