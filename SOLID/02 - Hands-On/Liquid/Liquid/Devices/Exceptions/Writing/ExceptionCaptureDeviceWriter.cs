using System;
using Liquid.Devices.Exceptions.Handlers;
using Liquid.Devices.Writers;
using Liquid.Models;

namespace Liquid.Devices.Exceptions.Writing
{
    internal class ExceptionCaptureDeviceWriter : ExceptionCaptureDevice, IDeviceWriterFacade
    {
        private readonly IDeviceWriterFacade deviceWriter;
        private readonly IExceptionHandler exceptionHandler;
        
        public ExceptionCaptureDeviceWriter(IDeviceWriterFacade deviceWriter, IExceptionHandler exceptionHandler)
            : base(deviceWriter, exceptionHandler)
        {
            this.deviceWriter = deviceWriter;
            this.exceptionHandler = exceptionHandler;
        }
        
        public bool Analyze(DataToAnalyze data)
        {
            try
            {
                return deviceWriter.Analyze(data);
            }
            catch(Exception ex)
            {
                exceptionHandler.HandleException(ex);
            }

            return false;
        }
    }
}