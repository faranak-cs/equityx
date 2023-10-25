namespace EquityX.Maui.Views;

public partial class StocksPage : ContentPage
{
	public StocksPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}