using FabricSoftener.Entities.Message;
using static FabricSoftener.Entities.Message.MessageEvents;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface IMessageQueue<TMessage> where TMessage : IGrainMessage
    {
        void Add(TMessage message);
        event MessageEventHandler Process;
        event MessageCompleteEventHandler Complete;
    }
}
