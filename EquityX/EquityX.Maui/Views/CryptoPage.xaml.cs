using EquityX.Maui.Models;
using EquityX.Maui.ViewModels;
using EquityX.Maui.Views.Cryptos;
using System.Collections.ObjectModel;

namespace EquityX.Maui.Views;
public partial class CryptoPage : ContentPage
{
    public CryptoPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var cryptos = new ObservableCollection<Crypto>(CryptoPageViewModel.GetCryptos());
        listCryptos.ItemsSource = cryptos;
    }

    // BUY BUTTON
    private async void btnBuy_Clicked(object sender, EventArgs e)
    {
        if (listCryptos.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(BuyCrypto)}?id={((Crypto)listCryptos.SelectedItem).CryptoId}");
            listCryptos.SelectedItem = null;
        }
    }

    // SELL BUTTON
    private async void btnSell_Clicked(object sender, EventArgs e)
    {
        if (listCryptos.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(SellCrypto)}?id={((Crypto)listCryptos.SelectedItem).CryptoId}");
            listCryptos.SelectedItem = null;
        }
    }
}