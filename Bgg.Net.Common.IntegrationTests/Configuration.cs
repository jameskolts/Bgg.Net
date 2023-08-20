using Microsoft.Extensions.Configuration;

namespace Bgg.Net.Common.IntegrationTests
{
    public static class Configuration
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")                
                 .AddEnvironmentVariables()
                 .Build();

            return config;
        }
    }
}
