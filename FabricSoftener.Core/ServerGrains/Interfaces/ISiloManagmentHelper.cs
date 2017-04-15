using System.Threading.Tasks;

namespace FabricSoftener.Core.ServerGrains.Interfaces
{
    public interface ISiloManagmentHelper
    {
        Task<int> GetNextAvailablePortAsync(string hostName);
        Task<bool> RegisterSiloAsync(string clusterName, string hostName, int port);
    }
}
