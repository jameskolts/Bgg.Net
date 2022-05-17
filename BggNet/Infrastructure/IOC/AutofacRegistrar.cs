using Autofac;
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
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
            builder.RegisterType<ThingDeserializer>().As<IThingDeserializer>().AsSelf();
            builder.RegisterType<ThingHandler>().As<IThingHandler>().AsSelf();
            builder.RegisterType<FamilyDeserializer>().As<IFamilyDeserializer>().AsSelf();
            builder.RegisterType<FamilyHandler>().As<IFamilyHandler>().AsSelf();
            builder.RegisterType<ThreadDeserializer>().As<IThreadDeserializer>().AsSelf();
            builder.RegisterType<ForumDeserializer>().As<IForumDeserializer>().AsSelf();
            builder.RegisterType<ForumListDeserializer>().As<IForumListDeserializer>().AsSelf();
            builder.RegisterType<ForumListHandler>().As<IForumListHandler>().AsSelf();
            builder.RegisterType<BggDeserializer>().As<IBggDeserializer>().AsSelf();
            builder.RegisterType<ForumHandler>().As<IForumHandler>().AsSelf();

            return builder.Build();
        }
    }
}
