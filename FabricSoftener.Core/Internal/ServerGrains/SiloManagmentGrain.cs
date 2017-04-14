using System;
using System.Threading.Tasks;
using FabricSoftener.Core.Internal.Interfaces.ServerGrains;

namespace FabricSoftener.Core.Internal.ServerGrains
{
    internal class SiloManagmentGrain : ISiloManagmentGrain
    {
        public SiloManagmentGrain()
        {

        }

        public Task<bool> CreateSiloAsync(string clusterName, string endPoint)
        {
            throw new NotImplementedException();
        }
    }
}
