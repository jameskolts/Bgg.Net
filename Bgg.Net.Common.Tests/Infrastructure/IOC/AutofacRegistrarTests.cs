using Autofac;
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Resources.Families;
using Bgg.Net.Common.Resources.Things;
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
    }
}
