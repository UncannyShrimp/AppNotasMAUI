namespace AppNotasMaui.Controls;

public partial class StarCheckBox : ContentView
{
    public static readonly BindableProperty IsCheckedProperty =
        BindableProperty.Create(
            nameof(IsChecked),
            typeof(bool),
            typeof(StarCheckBox),
            false,
            BindingMode.TwoWay,
            propertyChanged: OnCheckedChanged);

    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    public StarCheckBox()
    {
        InitializeComponent();
        UpdateIcon();
    }

    private void OnClicked(object sender, EventArgs e)
    {
        IsChecked = !IsChecked;
    }

    static void OnCheckedChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (StarCheckBox)bindable;
        control.UpdateIcon();
    }

    void UpdateIcon()
    {
        StarButton.Source = IsChecked
            ? "star_svg_full.png"
            : "star_svg_empty.png";
    }
}