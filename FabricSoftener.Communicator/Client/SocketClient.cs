using System.Threading.Tasks;
using FabricSoftener.Communicator.Internal.Interfaces;
using FabricSoftener.Communicator.Internal.Client;
using FabricSoftener.Communicator.Internal.Extensions;

namespace FabricSoftener.Communicator.Client
{
    public class SocketClient : ISocketClient
    {
        private ISocketClientContext SocketClientContext => _socketClientContext ?? (_socketClientContext = new SocketClientContext());
        private ISocketClientContext _socketClientContext;

        public async Task<TResponse> SendMessageAsync<TRequest, TResponse>(string endpoint, TRequest messageData)
        {
            var response = await SocketClientContext.SendMessageAsync(endpoint, messageData.Serialiser());
            return response.Deserialiser<TResponse>();
        }
    }
}
