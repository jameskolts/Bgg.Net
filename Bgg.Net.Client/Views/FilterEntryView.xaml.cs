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

    public static readonly BindableProperty NameProperty =
       BindableProperty.Create(nameof(NameProperty), typeof(string), typeof(FilterEntryView), string.Empty);

    public string Name
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(NameProperty, value);
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

    public ImageSource Image
    {
        get => (ImageSource)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public string Text
    {
        get => FilterEntry.Text;
        set => FilterEntry.Text = value;
    }
}