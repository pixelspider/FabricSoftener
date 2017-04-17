using FabricSoftener.Communicator.Internal.Server;
using FabricSoftener.Communicator.Internal.Extensions;
using FabricSoftener.Entities.Message;
using FabricSoftener.Core.Internal.Interfaces;

namespace FabricSoftener.Core.Internal.Message.Server
{
    public class GrainRequestSocketController : BaseSocketController
    {
        private IMessageTransmit MessageTransmit => _messageTransmit ?? (_messageTransmit = new MessageTransmit());
        private IMessageTransmit _messageTransmit;

        public override void Request(byte[] messageData)
        {
            var grainMessageRequestEntity = messageData.Deserialiser<GrainMessageRequestEntity>();
            MessageTransmit.TransmitRequestAsync(grainMessageRequestEntity);
        }
    }
}
