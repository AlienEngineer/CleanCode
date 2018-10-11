using System;

namespace Liquid.Devices.Exceptions.Handlers
{
    internal class ConsoleLogExceptionHandler : IExceptionHandler
    {
        public void HandleException(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}