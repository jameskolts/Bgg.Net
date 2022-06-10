using Bgg.Net.Client.IOC;
using Bgg.Net.Client.Models;
using Bgg.Net.Client.ViewModels;

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

    private void Init()
    {
        collectionViewModel = BootStrapper.Resolve<ICollectionViewModel>();
        BindingContext = collectionViewModel;
    }

    private async void InitAsync()
    {
        await collectionViewModel.GetCollection("JusticiarIV");
    }

    protected void SearchBtn_Clicked(object sender, EventArgs e)
    {
        if (SearchView.Visible)
        {
            SearchView.Visible = false;
        }
        else
        {
            SearchView.Visible = true;
        }
    }

    private void SearchView_TextChanged(object sender, TextChangedEventArgs e)
    {
        collectionViewModel.FilterCollection(SearchView.SearchText, SearchView.AgeText, SearchView.PlayerCountText, SearchView.PlayTimeText);
    }

    private void CollectionItem_Tapped(object sender, EventArgs e)
    {
        collectionViewModel.ItemTapped((e as TappedEventArgs).Parameter as CollectionPageItem);
    }
}