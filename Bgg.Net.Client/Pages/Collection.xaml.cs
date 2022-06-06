using Bgg.Net.Client.IOC;
using Bgg.Net.Client.ViewModels;

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

    protected void FilterBtn_Clicked(object sender, EventArgs e)
    {
        if (filterFrame.IsVisible)
        {
            filterFrame.IsVisible = false;
        }
        else
        {
            filterFrame.IsVisible = true;
        }
    }

    protected void SearchBtn_Clicked(object sender, EventArgs e)
    {
        if (searchFrame.IsVisible)
        {
            searchFrame.IsVisible = false;
        }
        else
        {
            searchFrame.IsVisible = true;
        }
    }
}