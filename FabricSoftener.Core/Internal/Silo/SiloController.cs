using FabricSoftener.Interfaces.Silo;

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

        public void Start()
        {
            _silo.Start();
        }

        public void Stop()
        {
            _silo.Stop();
        }
    }
}
