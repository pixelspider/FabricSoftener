using FabricSoftener.Communicator.Internal.Extensions;
using FabricSoftener.Communicator.Internal.Server;
using FabricSoftener.Entities.Message;
using System;

namespace FabricSoftener.Core.Internal.Message.Server
{
    public class GrainResponseSocketController : BaseSocketController
    {
        public override void Request(byte[] messageData)
        {
            var grainMessage = messageData.Deserialiser<IGrainMessage>();

            throw new NotImplementedException();
        }
    }
}
