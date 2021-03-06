﻿using FabricSoftener.Interfaces.GrainClient;

namespace FabricSoftener.Core.Internal.Interfaces
{
    public interface IProxyGrainFactory
    {
        TGrain CreateProxy<TGrain>() where TGrain : IGrain;
    }
}
