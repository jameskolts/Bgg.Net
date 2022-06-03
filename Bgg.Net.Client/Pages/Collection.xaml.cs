using Bgg.Net.Common.Models;
using Bgg.Net.Common.RequestHandlers.Collection;
using Bgg.Net.Common.Infrastructure.IOC;
using Autofac;
using Bgg.Net.Client.ViewModels;
using Bgg.Net.Client.IOC;

namespace Bgg.Net.Client.Pages;

public partial class Collection : ContentPage
{
	public ICollectionViewModel collectionViewModel;
	public Common.Models.Collection _collection;

	public Collection()
	{
		InitializeComponent();
		Init();
		InitAsync();
	}

	public void Init()
    {
        collectionViewModel = BootStrapper.Resolve<ICollectionViewModel>();
		BindingContext = collectionViewModel;
    }

	public async void InitAsync()
    {
		await collectionViewModel.GetCollection("JusticiarIV");
    }
}