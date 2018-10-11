using Liquid.Devices;
using Liquid.Devices.Readers;
using Liquid.Devices.Writers;

namespace Liquid.ClientDefinitions
{
    internal class Client2DeviceFacade : ClientDeviceFacade
    {
        public Client2DeviceFacade()
            : base(new DeviceA(), new IDeviceWriterFacade[]
            {
                new DeviceB(), 
                new DeviceC(), 
                new DeviceD(), 
                new DeviceE()
            }) { }
    }
}