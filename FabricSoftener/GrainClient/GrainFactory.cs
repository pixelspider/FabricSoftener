using FabricSoftener.Core.Factory;
using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.GrainClient
{
    public class GrainFactory : IGrainFactory
    {
        private static IProxyGrainFactory _proxyGrainFactory;

        public TGrain GetGrain<TGrain>() where TGrain : IGrain
        {
            return ProxyGrainFactory.CreateProxy<TGrain>();
        }

        private static IProxyGrainFactory ProxyGrainFactory => _proxyGrainFactory ?? (_proxyGrainFactory = CoreFactory.GrainFactory());
    }
}
