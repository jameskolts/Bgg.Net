using Autofac;
using Bgg.Net.Client.Infrastructure.Extensions;
using Bgg.Net.Client.Infrastructure.IOC;
using Bgg.Net.Client.Models;
using Bgg.Net.Client.ViewModels;

namespace Bgg.Net.Client.Pages;

public partial class CollectionItemDetails : ContentPage
{
	public ICollectionItemDetailsViewModel itemViewModel;

	public CollectionItemDetails(CollectionPageItem item)
	{
		InitializeComponent();
		Init(item);
	}

	private void Init(CollectionPageItem item)
    {
        itemViewModel = BootStrapper.Resolve<ICollectionItemDetailsViewModel>(new[] { new NamedParameter("item", item) });
		BindingContext = itemViewModel;
		PublishersLabel.Text = itemViewModel.Item.Publishers.CreateListLabelText();
		DesignersLabel.Text = itemViewModel.Item.Designers.CreateListLabelText();
    }
}