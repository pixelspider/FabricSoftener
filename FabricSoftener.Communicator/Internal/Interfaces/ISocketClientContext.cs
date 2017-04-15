using System.Threading.Tasks;

namespace FabricSoftener.Communicator.Internal.Interfaces
{
    internal interface ISocketClientContext
    {
        Task<byte[]> SendMessageAsync(string endpoint, byte[] messageData);
    }
}
