using System.Threading.Tasks;
using System.Linq;
using FabricSoftener.Data.Interfaces;
using FabricSoftener.Data.Repositories;
using FabricSoftener.Entities.Data;
using System;
using FabricSoftener.Core.ServerGrains.Interfaces;

namespace FabricSoftener.Core.ServerGrains.SiloManagment
{
    internal class SiloManagmentHelper : ISiloManagmentHelper
    {
        private const int FIRST_PORT = 3000;
        private const int LAST_PORT = 4000;

        private ISiloClusterRepository SiloClusterRepository => _siloClusterRepository ?? (_siloClusterRepository = new SiloClusterRepository());
        private ISiloClusterRepository _siloClusterRepository;

        public SiloManagmentHelper(ISiloClusterRepository siloClusterRepository = null)
        {
            _siloClusterRepository = siloClusterRepository;
        }

        public async Task<int> GetNextAvailablePortAsync(string hostName)
        {
            var ports = await SiloClusterRepository.GetAllHostPortsAsync(hostName);
            if (ports.Count() == 0)
                return FIRST_PORT;
            var firstAvailable = Enumerable.Range(FIRST_PORT, LAST_PORT).Except(ports).FirstOrDefault();
            if (firstAvailable > 0)
                return firstAvailable;
            return ports.Last() + 1;
        }

        public async Task<bool> RegisterSiloAsync(string clusterName, string hostName, int port)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            await SiloClusterRepository.RegisterSiloAsync(new SiloClusterEntity
            {
                ClusterName = clusterName,
                MarkToUnregister = false,
                HostName = hostName,
                HostPort = port
            }).ContinueWith((result) => { taskCompletionSource.SetResult(true); });

            return await taskCompletionSource.Task;
        }
    }
}
