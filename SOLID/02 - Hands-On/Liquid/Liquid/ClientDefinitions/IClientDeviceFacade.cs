using Liquid.Devices;
using Liquid.Devices.Readers;
using Liquid.Devices.Writers;

namespace Liquid.ClientDefinitions
{
    internal interface IClientDeviceFacade : IDeviceReader, IDeviceWriter, IConnectableDevice
    {

    }
}