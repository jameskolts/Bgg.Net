using Autofac;
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.RequestHandlers.Families;
using Bgg.Net.Common.RequestHandlers.Things;
using Bgg.Net.Common.RequestHandlers.ForumsList;
using Bgg.Net.Common.RequestHandlers.Forums;
using Serilog;
using IContainer = Autofac.IContainer;

namespace Bgg.Net.Common.Infrastructure.IOC
{
    public class AutofacRegistrar
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register<ILogger>((c, p) =>
            {
                return new LoggerConfiguration()
                    .WriteTo.Console()
                    .CreateLogger();
            }).SingleInstance();

            builder.RegisterType<BggClient>().As<IHttpClient>().AsSelf();
            builder.RegisterType<BggDeserializer>().As<IBggDeserializer>().AsSelf();
            builder.RegisterType<ThingHandler>().As<IThingHandler>().AsSelf();
            builder.RegisterType<FamilyHandler>().As<IFamilyHandler>().AsSelf();
            builder.RegisterType<ForumListHandler>().As<IForumListHandler>().AsSelf();
            builder.RegisterType<ForumHandler>().As<IForumHandler>().AsSelf();

            return builder.Build();
        }
    }
}
