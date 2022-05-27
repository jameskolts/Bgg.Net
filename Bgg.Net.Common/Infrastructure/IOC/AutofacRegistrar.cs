using Autofac;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.RequestHandlers.Collection;
using Bgg.Net.Common.RequestHandlers.Families;
using Bgg.Net.Common.RequestHandlers.Forums;
using Bgg.Net.Common.RequestHandlers.Guilds;
using Bgg.Net.Common.RequestHandlers.HotItems;
using Bgg.Net.Common.RequestHandlers.Search;
using Bgg.Net.Common.RequestHandlers.Things;
using Bgg.Net.Common.RequestHandlers.Threads;
using Bgg.Net.Common.RequestHandlers.Users;
using Serilog;
using IContainer = Autofac.IContainer;
using SearchHandler = Bgg.Net.Common.RequestHandlers.Search.SearchHandler;

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
            builder.RegisterType<CollectionClient>().As<ICollectionClient>().AsSelf();
            builder.RegisterType<BggDeserializer>().As<IBggDeserializer>().AsSelf();
            builder.RegisterType<ThingHandler>().As<IThingHandler>().AsSelf();
            builder.RegisterType<FamilyHandler>().As<IFamilyHandler>().AsSelf();
            builder.RegisterType<ForumListHandler>().As<IForumListHandler>().AsSelf();
            builder.RegisterType<ForumHandler>().As<IForumHandler>().AsSelf();
            builder.RegisterType<ThreadHandler>().As<IThreadHandler>().AsSelf();
            builder.RegisterType<UserHandler>().As<IUserHandler>().AsSelf();
            builder.RegisterType<GuildHandler>().As<IGuildHandler>().AsSelf();
            builder.RegisterType<CollectionHandler>().As<ICollectionHandler>().AsSelf();
            builder.RegisterType<HotItemHandler>().As<IHotItemsHandler>().AsSelf();
            builder.RegisterType<SearchHandler>().As<ISearchHandler>().AsSelf();

            return builder.Build();
        }
    }
}
