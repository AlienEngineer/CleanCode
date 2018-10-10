using Liquid.ClientDefinitions;
using Liquid.Models;

namespace Liquid.Products
{
    internal class LiquidProduct
    {
        private readonly IClientDeviceFacade devices;

        public LiquidProduct(IClientDeviceFacade devices)
        {
            this.devices = devices;
        }

        public void ReadAndAnalyze()
        {
            devices.Connect();

            var data = devices.ReadData();

            devices.Analyze(new DataToAnalyze
            {
                Something = data.Content
            });

            devices.Disconnect();
        }
    }
}