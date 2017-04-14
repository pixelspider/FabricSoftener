using FabricSoftener.Data.Internal.DataAccess;
using FabricSoftener.Data.Internal.Interfaces;

namespace FabricSoftener.Data.Internal.Factory
{
    internal class ContextFactory
    {
        public static ISiloClusterDataContext CreateSiloClusterDataContext()
        {
            return new SiloClusterDataContext(CreateDataContext());
        }

        private static IDataContext CreateDataContext()
        {
            return new DataContext(new DataProvider());
        }
    }
}
