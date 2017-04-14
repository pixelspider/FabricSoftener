using FabricSoftener.Interfaces.Silo;
using System.Configuration;

namespace Example.StartUp
{
    public class ExampleSiloConfig : ISiloConfig
    {
        public string Description => "Example Service Host";
        public string DisplayName => "Example Service";
        public string ServiceName => "Example.Service";
        public string PersistanceDbConnectionString => ConfigurationManager.AppSettings["PersistanceDbConnectionString"] ?? string.Empty;
    }
}
