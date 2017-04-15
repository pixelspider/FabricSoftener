namespace FabricSoftener.Communicator.Internal.Interfaces
{
    internal interface ISocketClientProvider
    {
        ISocketClientConnetion GetConnection(string endpoint);
    }
}
