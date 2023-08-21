using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Common.RequestHandlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers
{
    public class HandlerTestBase
    {
        protected IServiceProvider _serviceProvider;

        public HandlerTestBase() 
        {
            var services = new ServiceCollection();
            services.RegisterBggCommon();
            services.AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));
            services.AddLogging(x => x.SetMinimumLevel(LogLevel.Debug));

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
