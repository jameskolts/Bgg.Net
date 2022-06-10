namespace Bgg.Net.Client.Views;

public partial class FilterEntryView : ContentView
{
	public FilterEntryView()
	{
		InitializeComponent();
        FilterLayout.BindingContext = this;
	}

    public static readonly BindableProperty PlaceholderProperty =
       BindableProperty.Create(nameof(PlaceholderProperty), typeof(string), typeof(FilterEntryView), string.Empty);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty HorizontalLayoutProperty =
      BindableProperty.Create(nameof(HorizontalLayout), typeof(LayoutOptions), typeof(FilterEntryView), LayoutOptions.Center);

    public LayoutOptions HorizontalLayout
    {
        get => (LayoutOptions)GetValue(HorizontalLayoutProperty);
        set => SetValue(HorizontalLayoutProperty, value);
    }

    public static readonly BindableProperty BorderColorProperty =
       BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(FilterEntryView), Colors.White);

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public static readonly BindableProperty ImageProperty =
       BindableProperty.Create(nameof(ImageProperty), typeof(ImageSource), typeof(FilterEntryView), default(ImageSource));

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public string Text
    {
        get => FilterEntry.Text;
        set => FilterEntry.Text = value;
    }

    public event EventHandler<TextChangedEventArgs> TextChanged;

    private void FilterEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextChanged?.Invoke(this, e);
    }
}