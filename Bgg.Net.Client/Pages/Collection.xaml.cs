using Bgg.Net.Client.IOC;
using Bgg.Net.Client.ViewModels;
using Bgg.Net.Client.Views;
using Microsoft.Maui.Graphics;
using System.Numerics;
using Microsoft.Maui.Devices;

namespace Bgg.Net.Client.Pages;

public partial class Collection : ContentPage
{
    public ICollectionViewModel collectionViewModel;

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
        if (FilterFrame.IsVisible)
        {
            FilterFrame.IsVisible = false;
        }
        else
        {
            FilterFrame.IsVisible = true;
        }
    }

    protected void SearchBtn_Clicked(object sender, EventArgs e)
    {
        if (SearchFrame.IsVisible)
        {
            SearchFrame.IsVisible = false;
        }
        else
        {
            SearchFrame.IsVisible = true;
        }
    }
}