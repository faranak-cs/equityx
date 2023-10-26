namespace EquityX.Maui.Views;

using EquityX.Maui.Models;
using EquityX.Maui.ViewModels;
using System.Collections.ObjectModel;




public partial class CryptoPage : ContentPage
{
    
    public CryptoPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var cryptos = new ObservableCollection<EquityX.Maui.Models.Crypto>(CryptoPageViewModel.GetCryptos());
        listCryptos.ItemsSource= cryptos;

    }

    private async void listCryptos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listCryptos.SelectedItem != null)
        {

            //logic
           await Shell.Current.GoToAsync($"{nameof(PortfolioPage)}?cryptoid={((Crypto)listCryptos.SelectedItem).CryptoId}");

            /*DisplayAlert("Status", "OK", "X");*/
        }

    }


    private void btnHome_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}