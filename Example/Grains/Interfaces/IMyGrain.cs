using FabricSoftener.Interfaces.GrainClient;
using System.Threading.Tasks;

namespace Example.Grains.Interfaces
{
    public interface IMyGrain : IGrain
    {
        Task<int> CalculateSumAsync(int val1, int val2);
    }
}
