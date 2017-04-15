using FabricSoftener.Interfaces.GrainClient;
using System;

namespace FabricSoftener.Core.Internal.Interfaces
{
    internal interface IAssemblyRepository
    {
        Type GetActualType<TGrain>() where TGrain : IGrain;
    }
}
