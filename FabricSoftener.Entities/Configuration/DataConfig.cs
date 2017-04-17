using System;

namespace FabricSoftener.Entities.Configuration
{
    public class DataConfig
    {
        private static string _siloID;
        public static string SiloID => _siloID ?? (_siloID = Guid.NewGuid().ToString());
        public static string ConnectionString { get; set; }
        public static string DatabaseName => "FabricSoftener";
    }
}
