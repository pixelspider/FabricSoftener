using System.Threading.Tasks;
using FabricSoftener.Communicator.Internal.Interfaces;

namespace FabricSoftener.Communicator.Internal.Client
{
    internal class SocketClientContext : ISocketClientContext
    {
        private ISocketClientProvider SocketClientProvider => _socketClientProvider ?? (_socketClientProvider = new SocketClientProvider());
        private ISocketClientProvider _socketClientProvider;

        private ISocketClientConnetion _socketClientConnetion;

        public async Task<byte[]> SendMessageAsync(string endpoint, byte[] messageData)
        {
            _socketClientConnetion = SocketClientProvider.GetConnection(endpoint);
            return await _socketClientConnetion.SendMessageAsync(messageData);
        }
    }
}
