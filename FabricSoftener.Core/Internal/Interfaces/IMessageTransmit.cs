using FabricSoftener.Entities.Message;
using System.Threading.Tasks;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface IMessageTransmit
    {
        TaskCompletionSource<object> TransmitRequestFromProxyAsync(GrainMessageRequestEntity message);
        void TransmitRequestAsync(GrainMessageRequestEntity message);
        void TransmitResponseAsync(GrainMessageResponseEntity message);
        void TransmitResponseToProxyAsync(GrainMessageResponseEntity message);
    }
}
