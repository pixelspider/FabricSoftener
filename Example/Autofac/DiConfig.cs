using Autofac;

namespace Example.Autofac
{
    public class DiConfig
    {
        public static ContainerBuilder _builder;
        public static IContainer Configure()
        {
            _builder = new ContainerBuilder();
            _builder.RegisterModule<ServiceModule>();
            return _builder.Build();
        }
    }
}
