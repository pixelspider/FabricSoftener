using FabricSoftener.Entities.Data;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricSoftener.Data.Internal.Interfaces
{
    internal interface IDataContext
    {
        Task InsertOneAsync<TEntity>(IMongoCollection<TEntity> contextCollection, TEntity data) where TEntity : IEntity;
        IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName) where TEntity : IEntity;
        FilterDefinition<TEntity> CreateIdFilter<TEntity>(string id) where TEntity : IEntity;
        Task<long> CountAsync<TEntity>(IMongoCollection<TEntity> contextCollection, FilterDefinition<TEntity> filter) where TEntity : IEntity;
        Task<IEnumerable<TEntity>> FindAsync<TEntity>(IMongoCollection<TEntity> contextCollection, FilterDefinition<TEntity> filter) where TEntity : IEntity;
        Task<IEnumerable<TEntity>> SortAsync<TEntity>(IMongoCollection<TEntity> contextCollection, FilterDefinition<TEntity> filter, SortDefinition<TEntity> sort) where TEntity : IEntity;
    }
}
