using Liquid.Devices;
using Liquid.Models;

namespace Liquid.ClientDefinitions
{
    internal class ClientDeviceFacade : IClientDeviceFacade
    {
        private readonly IDeviceWriter deviceWriter;

        private readonly IDeviceReader deviceReader;

        private readonly IDevice allDevices;

        public ClientDeviceFacade(IDeviceWriter deviceWriter, IDeviceReader deviceReader, IDevice allDevices)
        {
            this.deviceWriter = deviceWriter;
            this.deviceReader = deviceReader;
            this.allDevices = allDevices;
        }

        public Data ReadData() => deviceReader.ReadData();

        public bool Analyze(DataToAnalyze data) => deviceWriter.Analyze(data);

        public void Connect() => allDevices.Connect();

        public void Disconnect() => allDevices.Disconnect();
    }
}