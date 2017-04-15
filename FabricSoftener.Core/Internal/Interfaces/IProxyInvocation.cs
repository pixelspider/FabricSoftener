using DynamicProxy;
using FabricSoftener.Interfaces.GrainClient;
using System.Threading.Tasks;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface IProxyInvocation
    {
        Task<object> Invocate<TGrain>(Invocation args) where TGrain : IGrain;
    }
}
