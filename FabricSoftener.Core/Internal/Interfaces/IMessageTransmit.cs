using FabricSoftener.Entities.Message;
using FabricSoftener.Interfaces.GrainClient;
using System.Threading.Tasks;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface IMessageTransmit
    {
        TaskCompletionSource<object> TransmitRequestAsync<TGrain>(GrainMessageRequestEntity<TGrain> message) where TGrain : IGrain;
        void TransmitResponseAsync<TGrain>(GrainMessageResponseEntity<TGrain> message) where TGrain : IGrain;
    }
}
