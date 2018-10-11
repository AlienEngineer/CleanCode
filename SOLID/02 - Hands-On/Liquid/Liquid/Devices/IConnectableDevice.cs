namespace Liquid.Devices
{
    internal interface IConnectableDevice
    {
        void Connect();
        void Disconnect();
    }
}