using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Bgg.Net.Web.Infrastructure.IOC
{
    public static class ClassFactory
    {
        public static WebAssemblyHostBuilder RegisterWebComponents(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            return builder;
        }
    }
}
