using System;
using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Entities.Message;

namespace FabricSoftener.Core.Internal.Message
{
    internal class MessageTransmit : IMessageTransmit
    {
        public void Transmit(IGrainMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
