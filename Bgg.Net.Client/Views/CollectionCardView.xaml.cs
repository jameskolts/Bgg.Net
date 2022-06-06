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

    public static readonly BindableProperty DescriptionColorProperty =
        BindableProperty.Create(nameof(CardDescriptionColor), typeof(Color), typeof(CollectionCardView), Colors.Black);

    public static readonly BindableProperty PlayCountProperty =
        BindableProperty.Create(nameof(CardDescriptionColor), typeof(int), typeof(CollectionCardView), 0);

    public static readonly BindableProperty DesignerProperty =
        BindableProperty.Create(nameof(Designer), typeof(string), typeof(CollectionCardView), string.Empty);

    public static readonly BindableProperty PublisherProperty =
        BindableProperty.Create(nameof(Publisher), typeof(string), typeof(CollectionCardView), string.Empty);

    public static readonly BindableProperty YearPublishedProperty =
        BindableProperty.Create(nameof(YearPublished), typeof(int), typeof(CollectionCardView), 0);

    public static readonly BindableProperty MaxPlayersProperty =
        BindableProperty.Create(nameof(MaxPlayers), typeof(int), typeof(CollectionCardView), 0);

    public static readonly BindableProperty MinPlayersProperty =
        BindableProperty.Create(nameof(MinPlayers), typeof(int), typeof(CollectionCardView), 0);

    public static readonly BindableProperty PlayTimeProperty =
        BindableProperty.Create(nameof(PlayTime), typeof(int), typeof(CollectionCardView), 0);

    public static readonly BindableProperty MinAgeProperty =
        BindableProperty.Create(nameof(MinAge), typeof(int), typeof(CollectionCardView), 0);

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

    public string Designer
    {
        get => (string)GetValue(DesignerProperty);
        set => SetValue(DesignerProperty, value);
    }

    public string Publisher
    {
        get => (string)GetValue(PublisherProperty);
        set => SetValue(PublisherProperty, value);
    }

    public int YearPublished
    {
        get => (int)GetValue(YearPublishedProperty);
        set => SetValue(YearPublishedProperty, value);
    }

    public int MinPlayers
    {
        get => (int)GetValue(MinPlayersProperty);
        set => SetValue(MinPlayersProperty, value);
    }

    public int MaxPlayers
    {
        get => (int)GetValue(MaxPlayersProperty);
        set => SetValue(MaxPlayersProperty, value);
    }

    public int PlayTime
    {
        get => (int)GetValue(PlayTimeProperty);
        set => SetValue(PlayTimeProperty, value);
    }

    public int MinAge
    {
        get => (int)GetValue(MinAgeProperty);
        set => SetValue(MinAgeProperty, value);
    }
}