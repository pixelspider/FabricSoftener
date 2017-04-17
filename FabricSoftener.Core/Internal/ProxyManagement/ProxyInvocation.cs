using DynamicProxy;
using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Core.Internal.Message;
using FabricSoftener.Entities.Message;
using FabricSoftener.Interfaces.GrainClient;
using System.Threading.Tasks;

namespace FabricSoftener.Core.Internal.ProxyManagement
{
    internal class ProxyInvocation : IProxyInvocation
    {
        private IMessageTransmit MessageTransmit => _messageTransmit ?? (_messageTransmit = new MessageTransmit());
        private IMessageTransmit _messageTransmit;

        public async Task<object> Invocate<TGrain>(Invocation args) where TGrain : IGrain
        {
            var message = new GrainMessageRequestEntity
            {
                GrainType = typeof(TGrain),
                MethodName = args.Method.Name,
                Arguments = args.Arguments
            };

            var taskCompletionSource = MessageTransmit.TransmitRequestFromProxyAsync(message);

            return await taskCompletionSource.Task;
        }
    }
}
