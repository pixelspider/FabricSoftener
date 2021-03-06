﻿using FabricSoftener.Entities.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricSoftener.Data.Internal.Interfaces
{
    public interface ISiloClusterDataContext
    {
        Task<long> GetActiveSiloAnyClusterCountAsync();
        Task<long> GetActiveSiloInClusterCountAsync(string clusterName);
        Task<IEnumerable<SiloClusterEntity>> GetAllHostSilosAsync(string hostName);
        Task RegisterSiloAsync(SiloClusterEntity siloClusterEntity);
    }
}
