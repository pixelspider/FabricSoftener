namespace FabricSoftener.Interfaces.Silo
{
    public interface ISiloConfig
    {
        string Description { get; }
        string DisplayName { get; }
        string ServiceName { get; }
        string PersistanceDbConnectionString { get; }
    }
}
