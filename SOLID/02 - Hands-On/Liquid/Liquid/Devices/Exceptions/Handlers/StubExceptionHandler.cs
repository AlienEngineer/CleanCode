using System;

namespace Liquid.Devices.Exceptions.Handlers
{
    internal class StubExceptionHandler : IExceptionHandler
    {
        public void HandleException(Exception exception)
        {
            throw exception;
        }
    }
}