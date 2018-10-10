using Liquid.Models;

namespace Liquid.Devices
{
    internal class DeviceE
    {
        public DeviceState State { get; private set; } = DeviceState.Disconnected;
        
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