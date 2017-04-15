using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabricSoftener.Data.Internal.Interfaces;
using FabricSoftener.Entities.Data;
using MongoDB.Driver;

namespace FabricSoftener.Data.Internal.DataAccess
{
    internal class DataContext : IDataContext
    {
        private IDataProvider DataProvider => _dataProvider ?? (_dataProvider = new DataProvider());
        private IDataProvider _dataProvider;

        public DataContext(IDataProvider dataProvider = null)
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
            return DataProvider.GetDatabase().GetCollection<TEntity>(collectionName);
        }

        public async Task<IEnumerable<TEntity>> SortAsync<TEntity>(IMongoCollection<TEntity> contextCollection, FilterDefinition<TEntity> filter, SortDefinition<TEntity> sort) where TEntity : IEntity
        {
            return await contextCollection.Find(filter).Sort(sort).ToListAsync();
        }

        public async Task<long> CountAsync<TEntity>(IMongoCollection<TEntity> contextCollection, FilterDefinition<TEntity> filter) where TEntity : IEntity
        {
            return await contextCollection.CountAsync(filter);
        }

        public Task InsertOneAsync<TEntity>(IMongoCollection<TEntity> contextCollection, TEntity data) where TEntity : IEntity
        {
            return contextCollection.InsertOneAsync(data);
        }
    }
}
