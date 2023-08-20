using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Common.RequestHandlers.Collection;
using Bgg.Net.Common.RequestHandlers.Families;
using Bgg.Net.Common.RequestHandlers.Forums;
using Bgg.Net.Common.RequestHandlers.Guilds;
using Bgg.Net.Common.RequestHandlers.HotItems;
using Bgg.Net.Common.RequestHandlers.Search;
using Bgg.Net.Common.RequestHandlers.Things;
using Bgg.Net.Common.RequestHandlers.Users;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.Tests.Infrastructure.IOC
{
    [TestClass]
    public class ClassFactoryTests
    {
        private ServiceProvider? provider;

        [TestInitialize]
        public void Init()
        {
            var services = new ServiceCollection();
            services.RegisterBggCommon();
            services.AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));
            services.AddLogging(x => x.SetMinimumLevel(LogLevel.Debug).AddConsole());

            provider = services.BuildServiceProvider();
        }

        [TestCleanup]
        public void Cleanup()
        {
            provider?.Dispose();
        }

        [TestMethod]
        public void BggClient_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<IHttpClient>();
            var objFromClass = provider?.GetService<BggClient>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<BggClient>();
            objFromInterface?.GetType().Name.Should().Be("BggClient");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<BggClient>();
            objFromClass?.GetType().Name.Should().Be("BggClient");
        }

        [TestMethod]
        public void ThingHandler_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<IThingHandler>();
            var objFromClass = provider?.GetService<ThingHandler>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<ThingHandler>();
            objFromInterface?.GetType().Name.Should().Be("ThingHandler");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<ThingHandler>();
            objFromClass?.GetType().Name.Should().Be("ThingHandler");
        }

        [TestMethod]
        public void FamilyHandler_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<IFamilyHandler>();
            var objFromClass = provider?.GetService<FamilyHandler>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<FamilyHandler>();
            objFromInterface?.GetType().Name.Should().Be("FamilyHandler");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<FamilyHandler>();
            objFromClass?.GetType().Name.Should().Be("FamilyHandler");
        }

        [TestMethod]
        public void ForumListHandler_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<IForumListHandler>();
            var objFromClass = provider?.GetService<ForumListHandler>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<ForumListHandler>();
            objFromInterface?.GetType().Name.Should().Be("ForumListHandler");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<ForumListHandler>();
            objFromClass?.GetType().Name.Should().Be("ForumListHandler");
        }

        [TestMethod]
        public void ForumHandler_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<IForumHandler>();
            var objFromClass = provider?.GetService<ForumHandler>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<ForumHandler>();
            objFromInterface?.GetType().Name.Should().Be("ForumHandler");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<ForumHandler>();
            objFromClass?.GetType().Name.Should().Be("ForumHandler");
        }

        [TestMethod]
        public void GuildHandler_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<IGuildHandler>();
            var objFromClass = provider?.GetService<GuildHandler>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<GuildHandler>();
            objFromInterface?.GetType().Name.Should().Be("GuildHandler");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<GuildHandler>();
            objFromClass?.GetType().Name.Should().Be("GuildHandler");
        }

        [TestMethod]
        public void UserHandler_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<IUserHandler>();
            var objFromClass = provider?.GetService<UserHandler>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<UserHandler>();
            objFromInterface?.GetType().Name.Should().Be("UserHandler");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<UserHandler>();
            objFromClass?.GetType().Name.Should().Be("UserHandler");
        }

        [TestMethod]
        public void CollectionClient_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<ICollectionClient>();
            var objFromClass = provider?.GetService<CollectionClient>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<CollectionClient>();
            objFromInterface?.GetType().Name.Should().Be("CollectionClient");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<CollectionClient>();
            objFromClass?.GetType().Name.Should().Be("CollectionClient");
        }

        [TestMethod]
        public void CollectionHandler_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<ICollectionHandler>();
            var objFromClass = provider?.GetService<CollectionHandler>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<CollectionHandler>();
            objFromInterface?.GetType().Name.Should().Be("CollectionHandler");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<CollectionHandler>();
            objFromClass?.GetType().Name.Should().Be("CollectionHandler");
        }

        [TestMethod]
        public void HotItemHandler_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<IHotItemsHandler>();
            var objFromClass = provider?.GetService<HotItemHandler>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<HotItemHandler>();
            objFromInterface?.GetType().Name.Should().Be("HotItemHandler");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<HotItemHandler>();
            objFromClass?.GetType().Name.Should().Be("HotItemHandler");
        }

        [TestMethod]
        public void SearchHandler_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<ISearchHandler>();
            var objFromClass = provider?.GetService<SearchHandler>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<SearchHandler>();
            objFromInterface?.GetType().Name.Should().Be("SearchHandler");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<SearchHandler>();
            objFromClass?.GetType().Name.Should().Be("SearchHandler");
        }

        [TestMethod]
        public void RequestValidatorFactory_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<IRequestValidatorFactory>();
            var objFromClass = provider?.GetService<RequestValidatorFactory>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<RequestValidatorFactory>();
            objFromInterface?.GetType().Name.Should().Be("RequestValidatorFactory");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<RequestValidatorFactory>();
            objFromClass?.GetType().Name.Should().Be("RequestValidatorFactory");
        }

        [TestMethod]
        public void QueryBuilder_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<IQueryBuilder>();
            var objFromClass = provider?.GetService<QueryBuilder>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<QueryBuilder>();
            objFromInterface?.GetType().Name.Should().Be("QueryBuilder");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<QueryBuilder>();
            objFromClass?.GetType().Name.Should().Be("QueryBuilder");
        }

        [TestMethod]
        public void DeserializerFactory_Resolve()
        {
            // Arrange/Act
            var objFromInterface = provider?.GetService<IDeserializerFactory>();
            var objFromClass = provider?.GetService<DeserializerFactory>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<DeserializerFactory>();
            objFromInterface?.GetType().Name.Should().Be("DeserializerFactory");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<DeserializerFactory>();
            objFromClass?.GetType().Name.Should().Be("DeserializerFactory");
        }
    }
}