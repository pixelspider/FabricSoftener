namespace FabricSoftener.Interfaces.GrainClient
{
    public interface IGrainFactoryController
    {
        TGrain GetGrain<TGrain>() where TGrain : IGrain;
    }
}
