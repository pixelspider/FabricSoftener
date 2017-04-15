using FabricSoftener.Communicator.Internal.Interfaces;
using WebSocketSharp;

namespace FabricSoftener.Communicator.Internal.Client
{
    internal class SocketClientProvider : ISocketClientProvider
    {
        public ISocketClientConnetion GetConnection(string endpoint)
        {
            return new SocketClientConnetion(new WebSocket(endpoint));
        }
    }
}
