using Liquid.Models;

namespace Liquid.Devices
{
    internal interface IConnectableDevice
    {
        void Connect();
        void Disconnect();
    }

    internal interface IDevice : IConnectableDevice
    {
        DeviceState State { get; }
        string Id { get; }
    }
}