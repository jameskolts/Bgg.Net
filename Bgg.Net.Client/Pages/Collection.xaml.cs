using Bgg.Net.Client.Infrastructure.IOC;
using Bgg.Net.Client.Models;
using Bgg.Net.Client.ViewModels;
using Serilog;

namespace Bgg.Net.Client.Pages;

public partial class Collection : ContentPage
{
    public ICollectionViewModel collectionViewModel;
    private ILogger _logger;

    public Collection()
    {
        InitializeComponent();
        Init();
        InitAsync();
    }

    private void Init()
    {
        _logger = BootStrapper.Resolve<ILogger>();
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

    private async void CollectionItem_Tapped(object sender, EventArgs e)
    {
        try
        {
            var collectionItem = (e as TappedEventArgs).Parameter as CollectionPageItem;
            var itemPage = new CollectionItemDetails(collectionItem);
            await Navigation.PushAsync(itemPage);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message, ex.InnerException);
        }
    }
}