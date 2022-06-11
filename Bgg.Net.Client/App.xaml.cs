using Bgg.Net.Client.Infrastructure.IOC;

namespace Bgg.Net.Client;

public partial class App : Application
{
	public static int ScreenWidth, ScreenHeight;
	public static string DeviceOs;
	public static DevicePlatform Platform;

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override void OnStart()
    {
        base.OnStart();
		GetDeviceInfo();
		BootStrapper.Start(); //TODO find a place to stop this.
    }

	private void GetDeviceInfo()
    {
		var width = DeviceDisplay.MainDisplayInfo.Width;
		var height = DeviceDisplay.MainDisplayInfo.Height;
		var density = DeviceDisplay.MainDisplayInfo.Density;

		ScreenWidth = (int)(width / density);
		ScreenHeight = (int)(height / density);
		DeviceOs = DeviceInfo.VersionString;
		Platform = DeviceInfo.Current.Platform;
    }
}
