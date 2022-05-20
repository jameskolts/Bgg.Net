// See https://aka.ms/new-console-template for more information
using Autofac;
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Common.RequestHandlers.Families;
using Bgg.Net.Common.RequestHandlers.ForumsList;
using Bgg.Net.Common.RequestHandlers.Things;
using Bgg.Net.Common.RequestHandlers.Forums;
using Serilog;


Console.WriteLine("Hello, Bgg.Net!");

using (var scope = AutofacRegistrar.BuildContainer().BeginLifetimeScope())
{
    var logger = scope.Resolve<ILogger>();

    var client = scope.Resolve<IHttpClient>();
    var handler = scope.Resolve<IThingHandler>();

    logger.Information("---Things---");
    var resultThing = await handler.GetThingById(25);
    logger.Information("Success: " + resultThing.IsSuccessful);

    var extension = new Extension
    {
        Value = new Dictionary<string, List<int>>
        {
            { "id", new List<int> { 1 } },
            { "versions", new List<int> { 1 } },
            { "badParameter", new List<int> { 1 }}
        }
    };

    var resultThingList = await handler.GetThingsExtensible(extension);
    logger.Information("Success: " + resultThingList.IsSuccessful);

    extension = new Extension
    {
        Value = new Dictionary<string, List<int>>
        {
            { "id", new List<int> { 1 } },
            { "versions", new List<int> { 1 } },
            { "videos", new List<int> { 1 } },
            { "comments", new List<int> { 1 } },
            { "marketplace", new List<int> { 1 } },
            { "stats", new List<int> { 1 } }
        }
    };

    resultThingList = await handler.GetThingsExtensible(extension);
    logger.Information("Success: " + resultThingList.IsSuccessful);

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

    logger.Information("---ForumList---");
    var forumListHandler = scope.Resolve<ForumListHandler>();
    var forumList = await forumListHandler.GetForumListByIdAndType(1, Bgg.Net.Common.Types.ForumListType.Thing);
    logger.Information("Success: " + forumList.IsSuccessful);

    logger.Information("---Forum---");
    var forumHandler = scope.Resolve<ForumHandler>();
    var forum = await forumHandler.GetForumById(3);
    logger.Information("Success: " + forum.IsSuccessful);

}

Console.WriteLine("Press any key to exit");
Console.ReadKey();


