using System;
using Liquid.Models;

namespace Liquid.Devices.Exceptions
{
    internal abstract class RetryPolicyDevice<T>
        where T : IDevice
    {
        private int tryCount;
        protected T Device;

        protected RetryPolicyDevice(T device)
        {
            this.Device = device;
            ResetTryCount();
        }

        private void ResetTryCount() => this.tryCount = 3;

        public DeviceState State => Device.State;
        public string Id => Device.Id;

        protected TOutput CaptureException<TOutput>(Func<TOutput> function)
        {
            try
            {
                var result = function();
                ResetTryCount();
                return result;
            }
            catch
            {
                AccountFailure();
                throw;
            }
        }

        private void AccountFailure()
        {
            tryCount--;

            if (tryCount == 0)
            {
                var stub = MakeStub();
                Device = stub;
            }
        }

        private void CaptureException(Action action)
        {
            CaptureException<object>(() =>
            {
                action();
                return null;
            });
        }

        protected abstract T MakeStub();

        public void Connect() => CaptureException(() => Device.Connect());
        public void Disconnect() => CaptureException(() => { Device.Disconnect(); });
    }
}