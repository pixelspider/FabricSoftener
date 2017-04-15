using FabricSoftener.Entities.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricSoftener.Data.Interfaces
{
    public interface ISiloClusterRepository
    {
        Task<long> GetActiveSiloAnyClusterCountAsync();
        Task<long> GetActiveSiloInClusterCountAsync(string clusterName);
        Task<IEnumerable<int>> GetAllHostPortsAsync(string hostName);
        Task RegisterSiloAsync(SiloClusterEntity siloClusterEntity);
    }
}
