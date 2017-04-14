using FabricSoftener.Core.Internal.Interfaces;
using System.Threading.Tasks;

namespace FabricSoftener.Core.Internal.ProxyManagement
{
    internal class ProxyInvocation : IProxyInvocation
    {
        public Task<object> Invocate<TGrain>(DynamicProxy.Invocation args)
        {
            return Task.FromResult((object)1234);
        }
    }
}
