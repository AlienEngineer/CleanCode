using Liquid.Models;

namespace Liquid.Devices
{
    internal interface IStatefullDevice
    {
        DeviceState State { get; }
    }
}