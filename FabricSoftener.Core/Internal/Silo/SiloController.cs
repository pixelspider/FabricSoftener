using FabricSoftener.Core.Factory;
using FabricSoftener.Core.ServerGrains.Interfaces;
using FabricSoftener.Interfaces.Silo;
using System.Net;

namespace FabricSoftener.Core.Internal.Silo
{
    internal class SiloController : ISiloController
    {
        private readonly ISiloConfig _config;
        private readonly ISilo _silo;

        public SiloController(ISiloConfig config, ISilo silo)
        {
            _config = config;
            _silo = silo;
        }

        public async void Start()
        {
            var siloManagmentGrain = CoreFactory.GrainFactory().CreateProxy<ISiloManagmentGrain>();
            var success = await siloManagmentGrain.RegisterSiloAsync(_config.ServiceName, Dns.GetHostName());
            if (success)
            {
                _silo.Start();
            }
            else
            {
                _silo.Stop();
            }
        }

        public void Stop()
        {
            _silo.Stop();
        }
    }
}
