using Liquid.Models;

namespace Liquid.Devices.Readers
{
    internal interface IDeviceReader
    {
        Data ReadData();
    }
}