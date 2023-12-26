namespace EquityX.Maui.Views;

using EquityX.Maui.Models;
using EquityX.Maui.ViewModels;
using EquityX.Maui.Views.StockDetail;
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
        var stocks = new ObservableCollection<EquityX.Maui.Models.Stocks>(StocksPageViewModel.GetStocks());
        listStocks.ItemsSource = stocks;
    }

    //private async void listStocks_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    if (listStocks.SelectedItem != null)
    //    {

    //        //logic
    //        //  await Shell.Current.GoToAsync($"{nameof(PortfolioPage)}?stocksid={((Stocks)listStocks.SelectedItem).StockId}");

    //        await Shell.Current.GoToAsync($"{nameof(BuyStock)}?id={((Stocks)listStocks.SelectedItem).StockId}");
    //    }
    //}


    // BUY BUTTON
    private async void btnBuy_Clicked(object sender, EventArgs e)
    {
        if (listStocks.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(BuyStock)}?id={((Stocks)listStocks.SelectedItem).StockId}");
            listStocks.SelectedItem = null;
        }
    }

    // SELL BUTTON
    private async void btnSell_Clicked(object sender, EventArgs e)
    {

        if (listStocks.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(SellStock)}?id={((Stocks)listStocks.SelectedItem).StockId}");
            listStocks.SelectedItem = null;
        }
    }
}