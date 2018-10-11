using Liquid.Models;

namespace Liquid.Devices.Writers
{
    internal interface IDeviceWriter
    {
        bool Analyze(DataToAnalyze data);
    }

    internal interface IStatefullDeviceWriter : IDeviceWriter, IStatefullDevice
    {

    }
}