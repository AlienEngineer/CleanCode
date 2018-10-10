using System;

namespace Liquid.Devices.Exceptions
{
    internal class StubExceptionHandler : IExceptionHandler
    {
        public void HandleException(Exception exception)
        {
            throw exception;
        }
    }
}