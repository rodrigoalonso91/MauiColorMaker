using CommunityToolkit.Maui.Alerts;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
    private bool IsRandom = false;
    private string HexValue;

    public MainPage()
    {
        InitializeComponent();
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (IsRandom) return;

        var red = sldRed.Value;
        var green = sldGreen.Value;
        var blue = sldBlue.Value;

        var color = Color.FromRgb(red, green, blue);

        SetColor(color);
    }

    private void SetColor(Color color)
    {
        BtnRandom.BackgroundColor = color;
        Container.BackgroundColor = color;
        HexValue = color.ToHex();
        lblHex.Text = HexValue;
    }

    private void BtnRandom_Clicked(object sender, EventArgs e)
    {
        IsRandom = !IsRandom;
        var random = new Random();
        var color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

        SetColor(color);

        sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;

        IsRandom = !IsRandom;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(HexValue);
        var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
        await toast.Show();
    }
}