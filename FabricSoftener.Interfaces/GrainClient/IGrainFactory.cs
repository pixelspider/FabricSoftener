namespace FabricSoftener.Interfaces.GrainClient
{
    public interface IGrainFactory
    {
        TGrain GetGrain<TGrain>() where TGrain : IGrain;
    }
}
