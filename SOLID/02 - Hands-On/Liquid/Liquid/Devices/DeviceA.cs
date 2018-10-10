using Liquid.Models;

namespace Liquid.Devices
{
    internal class DeviceA
    {
        public DeviceState State { get; private set; }

        public void Connect()
        {
            State = DeviceState.Connected;
        }

        public void Disconnect()
        {
            State = DeviceState.Disconnected;
        }

        public Data ReadData()
        {
            return new Data
            {
                Content = "SOLID"
            };
        }
    }
}