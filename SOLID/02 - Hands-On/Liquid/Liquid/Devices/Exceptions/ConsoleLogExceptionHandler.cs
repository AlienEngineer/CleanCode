using System;

namespace Liquid.Devices.Exceptions
{
    internal class ConsoleLogExceptionHandler : IExceptionHandler
    {
        public void HandleException(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}