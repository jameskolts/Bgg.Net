using Bgg.Net.Web;
using Bgg.Net.Web.Infrastructure.IOC;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.RegisterWebComponents();

await builder.Build().RunAsync();
