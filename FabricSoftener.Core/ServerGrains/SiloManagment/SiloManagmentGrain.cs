using System.Threading.Tasks;
using FabricSoftener.Entities.Attributes;
using FabricSoftener.Core.ServerGrains.Interfaces;

namespace FabricSoftener.Core.ServerGrains.SiloManagment
{
    [GlobalSiloInstance]
    public class SiloManagmentGrain : ISiloManagmentGrain
    {
        private ISiloManagmentHelper SiloManagmentHelper => _siloManagmentHelper ?? (_siloManagmentHelper = new SiloManagmentHelper());
        private ISiloManagmentHelper _siloManagmentHelper;

        public SiloManagmentGrain() : this(null) { }
        public SiloManagmentGrain(ISiloManagmentHelper siloManagmentHelper = null)
        {
            _siloManagmentHelper = siloManagmentHelper;
        }

        public async Task<bool> RegisterSiloAsync(string clusterName, string hostName)
        {
            var hostPort = await SiloManagmentHelper.GetNextAvailablePortAsync(hostName);
            return await SiloManagmentHelper.RegisterSiloAsync(clusterName, hostName, hostPort);
        }
    }
}
