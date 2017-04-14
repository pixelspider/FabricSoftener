using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface IProxyGrainFactory
    {
        TGrain CreateProxy<TGrain>() where TGrain : IGrain;
    }
}
