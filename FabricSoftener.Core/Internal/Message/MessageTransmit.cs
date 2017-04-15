using System;
using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Entities.Message;
using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.Core.Internal.Message
{
    internal class MessageTransmit<TGrain> : IMessageTransmit<TGrain> where TGrain : IGrain
    {
        public void TransmitRequest(IGrainMessage message)
        {
            throw new NotImplementedException();
        }

        public void TransmitResponse(IGrainMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
