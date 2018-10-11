using System;
using Liquid.Devices.Exceptions.Handlers;
using Liquid.Devices.Readers;
using Liquid.Models;

namespace Liquid.Devices.Exceptions.Reading
{
    internal class ExceptionCaptureDeviceReader : ExceptionCaptureDevice, IDeviceReaderFacade
    {
        private readonly IDeviceReaderFacade deviceWriter;
        private readonly IExceptionHandler exceptionHandler;
        
        public ExceptionCaptureDeviceReader(IDeviceReaderFacade deviceWriter, IExceptionHandler exceptionHandler)
            : base(deviceWriter, exceptionHandler)
        {
            this.deviceWriter = deviceWriter;
            this.exceptionHandler = exceptionHandler;
        }
        
        public Data ReadData()
        {
            try
            {
                return deviceWriter.ReadData();
            }
            catch(Exception ex)
            {
                exceptionHandler.HandleException(ex);
            }

            return new Data();
        }
    }
}