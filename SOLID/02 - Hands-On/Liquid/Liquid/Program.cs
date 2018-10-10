using Liquid.ClientDefinitions;
using Liquid.Products;

namespace Liquid
{
    // this system uses two devices, one that has data and another one that only analyzes data.
    // data analyzes is a success if any analyzer succeeds.
    //
    // client 1 : uses DeviceA to get data and Devices B and C to analyze the data.
    // client 2 : uses DeviceA to get data and all supported devices to analyze data.
    //
    // fix: all devices should only be used when they in Connected state.
    // fix: any exception should be logged
    // feature: when a device throws 3 exceptions in a row we should stop using that device.
    // 
    // What principles are being violated here?
    // 
    // 
    
    internal class Program
    {
        private static void Main(string[] args)
        {
            var devices = new Client1DeviceFacade();

            new LiquidProduct(devices).ReadAndAnalyze();
        }
    }
}
