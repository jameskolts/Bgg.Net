// See https://aka.ms/new-console-template for more information
using Autofac;
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Common.Resources.Families;
using Bgg.Net.Common.Resources.Things;
using Serilog;


Console.WriteLine("Hello, Bgg.Net!");

using (var scope = AutofacRegistrar.BuildContainer().BeginLifetimeScope())
{
    var logger = scope.Resolve<ILogger>();

    var client = scope.Resolve<IHttpClient>();
    var handler = scope.Resolve<IThingHandler>();

    logger.Information("---Things---");
    var result = await handler.GetThingById(25);
    logger.Information("Success: " + result.IsSuccessful);

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
    logger.Information("Success: " + result.IsSuccessful);

    logger.Information("---Families---");
    var familyHandler = scope.Resolve<IFamilyHandler>();
    var family = await familyHandler.GetFamilyById(1);
    logger.Information("Success: " + family.IsSuccessful);
    family = await familyHandler.GetFamilyByIds(new List<int> { 1, 2, 3 });
    logger.Information("Success: " + family.IsSuccessful);
    family = await familyHandler.GetFamilyByIdsAndType(new List<int> { 1, 2, 3 }, new List<Bgg.Net.Common.Types.FamilyType> { Bgg.Net.Common.Types.FamilyType.BoardGameFamily});
    logger.Information("Success: " + family.IsSuccessful);
    family = await familyHandler.GetFamilyByIdsAndType(new List<int> { 1, 2, 3 }, new List<Bgg.Net.Common.Types.FamilyType> { Bgg.Net.Common.Types.FamilyType.BoardGameFamily });
    logger.Information("Success: " + family.IsSuccessful);
    family = await familyHandler.GetFamilyExtensible(new Extension { Value = new Dictionary<string, List<int>> { { "id", new List<int> { 1 } } } });
    logger.Information("Success: " + family.IsSuccessful);

}

Console.WriteLine("Press any key to exit");
Console.ReadKey();
