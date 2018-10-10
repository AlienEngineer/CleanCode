using Liquid.Models;

namespace Liquid.Devices.Writers
{
    internal class DeviceC : IDeviceWriterFacade
    {
        public DeviceState State { get; private set; }
        public string Id { get; } = "C";
        
        public void Connect()
        {
            State = DeviceState.Connected;
        }

        public void Disconnect()
        {
            State = DeviceState.Disconnected;
        }

        public bool Analyze(DataToAnalyze data)
        {
            return data.Something == "LIQUID";
        }
    }
}