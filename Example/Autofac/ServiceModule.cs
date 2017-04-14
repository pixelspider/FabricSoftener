using Autofac;
using Example.StartUp;
using FabricSoftener.GrainClient;
using FabricSoftener.Host;
using FabricSoftener.Interfaces;
using FabricSoftener.Interfaces.GrainClient;
using FabricSoftener.Interfaces.Silo;

namespace Example.Autofac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExampleSiloConfig>().As<ISiloConfig>();
            builder.RegisterType<ExampleSilo>().As<ISilo>();
            builder.RegisterType<TopShelfSiloApplication>().As<ITopShelfSiloApplication>();
            builder.RegisterType<GrainFactory>().As<IGrainFactory>();
        }
    }
}
