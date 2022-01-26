// See https://aka.ms/new-console-template for more information
using Bgg.Net.Common.Resources.Things;

Console.WriteLine("Hello, Bgg.Net!");

var handler = new ThingHandler(new Bgg.Net.Common.Http.BggClient());

var result = await handler.GetThingById(1);

Console.WriteLine(result.ToString());
Console.WriteLine("Press any key to exit");
Console.ReadKey();
