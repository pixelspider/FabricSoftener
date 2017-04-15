using FabricSoftener.Interfaces.GrainClient;
using System.Threading.Tasks;

namespace FabricSoftener.Core.ServerGrains.Interfaces
{
    public interface ISiloManagmentGrain :IGrain
    {
        Task<bool> RegisterSiloAsync(string clusterName, string hostName);
    }
}
