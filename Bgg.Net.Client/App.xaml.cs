﻿using Bgg.Net.Client.Pages;

namespace Bgg.Net.Client;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
