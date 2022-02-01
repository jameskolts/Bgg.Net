using Autofac;
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Resources.Things;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bgg.Net.Common.Tests.Infrastructure.IOC
{
    [TestClass]
    public class AutofacRegistrarTests
    {
        private ILifetimeScope? scope;
        
        public AutofacRegistrarTests()
        {
            AutofacRegistrar.BuildContainer();
        }

        [TestInitialize]
        public void init()
        {
            scope = AutofacRegistrar.Container.BeginLifetimeScope();
        }

        [TestCleanup]
        public void Cleanup()
        {
            scope?.Dispose();
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
    }
}
