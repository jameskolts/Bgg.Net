// See https://aka.ms/new-console-template for more information
using Autofac;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.IOC;
using Bgg.Net.Common.RequestHandlers.Collection;
using Bgg.Net.Common.RequestHandlers.Families;
using Bgg.Net.Common.RequestHandlers.Forums;
using Bgg.Net.Common.RequestHandlers.Guilds;
using Bgg.Net.Common.RequestHandlers.HotItems;
using Bgg.Net.Common.RequestHandlers.Things;
using Bgg.Net.Common.RequestHandlers.Threads;
using Bgg.Net.Common.Types;
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

    logger.Information("---Families---");
    var familyHandler = scope.Resolve<IFamilyHandler>();
    var family = await familyHandler.GetFamilyById(1);
    logger.Information("Success: " + family.IsSuccessful);
    family = await familyHandler.GetFamilyByIds(new List<long> { 1, 2, 3 });
    logger.Information("Success: " + family.IsSuccessful);
    family = await familyHandler.GetFamilyByIdsAndType(new List<long> { 1, 2, 3 }, new List<Bgg.Net.Common.Types.FamilyType> { Bgg.Net.Common.Types.FamilyType.BoardGameFamily });
    logger.Information("Success: " + family.IsSuccessful);
    family = await familyHandler.GetFamilyByIdsAndType(new List<long> { 1, 2, 3 }, new List<Bgg.Net.Common.Types.FamilyType> { Bgg.Net.Common.Types.FamilyType.BoardGameFamily });
    logger.Information("Success: " + family.IsSuccessful);


    logger.Information("---ForumList---");
    var forumListHandler = scope.Resolve<ForumListHandler>();
    var forumList = await forumListHandler.GetForumListByIdAndType(1, Bgg.Net.Common.Types.ItemType.Thing);
    logger.Information("Success: " + forumList.IsSuccessful);

    logger.Information("---Forum---");
    var forumHandler = scope.Resolve<ForumHandler>();
    var forum = await forumHandler.GetForumById(3);
    logger.Information("Success: " + forum.IsSuccessful);


    logger.Information("---Thread---");
    var threadHandler = scope.Resolve<ThreadHandler>();
    var thread = await threadHandler.GetThreadById(25);
    logger.Information("Success: " + thread.IsSuccessful);

    logger.Information("---Collection---");
    var collectionHandler = scope.Resolve<ICollectionHandler>();
    var collection = await collectionHandler.GetCollectionByUserName("Jimmydm90");
    logger.Information("Success: " + collection.IsSuccessful);

    logger.Information("---Guild---");
    var guildHandler = scope.Resolve<IGuildHandler>();
    var guild = await guildHandler.GetGuildById(24);
    logger.Information("Success: " + guild.IsSuccessful);

    logger.Information("---HotItem---");
    var hotHandler = scope.Resolve<IHotItemsHandler>();
    var hotItem = await hotHandler.GetHotItemsByType(HotItemType.BoardGame);
    logger.Information("Success: " + hotItem.IsSuccessful);
}

Console.WriteLine("Press any key to exit");
Console.ReadKey();


