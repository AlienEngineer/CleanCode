using Liquid.Models;

namespace Liquid.Devices
{
    internal interface IDeviceReader
    {
        Data ReadData();
    }
}