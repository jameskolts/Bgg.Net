using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Web.Components;
using Bgg.Net.Web.Infrastructure.IOC;
using Dgi.Client;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.RegisterWebComponents();
builder.Services
    .RegisterBggCommon()
    .RegisterDgiClients()
    .ConfigureLogging()
    .AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Bgg.Net.Web.Client._Imports).Assembly);

app.Run();
