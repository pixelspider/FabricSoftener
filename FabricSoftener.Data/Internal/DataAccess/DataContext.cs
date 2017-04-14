using System.Collections.Generic;
using System.Threading.Tasks;
using FabricSoftener.Data.Internal.Interfaces;
using FabricSoftener.Entities.Data;
using MongoDB.Driver;

namespace FabricSoftener.Data.Internal.DataAccess
{
    internal class DataContext : IDataContext
    {
        private readonly IDataProvider _dataProvider;

        public DataContext(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public FilterDefinition<TEntity> CreateIdFilter<TEntity>(string id) where TEntity : IEntity
        {
            return Builders<TEntity>.Filter.Eq(e => e.Id, id);
        }

        public async Task<IEnumerable<TEntity>> FindAsync<TEntity>(IMongoCollection<TEntity> contextCollection, FilterDefinition<TEntity> filter) where TEntity : IEntity
        {
            return await contextCollection.Find(filter).ToListAsync();
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName) where TEntity : IEntity
        {
            return _dataProvider.GetDatabase().GetCollection<TEntity>(collectionName);
        }

        public async Task<IEnumerable<TEntity>> SortAsync<TEntity>(IMongoCollection<TEntity> contextCollection, FilterDefinition<TEntity> filter, SortDefinition<TEntity> sort) where TEntity : IEntity
        {
            return await contextCollection.Find(filter).Sort(sort).ToListAsync();
        }
    }
}
