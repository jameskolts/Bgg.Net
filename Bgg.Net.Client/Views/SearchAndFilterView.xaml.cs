namespace Bgg.Net.Client.Views;

public partial class SearchAndFilterView : ContentView
{
    public SearchAndFilterView()
    {
        InitializeComponent();
        SearchFrame.BindingContext = this;
    }

    public static readonly BindableProperty VisibleProperty =
        BindableProperty.Create(nameof(Visible), typeof(bool), typeof(SearchAndFilterView), true);

    public bool Visible
    {
        get => (bool)GetValue(VisibleProperty);
        set => SetValue(VisibleProperty, value);
    }

    public static readonly BindableProperty SearchFrameColorProperty =
       BindableProperty.Create(nameof(SearchFrameColor), typeof(Color), typeof(SearchAndFilterView), Colors.White);

    public Color SearchFrameColor
    {
        get => (Color)GetValue(SearchFrameColorProperty);
        set => SetValue(SearchFrameColorProperty, value);
    }

    public static readonly BindableProperty BorderColorProperty =
       BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(SearchAndFilterView), Colors.White);

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty =
       BindableProperty.Create(nameof(PlaceholderProperty), typeof(string), typeof(SearchAndFilterView), string.Empty);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty TextColorProperty =
      BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(SearchAndFilterView), Colors.Black);

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public string SearchText
    {
        get => SearchBar.Text;
        set => SearchBar.Text = value;
    }

    public string PlayTimeText
    {
        get => PlayTimeEntry.Text;
        set => PlayTimeEntry.Text = value;
    }

    public string AgeText
    {
        get => AgeEntry.Text;
        set => AgeEntry.Text = value;
    }

    public string PlayerCountText
    {
        get => PlayerCountEntry.Text;
        set => PlayerCountEntry.Text = value;
    }

    public event EventHandler<TextChangedEventArgs> TextChanged;

    private void SearchAndEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextChanged?.Invoke(this, e);
    }
}