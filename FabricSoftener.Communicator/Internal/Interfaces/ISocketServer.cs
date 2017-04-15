namespace FabricSoftener.Communicator.Internal.Interfaces
{
    public interface ISocketServer
    {
        void Start();
        void Stop();
        void AddSocketService(string path, ISocketController socketController);
    }
}
