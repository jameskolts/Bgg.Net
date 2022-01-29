// See https://aka.ms/new-console-template for more information
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Resources.Things;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Console.WriteLine("Hello, Bgg.Net!");

using (var client = new BggClient())
{
    var handler = new ThingHandler(client, Log.Logger, new ThingDeserializer("//items/item", Log.Logger));
    var result = await handler.GetThingById(25);

    Log.Logger.Information(result.ToString());

    var extension = new Extension
    {
        Value = new Dictionary<string, int>
        {
            { "id", 1 },
            { "versions", 1 },
            { "padParameter", 1}
        }
    };

    result = await handler.GetThingsExtensible(extension);
    Log.Logger.Information(result.ToString());
}
Console.WriteLine("Press any key to exit");
Console.ReadKey();
