using Bgg.Net.Client.Infrastructure.IOC;

namespace Bgg.Net.Client;

public partial class App : Application
{	
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override void OnStart()
    {
        base.OnStart();
		BootStrapper.Start(); //TODO find a place to stop this.
    }
}
