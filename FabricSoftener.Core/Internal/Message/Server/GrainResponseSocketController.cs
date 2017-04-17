using FabricSoftener.Communicator.Internal.Extensions;
using FabricSoftener.Communicator.Internal.Server;
using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Entities.Message;

namespace FabricSoftener.Core.Internal.Message.Server
{
    public class GrainResponseSocketController : BaseSocketController
    {
        private IMessageTransmit MessageTransmit => _messageTransmit ?? (_messageTransmit = new MessageTransmit());
        private IMessageTransmit _messageTransmit;

        public override void Request(byte[] messageData)
        {
            var grainMessageResponseEntity = messageData.Deserialiser<GrainMessageResponseEntity>();
            MessageTransmit.TransmitResponseToProxyAsync(grainMessageResponseEntity);
        }
    }
}
