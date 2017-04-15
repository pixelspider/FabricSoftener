using FabricSoftener.Communicator.Internal.Interfaces;

namespace FabricSoftener.Communicator.Internal.Server
{
    public abstract class BaseSocketController : ISocketController
    {
        public event SocketServer.SendData SendData;

        public abstract void Request(byte[] messageData);

        public void Response(byte[] messageData)
        {
            SendData?.Invoke(messageData);
        }
    }
}
