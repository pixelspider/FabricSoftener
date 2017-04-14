using DynamicProxy;
using FabricSoftener.Interfaces.GrainClient;
using FabricSoftener.Core.Internal.Interfaces;

namespace FabricSoftener.Core.Internal.ProxyManagement
{
    internal class ProxyGrainFactory : IProxyGrainFactory
    {
        private readonly IProxyInvocation _proxyInvocation;

        public ProxyGrainFactory(IProxyInvocation proxyInvocation)
        {
            _proxyInvocation = proxyInvocation;
        }

        public TGrain CreateProxy<TGrain>() where TGrain : IGrain
        {
            return Proxy.CreateProxy<TGrain>(_proxyInvocation.Invocate<TGrain>);
        }
    }
}
