using System.Threading.Tasks;
using FabricSoftener.Data.Interfaces;
using FabricSoftener.Data.Internal.Interfaces;
using FabricSoftener.Data.Internal.DataAccess;
using System.Collections.Generic;
using System.Linq;
using FabricSoftener.Entities.Data;
using System;

namespace FabricSoftener.Data.Repositories
{
    public class SiloClusterRepository : ISiloClusterRepository
    {
        private ISiloClusterDataContext DataContext => _dataContext ?? (_dataContext = new SiloClusterDataContext());
        private ISiloClusterDataContext _dataContext;

        public SiloClusterRepository(ISiloClusterDataContext dataContext = null)
        {
            _dataContext = dataContext;
        }

        public async Task<long> GetActiveSiloAnyClusterCountAsync()
        {
            return await DataContext.GetActiveSiloAnyClusterCountAsync();
        }

        public async Task<long> GetActiveSiloInClusterCountAsync(string clusterName)
        {
            return await DataContext.GetActiveSiloInClusterCountAsync(clusterName);
        }

        public async Task<IEnumerable<int>> GetAllHostPortsAsync(string hostName)
        {
            var hostSilos = await DataContext.GetAllHostSilosAsync(hostName);
            return hostSilos.Select(x => x.HostPort);
        }

        public Task RegisterSiloAsync(SiloClusterEntity siloClusterEntity)
        {
            return DataContext.RegisterSiloAsync(siloClusterEntity);
        }
    }
}
