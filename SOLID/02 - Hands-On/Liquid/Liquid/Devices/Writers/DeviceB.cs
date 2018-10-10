using Liquid.Models;

namespace Liquid.Devices.Writers
{
    internal class DeviceB : IDeviceWriterFacade
    {
        public DeviceState State { get; private set; }
        public string Id { get; } = "B";
        
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
            return data.Something == "SOLID";
        }
    }
}