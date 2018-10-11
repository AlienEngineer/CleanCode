using System.Collections.Generic;
using System.Linq;
using Liquid.Devices.Exceptions.Handlers;
using Liquid.Devices.Exceptions.Writing;
using Liquid.Devices.Writers;
using Liquid.Models;

namespace Liquid.Devices
{
    internal class DeviceWriterComposite : IDeviceWriter
    {
        private readonly IEnumerable<IStatefullDeviceWriter> devices;

        public DeviceWriterComposite(IEnumerable<IDeviceWriterFacade> devices, IExceptionHandler exceptionHandler)
        {
            this.devices = devices.Select(device => new ExceptionCaptureDeviceWriter(device, exceptionHandler));
        }

        public DeviceWriterComposite(IEnumerable<IDeviceWriterFacade> devices)
            : this(devices, new StubExceptionHandler()) { }

        public bool Analyze(DataToAnalyze data) => 
            GetConnectedDevices().Aggregate(false, (current, device) => device.Analyze(data) || current);

        private IEnumerable<IDeviceWriter> GetConnectedDevices() => 
            devices.Where(e => e.State == DeviceState.Connected);
        
    }
}