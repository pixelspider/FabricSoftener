using System.Threading.Tasks;

namespace FabricSoftener.Data.Internal.Interfaces
{
    internal interface ISiloClusterDataContext
    {
        Task<int> GetSiloCount();
    }
}
