using FabricSoftener.Interfaces.GrainClient;
using System.Threading.Tasks;

namespace FabricSoftener.Core.Internal.Interfaces.ServerGrains
{
    internal interface ISiloManagmentGrain :IGrain
    {
        Task<bool> CreateSiloAsync(string clusterName, string endPoint);
    }
}
