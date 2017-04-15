using FabricSoftener.Entities.Message;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface IMessageTransmit
    {
        void Transmit(IGrainMessage message);
    }
}
