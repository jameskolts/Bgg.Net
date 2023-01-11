using Autofac;
using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Web;
using Bgg.Net.Web.Infrastructure.IOC;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.RegisterWebComponents();

        //TODO: Generate new common package with Microsoft IOC and register here.
        await builder.Build().RunAsync();
    }
}
