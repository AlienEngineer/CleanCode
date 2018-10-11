using Liquid.Devices.Readers;
using Liquid.Models;

namespace Liquid.Devices.Exceptions.Reading
{
    internal class RetryPolicyDeviceReader : RetryPolicyDevice<IDeviceReaderFacade>, IDeviceReaderFacade
    {
        public RetryPolicyDeviceReader(IDeviceReaderFacade device)
            : base(device) { }

        public Data ReadData() => CaptureException(() => Device.ReadData());
        protected override IDeviceReaderFacade MakeStub() => new StubDevice();
    }
}