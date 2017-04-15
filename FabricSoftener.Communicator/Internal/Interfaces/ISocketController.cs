using FabricSoftener.Communicator.Internal.Server;

namespace FabricSoftener.Communicator.Internal.Interfaces
{
    public interface ISocketController
    {
        void Request(byte[] messageData);
        void Response(byte[] messageData);
        event SocketServer.SendData SendData;
    }
}
