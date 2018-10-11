using Liquid.Devices.Writers;
using Liquid.Models;

namespace Liquid.Devices.Exceptions.Writing
{
    internal class RetryPolicyDeviceWriter : RetryPolicyDevice<IDeviceWriterFacade>, IDeviceWriterFacade
    {
        public RetryPolicyDeviceWriter(IDeviceWriterFacade device) 
            : base(device) { }

        protected override IDeviceWriterFacade MakeStub() => new StubDevice();
        public bool Analyze(DataToAnalyze data) => CaptureException(() => Device.Analyze(data));
    }
}