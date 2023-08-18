using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Web.Infrastructure.IOC;
using Dgi.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Bgg.Net.Web;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.RegisterWebComponents();
        builder.Services.RegisterBggCommon();
        builder.Services.RegisterDgiClients();
        builder.Services.ConfigureLogging();

        await builder.Build().RunAsync();
    }
}
