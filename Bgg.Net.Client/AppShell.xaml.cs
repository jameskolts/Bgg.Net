using Bgg.Net.Client.Pages;

namespace Bgg.Net.Client;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
    }

    private static void RegisterRoutes()
    {
        Routing.RegisterRoute("dashboard", typeof(Dashboard));
        Routing.RegisterRoute("logs", typeof(Logs));
        Routing.RegisterRoute("collection", typeof(Collection));
        Routing.RegisterRoute("collectionitemdetails", typeof(CollectionItemDetails));
    }
}
