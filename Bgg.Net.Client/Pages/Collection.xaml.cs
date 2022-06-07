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
        SetCollectionViewSpan();
    }

    public async void InitAsync()
    {
        await collectionViewModel.GetCollection("JusticiarIV");
    }

    private void SetCollectionViewSpan()
    {
        var density = DeviceDisplay.Current.MainDisplayInfo.Density;
        var deviceWidth = DeviceDisplay.Current.MainDisplayInfo.Width;
        var columMath = (int)(deviceWidth / density / 350);
        int columns;

        if (columMath > 1)
        {
            columns = columMath - 2;
        }
        else
        {
            columns = 1;
        }

        CollectionView.ItemsLayout = new GridItemsLayout(columns, ItemsLayoutOrientation.Vertical)
        {
            HorizontalItemSpacing = 10,
            VerticalItemSpacing = 10
        };

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