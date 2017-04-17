using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Entities.Message;
using FabricSoftener.Interfaces.GrainClient;
using FabricSoftener.Core.Internal.Message;
using System.Reflection;

namespace FabricSoftener.Core.Internal.GrainClient
{
    internal class GrainContainer<TGrain> : IGrainContainer<TGrain> where TGrain : IGrain
    {
        private MessageQueue<GrainMessageRequestEntity<TGrain>> RequestMessageQueue => GetRequestMessageQueue();
        private MessageQueue<GrainMessageRequestEntity<TGrain>> _requestMessageQueue;

        private MessageQueue<GrainMessageResponseEntity<TGrain>> ResponseMessageQueue => GetResponsetMessageQueue();
        private MessageQueue<GrainMessageResponseEntity<TGrain>> _responseMessageQueue;

        private IMessageTransmit MessageTransmit => _messageTransmit ?? (_messageTransmit = new MessageTransmit());
        private IMessageTransmit _messageTransmit;

        private IGrainGenerator<TGrain> GrainGenerator => _grainGenerator ?? (_grainGenerator = new GrainGenerator<TGrain>());
        private IGrainGenerator<TGrain> _grainGenerator;

        private TGrain Grain => GetGrain();
        private TGrain _grain;

        private bool _isBusy;

        public GrainContainer(MessageQueue<GrainMessageRequestEntity<TGrain>> requestMessageQueue = null, IGrainGenerator<TGrain> grainGenerator = null)
        {
            _requestMessageQueue = requestMessageQueue;
            _grainGenerator = grainGenerator;
        }

        public bool IsBusy => _isBusy;
        public void ProcessMessage(GrainMessageRequestEntity<TGrain> message)
        {
            RequestMessageQueue.Add(message);
        }

        private void ProcessRequest(IGrainMessage message)
        {
            var requestMessage = (GrainMessageRequestEntity<TGrain>)message;
            var response = new GrainMessageResponseEntity<TGrain>
            {
                RequesterSiloId = requestMessage.RequesterSiloId,
                ResponseTaskCompletionSourceId = requestMessage.ResponseTaskCompletionSourceId,
                Result = Grain.GetType().GetTypeInfo().GetDeclaredMethod(requestMessage.MethodName).Invoke(Grain, requestMessage.Arguments)
            }; 
            ResponseMessageQueue.Add(response);
        }

        private TGrain GetGrain()
        {
            if(_grain == null)
            {
                _grain = GrainGenerator.Generate();
            }
            return _grain;
        }

        private MessageQueue<GrainMessageRequestEntity<TGrain>> GetRequestMessageQueue()
        {
            if(_requestMessageQueue == null)
            {
                _requestMessageQueue = new MessageQueue<GrainMessageRequestEntity<TGrain>>();
                RequestMessageQueue.Process += ProcessRequest;
            }
            return _requestMessageQueue;
        }

        private MessageQueue<GrainMessageResponseEntity<TGrain>> GetResponsetMessageQueue()
        {
            if (_responseMessageQueue == null)
            {
                _responseMessageQueue = new MessageQueue<GrainMessageResponseEntity<TGrain>>();
                ResponseMessageQueue.Process += TransmitResponseMessage;
            }
            return _responseMessageQueue;
        }

        private void TransmitResponseMessage(IGrainMessage message)
        {
            MessageTransmit.TransmitResponseAsync((GrainMessageResponseEntity<TGrain>)message);
        }
    }
}
