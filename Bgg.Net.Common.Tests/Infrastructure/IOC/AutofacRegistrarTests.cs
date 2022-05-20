using Autofac;
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Common.RequestHandlers.Families;
using Bgg.Net.Common.RequestHandlers.Forums;
using Bgg.Net.Common.RequestHandlers.ForumsList;
using Bgg.Net.Common.RequestHandlers.Things;
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
    }
}
