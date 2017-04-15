using System.Threading.Tasks;
using FabricSoftener.Data.Internal.Interfaces;
using FabricSoftener.Entities.Data;
using MongoDB.Driver;
using System.Collections.Generic;
using System;

namespace FabricSoftener.Data.Internal.DataAccess
{
    internal class SiloClusterDataContext : ISiloClusterDataContext
    {
        private IDataContext DataContext => _dataContext ?? (_dataContext = new DataContext());
        private IDataContext _dataContext;

        public SiloClusterDataContext(IDataContext dataContext = null)
        {
            _dataContext = dataContext;
        }

        public async Task<long> GetActiveSiloAnyClusterCountAsync()
        {
            return await DataContext.CountAsync(SiloClusterContextCollection, CreateMarkToUnregisterFilter(false));
        }

        public async Task<long> GetActiveSiloInClusterCountAsync(string clusterName)
        {
            var filter = Builders<SiloClusterEntity>.Filter.And(new List<FilterDefinition<SiloClusterEntity>>
            {
                CreateMarkToUnregisterFilter(false),
                Builders<SiloClusterEntity>.Filter.Eq(e => e.ClusterName, clusterName)
            });
            return await DataContext.CountAsync(SiloClusterContextCollection, filter);
        }

        public async Task<IEnumerable<SiloClusterEntity>> GetAllHostSilosAsync(string hostName)
        {
            return await DataContext.SortAsync(SiloClusterContextCollection,
                Builders<SiloClusterEntity>.Filter.Eq(e => e.HostName, hostName),
                Builders<SiloClusterEntity>.Sort.Ascending(s => s.HostPort));
        }

        public Task RegisterSiloAsync(SiloClusterEntity siloClusterEntity)
        {
            return DataContext.InsertOneAsync(SiloClusterContextCollection, siloClusterEntity);
        }

        private FilterDefinition<SiloClusterEntity> CreateMarkToUnregisterFilter(bool markToUnregister)
        {
            return Builders<SiloClusterEntity>.Filter.Eq(e => e.MarkToUnregister, markToUnregister);
        }

        private IMongoCollection<SiloClusterEntity> SiloClusterContextCollection => DataContext.GetCollection<SiloClusterEntity>("SiloCluster");
    }
}
