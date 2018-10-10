using Liquid.Models;

namespace Liquid.Devices.Readers
{
    internal class DeviceA : IDeviceReaderFacade
    {
        public DeviceState State { get; private set; }
        public string Id { get; } = "A";

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