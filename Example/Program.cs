using Autofac;
using Example.Autofac;
using FabricSoftener.Interfaces;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DiConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ITopShelfSiloApplication>();
                app.Run();
            }
        }
    }
}
