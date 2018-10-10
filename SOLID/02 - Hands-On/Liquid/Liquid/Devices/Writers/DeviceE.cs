using Liquid.Models;

namespace Liquid.Devices.Writers
{
    internal class DeviceE : IDeviceWriterFacade
    {
        public DeviceState State { get; private set; } = DeviceState.Disconnected;
        public string Id { get; } = "E";
        
        public void Connect()
        {

        }

        public void Disconnect()
        {

        }

        public bool Analyze(DataToAnalyze data)
        {
            return true;
        }
    }
}