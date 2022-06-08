namespace Bgg.Net.Client.Views;

public partial class SearchView : ContentView
{
    public SearchView()
    {
        InitializeComponent();
        SearchFrame.BindingContext = this;
    }

    public static readonly BindableProperty VisibleProperty =
        BindableProperty.Create(nameof(Visible), typeof(bool), typeof(SearchView), true);

    public bool Visible
    {
        get => (bool)GetValue(VisibleProperty);
        set => SetValue(VisibleProperty, value);
    }

    public static readonly BindableProperty SearchFrameColorProperty =
       BindableProperty.Create(nameof(SearchFrameColor), typeof(Color), typeof(SearchView), Colors.White);

    public Color SearchFrameColor
    {
        get => (Color)GetValue(SearchFrameColorProperty);
        set => SetValue(SearchFrameColorProperty, value);
    }

    public static readonly BindableProperty BorderColorProperty =
       BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(SearchView), Colors.White);

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty =
       BindableProperty.Create(nameof(PlaceholderProperty), typeof(string), typeof(SearchView), string.Empty);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty TextColorProperty =
      BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(SearchView), Colors.Black);

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public string Text
    {
        get => SearchBar.Text;
        set => SearchBar.Text = value;
    }

    public event EventHandler<TextChangedEventArgs> TextChanged;

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextChanged?.Invoke(this, e);
    }
}