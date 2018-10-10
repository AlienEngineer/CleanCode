using System;
using System.Collections.Generic;
using Liquid.Devices.Exceptions;
using Liquid.Models;

namespace Liquid.Devices
{
    internal class DeviceWriterComposite : IDeviceWriter
    {
        private readonly IEnumerable<IDeviceWriter> devices;
        private readonly IExceptionHandler exceptionHandler;

        public DeviceWriterComposite(IEnumerable<IDeviceWriter> devices, IExceptionHandler exceptionHandler)
        {
            this.devices = devices;
            this.exceptionHandler = exceptionHandler;
        }

        public DeviceWriterComposite(IEnumerable<IDeviceWriter> devices)
            : this(devices, new StubExceptionHandler()) { }

        public bool Analyze(DataToAnalyze data)
        {
            var result = false;

            foreach (var device in devices)
            {
                try
                {
                    result = device.Analyze(data) || result;
                }
                catch(Exception ex)
                {
                    exceptionHandler.HandleException(ex);
                }
            }

            return result;
        }
    }
}