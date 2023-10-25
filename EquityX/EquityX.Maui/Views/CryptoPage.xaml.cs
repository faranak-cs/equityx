namespace EquityX.Maui.Views;

public partial class CryptoPage : ContentPage
{
	public CryptoPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}