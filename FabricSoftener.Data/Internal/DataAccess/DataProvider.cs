using FabricSoftener.Data.Configuration;
using FabricSoftener.Data.Internal.Interfaces;
using MongoDB.Driver;

namespace FabricSoftener.Data.Internal.DataAccess
{
    internal class DataProvider : IDataProvider
    {
        public IMongoDatabase GetDatabase()
        {
            return new MongoClient(DataConfig.ConnectionString).GetDatabase(DataConfig.DatabaseName);
        }
    }
}
