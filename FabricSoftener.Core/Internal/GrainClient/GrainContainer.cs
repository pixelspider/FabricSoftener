using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Entities.Message;
using FabricSoftener.Interfaces.GrainClient;
using FabricSoftener.Core.Internal.Message;
using System.Reflection;

namespace FabricSoftener.Core.Internal.GrainClient
{
    internal class GrainContainer<TGrain> : IGrainContainer where TGrain : IGrain
    {
        private MessageQueue<GrainMessageRequestEntity> RequestMessageQueue => GetRequestMessageQueue();
        private MessageQueue<GrainMessageRequestEntity> _requestMessageQueue;

        private MessageQueue<GrainMessageResponseEntity> ResponseMessageQueue => GetResponsetMessageQueue();
        private MessageQueue<GrainMessageResponseEntity> _responseMessageQueue;

        private IMessageTransmit MessageTransmit => _messageTransmit ?? (_messageTransmit = new MessageTransmit());
        private IMessageTransmit _messageTransmit;

        private IGrainGenerator<TGrain> GrainGenerator => _grainGenerator ?? (_grainGenerator = new GrainGenerator<TGrain>());
        private IGrainGenerator<TGrain> _grainGenerator;

        private TGrain Grain => GetGrain();
        private TGrain _grain;

        private bool _isBusy;

        public GrainContainer() : this(null, null) { }
        public GrainContainer(MessageQueue<GrainMessageRequestEntity> requestMessageQueue, IGrainGenerator<TGrain> grainGenerator)
        {
            _requestMessageQueue = requestMessageQueue;
            _grainGenerator = grainGenerator;
        }

        public bool IsBusy => _isBusy;
        public void ProcessMessage(GrainMessageRequestEntity message)
        {
            RequestMessageQueue.Add(message);
        }

        private async void ProcessRequest(IGrainMessage message)
        {
            var requestMessage = (GrainMessageRequestEntity)message;

            var result = await (dynamic)Grain.GetType().GetTypeInfo().GetDeclaredMethod(requestMessage.MethodName).Invoke(Grain, requestMessage.Arguments);

            var response = new GrainMessageResponseEntity
            {
                RequesterSiloId = requestMessage.RequesterSiloId,
                ResponseTaskCompletionSourceId = requestMessage.ResponseTaskCompletionSourceId,
                Result = result
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

        private MessageQueue<GrainMessageRequestEntity> GetRequestMessageQueue()
        {
            if(_requestMessageQueue == null)
            {
                _requestMessageQueue = new MessageQueue<GrainMessageRequestEntity>();
                RequestMessageQueue.Process += ProcessRequest;
            }
            return _requestMessageQueue;
        }

        private MessageQueue<GrainMessageResponseEntity> GetResponsetMessageQueue()
        {
            if (_responseMessageQueue == null)
            {
                _responseMessageQueue = new MessageQueue<GrainMessageResponseEntity>();
                ResponseMessageQueue.Process += TransmitResponseMessage;
            }
            return _responseMessageQueue;
        }

        private void TransmitResponseMessage(IGrainMessage message)
        {
            MessageTransmit.TransmitResponseAsync((GrainMessageResponseEntity)message);
        }
    }
}
