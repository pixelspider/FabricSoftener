using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.Core.Internal.Silo
{
    internal class SiloLocalGrainManager : ISiloLocalGrainManager
    {
        public TGrain GetGrain<TGrain>() where TGrain : IGrain
        {
            return default(TGrain);
        }
    }
}
