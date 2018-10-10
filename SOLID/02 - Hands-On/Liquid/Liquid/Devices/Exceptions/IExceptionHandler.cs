using System;

namespace Liquid.Devices.Exceptions
{
    internal interface IExceptionHandler
    {
        void HandleException(Exception exception);
    }
}