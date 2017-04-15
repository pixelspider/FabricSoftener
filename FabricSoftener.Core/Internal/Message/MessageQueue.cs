using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Entities.Message;
using System;
using System.Reactive.Subjects;
using static FabricSoftener.Entities.Message.MessageEvents;

namespace FabricSoftener.Core.Internal.Message
{
    internal class MessageQueue<TMessage> : IMessageQueue<TMessage> where TMessage : IGrainMessage
    {
        private Subject<TMessage> Queue => _queue ?? (_queue = new Subject<TMessage>());
        private Subject<TMessage> _queue;

        public MessageQueue()
        {
            //persistence goes here
            Queue.Subscribe(
            x => Process(x),
            () => Complete());
        }

        public void Add(TMessage message)
        {
            //persistence goes here
            Queue.OnNext(message);
        }

        public event MessageEventHandler Process;
        public event MessageCompleteEventHandler Complete;
    }
}
