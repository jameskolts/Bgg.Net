using Autofac;
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Resources.Things;
using IContainer = Autofac.IContainer;
using Serilog;

namespace Bgg.Net.Common.Infrastructure.IOC
{
    public class AutofacRegistrar
    {
        public static IContainer Container { get; private set; }

        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register<ILogger>((c, p) =>
            {
                return new LoggerConfiguration()
                    .WriteTo.Console()
                    .CreateLogger();
            }).SingleInstance();

            builder.RegisterType<BggClient>().As<IHttpClient>().AsSelf();
            builder.RegisterType<ThingDeserializer>().As<IThingDeserializer>().AsSelf();
            builder.RegisterType<ThingHandler>().As<IThingHandler>().AsSelf();

            Container = builder.Build();
        }
    }
}
