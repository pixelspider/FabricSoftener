using MongoDB.Driver;

namespace FabricSoftener.Data.Internal.Interfaces
{
    internal interface IDataProvider
    {
        IMongoDatabase GetDatabase();
    }
}
