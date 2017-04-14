using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.Core.Internal.GrainClient
{
    internal class GrainFactoryController : IGrainFactoryController
    {
        private readonly ISiloLocalGrainManager _siloLocalGrainManager;
        private readonly IProxyGrainFactory _proxyGrainFactory;

        public GrainFactoryController(ISiloLocalGrainManager siloLocalGrainManager, IProxyGrainFactory proxyGrainFactory)
        {
            _siloLocalGrainManager = siloLocalGrainManager;
            _proxyGrainFactory = proxyGrainFactory;
        }

        public TGrain GetGrain<TGrain>() where TGrain : IGrain
        {
            var localSiloGrain = _siloLocalGrainManager.GetGrain<TGrain>();
            if (localSiloGrain != null)
                return localSiloGrain;
            return _proxyGrainFactory.CreateProxy<TGrain>();
        }
    }
}
