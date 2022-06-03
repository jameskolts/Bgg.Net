namespace Bgg.Net.Client.Views;

public partial class CardView : ContentView
{
    public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(CardView), string.Empty);

    public string CardTitle
    {
        get => (string)GetValue(CardView.CardTitleProperty);
        set => SetValue(CardView.CardTitleProperty, value);
    }

    public CardView()
    {
        InitializeComponent();
    }
}