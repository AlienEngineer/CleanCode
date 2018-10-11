using System;
using Liquid.Devices.Exceptions.Handlers;
using Liquid.Models;

namespace Liquid.Devices.Exceptions
{
    internal class ExceptionCaptureDevice : IDevice
    {
        private readonly IDevice device;
        private readonly IExceptionHandler exceptionHandler;

        public DeviceState State => device.State;
        public string Id => device.Id;

        public ExceptionCaptureDevice(IDevice device, IExceptionHandler exceptionHandler)
        {
            this.device = device;
            this.exceptionHandler = exceptionHandler;
        }
        
        public void Connect()
        {
            try
            {
                device.Connect();
            }
            catch(Exception ex)
            {
                exceptionHandler.HandleException(ex);
            }
        }

        public void Disconnect()
        {
            try
            {
                device.Disconnect();
            }
            catch(Exception ex)
            {
                exceptionHandler.HandleException(ex);
            }
        }
    }
}