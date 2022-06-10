using Bgg.Net.Client.Models;

namespace Bgg.Net.Client.Views;

public partial class CollectionCardView : ContentView
{
    public CollectionCardView()
    {
        InitializeComponent();

        Card.BindingContext = this;
    }

    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CollectionCardView), Colors.DarkGray);

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public static readonly BindableProperty CardColorProperty =
        BindableProperty.Create(nameof(CardColor), typeof(Color), typeof(CollectionCardView), Colors.White);

    public Color CardColor
    {
        get => (Color)GetValue(CardColorProperty);
        set => SetValue(CardColorProperty, value);
    }

    public static readonly BindableProperty IconImageSourceProperty =
        BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(CollectionCardView), default(ImageSource));

    public ImageSource IconImageSource
    {
        get => (ImageSource)GetValue(IconImageSourceProperty);
        set => SetValue(IconImageSourceProperty, value);
    }

    public static readonly BindableProperty IconBackgroundColorProperty =
        BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(CollectionCardView), Colors.LightGray);

    public Color IconBackgroundColor
    {
        get => (Color)GetValue(IconBackgroundColorProperty);
        set => SetValue(IconBackgroundColorProperty, value);
    }
    
    public static readonly BindableProperty ItemProperty =
        BindableProperty.Create(nameof(Item), typeof(CollectionPageItem), typeof(CollectionCardView), default(CollectionPageItem));

    public CollectionPageItem Item
    {
        get => (CollectionPageItem)GetValue(ItemProperty);
        set => SetValue(ItemProperty, value);
    }

    public event EventHandler CardTapped;

    private void Card_Tapped(object sender, EventArgs e)
    {
        CardTapped?.Invoke(sender, e);
    }
}