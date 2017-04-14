using System;
using System.Threading.Tasks;
using FabricSoftener.Data.Internal.Interfaces;

namespace FabricSoftener.Data.Internal.DataAccess
{
    internal class SiloClusterDataContext : ISiloClusterDataContext
    {
        private readonly IDataContext _dataContext;

        public SiloClusterDataContext(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<int> GetSiloCount()
        {
            throw new NotImplementedException();
        }
    }
}
