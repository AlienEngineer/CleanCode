using System.Collections.Generic;
using System.Linq;
using Liquid.Devices;
using Liquid.Devices.Logging;
using Liquid.Devices.Readers;
using Liquid.Devices.Writers;
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

        public ClientDeviceFacade(IDeviceReaderFacade deviceReader, IEnumerable<IDeviceWriterFacade> deviceWriters)
            : this(
                new DeviceWriterComposite(MakeLoggerWriters(deviceWriters)),
                deviceReader,
                new DeviceComposite(MakeLoggerDevices(new IDevice[] { deviceReader }.Concat(deviceWriters))))
        { }

        public Data ReadData() => deviceReader.ReadData();

        public bool Analyze(DataToAnalyze data) => deviceWriter.Analyze(data);

        public void Connect() => allDevices.Connect();

        public void Disconnect() => allDevices.Disconnect();

        
        private static IEnumerable<IDeviceWriterFacade> MakeLoggerWriters(IEnumerable<IDeviceWriterFacade> deviceWriters) => 
            deviceWriters.Select(deviceWriter => new DeviceWriterConsoleLog(deviceWriter)).ToArray();

        private static IEnumerable<IDevice> MakeLoggerDevices(IEnumerable<IDevice> devices) => 
            devices.Select(device => new DeviceConsoleLog(device)).ToArray();
    }
}