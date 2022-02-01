using Autofac;
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Resources.Families;
using Bgg.Net.Common.Resources.Things;
using Serilog;
using IContainer = Autofac.IContainer;

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
            builder.RegisterType<FamilyDeserializer>().As<IFamilyDeserializer>().AsSelf();
            builder.RegisterType<FamilyHandler>().As<IFamilyHandler>().AsSelf();

            Container = builder.Build();
        }
    }
}
