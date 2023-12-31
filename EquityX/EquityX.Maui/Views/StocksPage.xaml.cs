namespace EquityX.Maui.Views;

using EquityX.Maui.Models;
using EquityX.Maui.ViewModels;
using EquityX.Maui.Views.Stocks;
using System.Collections.ObjectModel;

public partial class StocksPage : ContentPage
{
    public StocksPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var stocks = new ObservableCollection<Stock>(StocksPageViewModel.GetStocks());
        listStocks.ItemsSource = stocks;
    }

    // BUY BUTTON
    private async void btnBuy_Clicked(object sender, EventArgs e)
    {
        if (listStocks.SelectedItem != null)
        {
            // HOW CAN I PASS TWO PARAMETERS?
            await Shell.Current.GoToAsync($"{nameof(BuyStock)}?id={((Stock)listStocks.SelectedItem).StockId}");
            listStocks.SelectedItem = null;
        }
    }

    // SELL BUTTON
    private async void btnSell_Clicked(object sender, EventArgs e)
    {

        if (listStocks.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(SellStock)}?id={((Stock)listStocks.SelectedItem).StockId}");
            listStocks.SelectedItem = null;
        }
    }
}