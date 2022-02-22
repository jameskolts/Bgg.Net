using Autofac;
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using Bgg.Net.Common.RequestHandlers.Families;
using Bgg.Net.Common.RequestHandlers.Things;
using Bgg.Net.Common.RequestHandlers.ForumsList;
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
        public void ThingDeserializer_Resolve()
        {
            // Arrange/Act
            var objFromInterface = scope?.Resolve<IThingDeserializer>();
            var objFromClass = scope?.Resolve<ThingDeserializer>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<ThingDeserializer>();
            objFromInterface?.GetType().Name.Should().Be("ThingDeserializer");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<ThingDeserializer>();
            objFromClass?.GetType().Name.Should().Be("ThingDeserializer");
        }

        [TestMethod]
        public void FamilyDeserializer_Resolve()
        {
            // Arrange/Act
            var objFromInterface = scope?.Resolve<IFamilyDeserializer>();
            var objFromClass = scope?.Resolve<FamilyDeserializer>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<FamilyDeserializer>();
            objFromInterface?.GetType().Name.Should().Be("FamilyDeserializer");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<FamilyDeserializer>();
            objFromClass?.GetType().Name.Should().Be("FamilyDeserializer");
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
        public void ThreadDeserializer_Resolve()
        {
            // Arrange/Act
            var objFromInterface = scope?.Resolve<IThreadDeserializer>();
            var objFromClass = scope?.Resolve<ThreadDeserializer>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<ThreadDeserializer>();
            objFromInterface?.GetType().Name.Should().Be("ThreadDeserializer");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<ThreadDeserializer>();
            objFromClass?.GetType().Name.Should().Be("ThreadDeserializer");
        }

        [TestMethod]
        public void ForumDeserializer_Resolve()
        {
            // Arrange/Act
            var objFromInterface = scope?.Resolve<IForumDeserializer>();
            var objFromClass = scope?.Resolve<ForumDeserializer>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<ForumDeserializer>();
            objFromInterface?.GetType().Name.Should().Be("ForumDeserializer");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<ForumDeserializer>();
            objFromClass?.GetType().Name.Should().Be("ForumDeserializer");
        }

        [TestMethod]
        public void ForumListDeserializer_Resolve()
        {
            // Arrange/Act
            var objFromInterface = scope?.Resolve<IForumListDeserializer>();
            var objFromClass = scope?.Resolve<ForumListDeserializer>();

            //Assert
            objFromInterface.Should().NotBeNull();
            objFromInterface.Should().BeAssignableTo<ForumListDeserializer>();
            objFromInterface?.GetType().Name.Should().Be("ForumListDeserializer");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<ForumListDeserializer>();
            objFromClass?.GetType().Name.Should().Be("ForumListDeserializer");
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
            objFromInterface?.GetType().Name.Should().Be("ForumListDHandler");

            objFromClass.Should().NotBeNull();
            objFromClass.Should().BeAssignableTo<ForumListDeserializer>();
            objFromClass?.GetType().Name.Should().Be("ForumListHandler");
        }
    }
}
