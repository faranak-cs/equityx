namespace EquityX.Maui.Views;

using EquityX.Maui.Models;
using EquityX.Maui.ViewModels;
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

    private void btnHome_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    //private async void listStocks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    //{
    //    if (listStocks.SelectedItem != null)
    //    {

    //        //logic
    //        await Shell.Current.GoToAsync($"{nameof(PortfolioPage)}?stocksid={((Stocks)listStocks.SelectedItem).StockId}");


    //        // /*DisplayAlert("Status", "OK", "X");*/
    //    }
    //}

    private async void listStocks_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (listStocks.SelectedItem != null)
        {

            //logic
            await Shell.Current.GoToAsync($"{nameof(PortfolioPage)}?stocksid={((Stocks)listStocks.SelectedItem).StockId}");


        }
    }
}