using FabricSoftener.Core.Internal.Interfaces;
using FabricSoftener.Core.Internal.ProxyManagement;
using FabricSoftener.Core.Internal.Silo;
using FabricSoftener.Data.Configuration;
using FabricSoftener.Interfaces.Silo;

namespace FabricSoftener.Core.Factory
{
    public class CoreFactory
    {
        public static ISiloController CreateSiloController(ISiloConfig config, ISilo silo)
        {
            DataConfig.ConnectionString = config.PersistanceDbConnectionString;
            return new SiloController(config, silo);
        }

        public static IProxyGrainFactory GrainFactory()
        {
            return new ProxyGrainFactory();
        }
    }
}
