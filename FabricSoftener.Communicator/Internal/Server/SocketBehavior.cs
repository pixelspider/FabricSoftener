using FabricSoftener.Communicator.Internal.Interfaces;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace FabricSoftener.Communicator.Internal.Server
{
    public class SocketBehavior : WebSocketBehavior
    {
        private readonly ISocketController _socketController;

        public SocketBehavior(ISocketController socketController)
        {
            _socketController = socketController;
            _socketController.SendData += Send;
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            _socketController.Request(e.RawData);
        }
    }
}
