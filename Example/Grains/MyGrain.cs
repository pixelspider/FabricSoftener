using Example.Grains.Interfaces;
using System.Threading.Tasks;

namespace Example.Grains
{
    public class MyGrain : IMyGrain
    {
        public Task<int> CalculateSumAsync(int val1, int val2)
        {
            return Task.FromResult(val1 + val2);
        }
    }
}
