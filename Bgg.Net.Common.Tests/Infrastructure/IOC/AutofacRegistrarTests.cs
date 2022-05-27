using Autofac;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Common.RequestHandlers.Collection;
using Bgg.Net.Common.RequestHandlers.Families;
using Bgg.Net.Common.RequestHandlers.Forums;
using Bgg.Net.Common.RequestHandlers.Guilds;
using Bgg.Net.Common.RequestHandlers.Things;
using Bgg.Net.Common.RequestHandlers.Users;
using Bgg.Net.Common.RequestHandlers.HotItems;
using Bgg.Net.Common.RequestHandlers.Search;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bgg.Net.Common.Tests.Infrastructure.IOC
{
    [TestClass]
    public class AutofacRegistrarTests
    {
        private IContainer? container;
        private ILifetimeScope? scope;
               
        [TestInitialize]
        public void Init()
        {
            container = AutofacRegistrar.BuildContainer();
            scope = container.BeginLifetimeScope();
        }

        [TestCleanup]
        public void Cleanup()
        {
            scope?.Dispose();
            container?.Dispose();
        }

        [TestMethod]
        public void BggClient_Resolve()
        {
            // Arrange/Act
            var objFromInterface = scope?.Resolve<IHttpClient>();
            var objFromClass = scope?.Resolve<BggClient>();

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
            var objFromInterface = scope?.Resolve<IThingHandler>();
            var objFromClass = scope?.Resolve<ThingHandler>();

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
            var objFromInterface = scope?.Resolve<IFamilyHandler>();
            var objFromClass = scope?.Resolve<FamilyHandler>();

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
            var objFromInterface = scope?.Resolve<IForumListHandler>();
            var objFromClass = scope?.Resolve<ForumListHandler>();

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
            var objFromInterface = scope?.Resolve<IForumHandler>();
            var objFromClass = scope?.Resolve<ForumHandler>();

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
            var objFromInterface = scope?.Resolve<IGuildHandler>();
            var objFromClass = scope?.Resolve<GuildHandler>();

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
            var objFromInterface = scope?.Resolve<IUserHandler>();
            var objFromClass = scope?.Resolve<UserHandler>();

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
            var objFromInterface = scope?.Resolve<ICollectionClient>();
            var objFromClass = scope?.Resolve<CollectionClient>();

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
            var objFromInterface = scope?.Resolve<ICollectionHandler>();
            var objFromClass = scope?.Resolve<CollectionHandler>();

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
            var objFromInterface = scope?.Resolve<IHotItemsHandler>();
            var objFromClass = scope?.Resolve<HotItemHandler>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<HotItemHandler>();
            objFromInterface?.GetType().Name.Should().Be("HotItemHandler");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<HotItemHandler>();
            objFromClass?.GetType().Name.Should().Be("HotItemHandler");
        }

        [TestMethod]
        public void SearchnHandler_Resolve()
        {
            // Arrange/Act
            var objFromInterface = scope?.Resolve<ISearchHandler>();
            var objFromClass = scope?.Resolve<SearchHandler>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<SearchHandler>();
            objFromInterface?.GetType().Name.Should().Be("SearchHandler");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<SearchHandler>();
            objFromClass?.GetType().Name.Should().Be("SearchHandler");
        }
    }
}
