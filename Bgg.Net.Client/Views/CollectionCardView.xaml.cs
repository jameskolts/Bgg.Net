using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Bgg.Net.Client.Views;

public partial class CollectionCardView : ContentView
{
    public static readonly BindableProperty CardTitleProperty =
            BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(CollectionCardView), string.Empty);

    public static readonly BindableProperty CardDescriptionProperty =
        BindableProperty.Create(nameof(CardDescription), typeof(string), typeof(CollectionCardView), string.Empty);

    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CollectionCardView), Colors.DarkGray);

    public static readonly BindableProperty CardColorProperty =
        BindableProperty.Create(nameof(CardColor), typeof(Color), typeof(CollectionCardView), Colors.White);

    public static readonly BindableProperty IconImageSourceProperty =
        BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(CollectionCardView), default(ImageSource));

    public static readonly BindableProperty IconBackgroundColorProperty =
        BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(CollectionCardView), Colors.LightGray);

    public static readonly BindableProperty TitleColorProperty =
        BindableProperty.Create(nameof(CardTitle), typeof(Color), typeof(CollectionCardView), Colors.Black);

    public static readonly BindableProperty DescriptionColorProperty =
        BindableProperty.Create(nameof(CardDescriptionColor), typeof(Color), typeof(CollectionCardView), Colors.Black);

    public static readonly BindableProperty PlayCountProperty =
        BindableProperty.Create(nameof(CardDescriptionColor), typeof(int), typeof(CollectionCardView), 0);

    public CollectionCardView()
    {
        InitializeComponent();

         Card.BindingContext = this;
    }

    public string CardTitle
    {
        get => (string)GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }

    public Color CardTitleColor
    {
        get => (Color)GetValue(TitleColorProperty);
        set => SetValue(TitleColorProperty, value);
    }

    public string CardDescription
    {
        get => (string)GetValue(CardDescriptionProperty);
        set => SetValue(CardDescriptionProperty, value);
    }

    public Color CardDescriptionColor
    {
        get => (Color)GetValue(DescriptionColorProperty);
        set => SetValue(DescriptionColorProperty, value);
    }

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public Color CardColor
    {
        get => (Color)GetValue(CardColorProperty);
        set => SetValue(CardColorProperty, value);
    }

    public ImageSource IconImageSource
    {
        get => (ImageSource)GetValue(IconImageSourceProperty);
        set => SetValue(IconImageSourceProperty, value);
    }

    public Color IconBackgroundColor
    {
        get => (Color)GetValue(IconBackgroundColorProperty);
        set => SetValue(IconBackgroundColorProperty, value);
    }

    public int PlayCount
    {
        get => (int)GetValue(PlayCountProperty);
        set => SetValue(PlayCountProperty, value);
    }
}