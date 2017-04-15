using FabricSoftener.Communicator.Internal.Interfaces;
using WebSocketSharp.Server;

namespace FabricSoftener.Communicator.Internal.Server
{
    public class SocketServer : ISocketServer
    {
        private WebSocketServer WebSocketServer => _webSocketServer ?? (_webSocketServer = new WebSocketServer(_endpoint));
        private WebSocketServer _webSocketServer;
        private readonly string _endpoint;

        public SocketServer(string endpoint)
        {
            _endpoint = endpoint;
        }

        public void AddSocketService(string path, ISocketController socketController)
        {
            WebSocketServer.AddWebSocketService(path, () => new SocketBehavior(socketController));
        }

        public void Start()
        {
            WebSocketServer.Start();
        }

        public void Stop()
        {
            WebSocketServer.Stop();
        }

        public delegate void SendData(byte[] data);
    }
}
