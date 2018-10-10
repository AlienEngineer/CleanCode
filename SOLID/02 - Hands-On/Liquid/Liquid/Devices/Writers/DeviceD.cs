using System;
using Liquid.Models;

namespace Liquid.Devices.Writers
{
    internal class DeviceD : IDeviceWriterFacade
    {
        public DeviceState State { get; private set; }
        public string Id { get; } = "D";
        
        public void Connect()
        {
            State = DeviceState.Connected;
        }

        public void Disconnect()
        {
            State = DeviceState.Disconnected;
        }

        public bool Analyze(DataToAnalyze data)
        {
            if (data.Something == "SOLID")
            {
                throw new Exception("This is my device exception.");
            }

            return data.Something == "LIQUID";
        }
    }
}