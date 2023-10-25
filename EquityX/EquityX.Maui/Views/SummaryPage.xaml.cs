namespace EquityX.Maui.Views;

public partial class SummaryPage : ContentPage
{
	public SummaryPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
       Shell.Current.GoToAsync(nameof(HomePage));
    }
}