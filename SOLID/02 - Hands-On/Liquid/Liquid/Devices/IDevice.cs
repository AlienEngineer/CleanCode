namespace Liquid.Devices
{
    internal interface IDevice : IConnectableDevice, IStatefullDevice
    {
        string Id { get; }
    }
}