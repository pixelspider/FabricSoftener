using System.Threading.Tasks;

namespace FabricSoftener.Communicator.Internal.Interfaces
{
    internal interface ISocketClientConnetion
    {
        Task<byte[]> SendMessageAsync(byte[] messageData);
    }
}
