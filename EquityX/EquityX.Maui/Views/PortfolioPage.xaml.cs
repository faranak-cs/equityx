using CommunityToolkit.Mvvm.Input;

namespace EquityX.Maui.Views;

public partial class PortfolioPage : ContentPage
{
	public PortfolioPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}