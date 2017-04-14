using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface ISiloLocalGrainManager
    {
        TGrain GetGrain<TGrain>() where TGrain : IGrain;
    }
}
