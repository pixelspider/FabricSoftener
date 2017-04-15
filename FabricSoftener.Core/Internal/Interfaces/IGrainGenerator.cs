using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface IGrainGenerator<TGrain> where TGrain : IGrain
    {
        TGrain Generate();
    }
}
