using FabricSoftener.Entities.Message;
using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface IMessageTransmit<TGrain> where TGrain : IGrain
    {
        void TransmitRequest(IGrainMessage message);
        void TransmitResponse(IGrainMessage message);
    }
}
