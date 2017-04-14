using DynamicProxy;
using System.Threading.Tasks;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface IProxyInvocation
    {
        Task<object> Invocate<TGrain>(Invocation args);
    }
}
