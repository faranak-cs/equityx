// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

using EquityX.Maui.ViewModels;
using System.Collections.ObjectModel;
namespace EquityX.Maui.Views;

public partial class MarketPage : ContentPage
{
    public MarketPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var stocks = new ObservableCollection<Models.Stock>(StocksPageViewModel.GetStocks());
        var cryptos = new ObservableCollection<Models.Crypto>(CryptoPageViewModel.GetCryptos());
        listStocks.ItemsSource = stocks;
        listCrypto.ItemsSource = cryptos;
    }
}