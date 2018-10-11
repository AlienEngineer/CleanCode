using System;

namespace Liquid.Devices.Exceptions.Handlers
{
    internal interface IExceptionHandler
    {
        void HandleException(Exception exception);
    }
}