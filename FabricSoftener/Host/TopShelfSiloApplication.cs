using FabricSoftener.Core.Factory;
using FabricSoftener.Interfaces;
using FabricSoftener.Interfaces.Silo;
using Topshelf;

namespace FabricSoftener.Host
{
    public class TopShelfSiloApplication : ITopShelfSiloApplication
    {
        private readonly ISiloConfig _config;
        private readonly ISilo _silo;

        public TopShelfSiloApplication(ISiloConfig config, ISilo silo)
        {
            _config = config;
            _silo = silo;
        }

        public void Run()
        {
            HostFactory.Run(x =>
            {
                x.Service<ISilo>(s =>
                {
                    s.ConstructUsing(() => CoreFactory.CreateSiloController(_config, _silo));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription(_config.Description);
                x.SetDisplayName(_config.DisplayName);
                x.SetServiceName(_config.ServiceName);
            });
        }
    }
}
