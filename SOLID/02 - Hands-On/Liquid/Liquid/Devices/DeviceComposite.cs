using System;
using System.Collections.Generic;
using Liquid.Devices.Exceptions;
using Liquid.Models;

namespace Liquid.Devices
{
    internal class DeviceComposite : IDevice
    {
        private readonly IEnumerable<IDevice> devices;
        private readonly IExceptionHandler exceptionHandler;

        public DeviceState State { get; private set; }
        public string Id { get; } = "Composite";

        public DeviceComposite(IEnumerable<IDevice> devices, IExceptionHandler exceptionHandler)
        {
            this.devices = devices;
            this.exceptionHandler = exceptionHandler;
        }

        public DeviceComposite(IEnumerable<IDevice> devices)
            : this(devices, new StubExceptionHandler()) { }

        public void Connect()
        {
            foreach (var device in devices)
            {
                try
                {
                    device.Connect();
                }
                catch (Exception exception)
                {
                    exceptionHandler.HandleException(exception);
                }
            }

            State = DeviceState.Connected;
        }

        public void Disconnect()
        {
            foreach (var device in devices)
            {
                try
                {
                    device.Disconnect();
                }
                catch (Exception exception)
                {
                    exceptionHandler.HandleException(exception);
                }
            }

            State = DeviceState.Disconnected;
        }
    }
}
