using Liquid.Models;

namespace Liquid.Devices
{
    internal interface IDeviceWriter
    {
        bool Analyze(DataToAnalyze data);
    }
}