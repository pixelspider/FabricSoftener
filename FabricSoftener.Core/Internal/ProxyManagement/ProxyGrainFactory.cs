using DynamicProxy;
using FabricSoftener.Interfaces.GrainClient;
using FabricSoftener.Core.Internal.Interfaces;

namespace FabricSoftener.Core.Internal.ProxyManagement
{
    internal class ProxyGrainFactory : IProxyGrainFactory
    {
        private IProxyInvocation ProxyInvocation => _proxyInvocation ?? (_proxyInvocation = new ProxyInvocation());
        private IProxyInvocation _proxyInvocation;

        public ProxyGrainFactory(IProxyInvocation proxyInvocation = null)
        {
            _proxyInvocation = proxyInvocation;
        }

        public TGrain CreateProxy<TGrain>() where TGrain : IGrain
        {
            return Proxy.CreateProxy<TGrain>(ProxyInvocation.Invocate<TGrain>);
        }
    }
}
