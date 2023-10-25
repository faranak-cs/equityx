namespace EquityX.Maui.Views;

public partial class MarketPage : ContentPage
{
	public MarketPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}