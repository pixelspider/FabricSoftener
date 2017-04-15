using System.Threading.Tasks;

namespace FabricSoftener.Communicator.Internal.Interfaces
{
    public interface ISocketClient
    {
        Task<TResponse> SendMessageAsync<TRequest, TResponse>(string endpoint, TRequest messageData);
    }
}
