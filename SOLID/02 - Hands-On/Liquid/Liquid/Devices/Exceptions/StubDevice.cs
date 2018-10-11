using Liquid.Devices.Readers;
using Liquid.Devices.Writers;
using Liquid.Models;

namespace Liquid.Devices.Exceptions
{
    internal class StubDevice : IDeviceReaderFacade, IDeviceWriterFacade
    {
        public DeviceState State { get; } = DeviceState.Disconnected;
        public Data ReadData() => new Data();
        public bool Analyze(DataToAnalyze data) => false;
        public void Connect() {}
        public void Disconnect() { }
        public string Id { get; }
    }
}