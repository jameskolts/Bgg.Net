// See https://aka.ms/new-console-template for more information
using Autofac;
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Common.Resources.Things;
using Serilog;


Console.WriteLine("Hello, Bgg.Net!");

AutofacRegistrar.BuildContainer();

using (var scope = AutofacRegistrar.Container.BeginLifetimeScope())
{
    var client = scope.Resolve<IHttpClient>();
    var handler = scope.Resolve<IThingHandler>();

    var result = await handler.GetThingById(25);

    Log.Logger.Information("Success: " + result.IsSuccessful.ToString());

    var extension = new Extension
    {
        Value = new Dictionary<string, List<int>>
        {
            { "id", new List<int> { 1 } },
            { "versions", new List<int> { 1 } },
            { "badParameter", new List<int> { 1 }}
        }
    };

    result = await handler.GetThingsExtensible(extension);
    Log.Logger.Information("Success: " + result.IsSuccessful.ToString());
}

Console.WriteLine("Press any key to exit");
Console.ReadKey();
