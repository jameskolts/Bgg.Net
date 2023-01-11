using Bgg.Net.Common.Infrastructure.Extensions;
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
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.Infrastructure.IOC
{
    public static class ClassFactory
    {
        public static IServiceCollection RegisterBggCommon(this IServiceCollection services)
        {
            services.AddTransient<IHttpClient, BggClient>().AsSelf();
            services.AddTransient<ICollectionClient, CollectionClient>().AsSelf();
            services.AddTransient<IBggDeserializer, BggDeserializer>().AsSelf();
            services.AddTransient<IQueryBuilder, QueryBuilder>().AsSelf();
            services.AddTransient<IRequestValidatorFactory, RequestValidatorFactory>().AsSelf();
            services.AddTransient<IThingHandler, ThingHandler>().AsSelf();
            services.AddTransient<IFamilyHandler, FamilyHandler>().AsSelf();
            services.AddTransient<IForumHandler, ForumHandler>().AsSelf();
            services.AddTransient<IThreadHandler, ThreadHandler>().AsSelf();
            services.AddTransient<IUserHandler, UserHandler>().AsSelf();
            services.AddTransient<IGuildHandler, GuildHandler>().AsSelf();
            services.AddTransient<ICollectionHandler, CollectionHandler>().AsSelf();
            services.AddTransient<IHotItemsHandler, HotItemHandler>().AsSelf();
            services.AddTransient<ISearchHandler, SearchHandler>().AsSelf();
            services.AddTransient<IForumListHandler, ForumListHandler>().AsSelf();

            return services;
        }
    }
}
