namespace Bgg.Net.Client.Views;

public partial class SearchAndFilterView : ContentView
{
	public SearchAndFilterView()
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
       BindableProperty.Create(nameof(SearchFrameColor), typeof(Color), typeof(CollectionCardView), Colors.DarkGray);

    public Color SearchFrameColor
    {
        get => (Color)GetValue(SearchFrameColorProperty);
        set => SetValue(SearchFrameColorProperty, value);
    }

    public static readonly BindableProperty BorderColorProperty =
       BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CollectionCardView), Colors.White);

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }
}