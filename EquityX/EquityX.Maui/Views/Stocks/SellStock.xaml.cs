using EquityX.Maui.ViewModels;

namespace EquityX.Maui.Views.Stocks;

[QueryProperty(nameof(StockId), "id")]
public partial class SellStock : ContentPage
{
    // CREATE OBJECT OF STOCKS CLASS
    private Models.Stock stock;
    public SellStock()
    {
        InitializeComponent();
    }

    // CREATE "StockId" PROPERTY TO GET ALL DETAILS
    public string StockId
    {
        set
        {
            stock = StocksPageViewModel.GetStockById(int.Parse(value));
            if (stock != null)
            {
                stockCtrl.Stock = stock.Name;
                // STOCKCTRL PRICE DATA TYPE IS STRING
                stockCtrl.Price = stock.MarketPrice.ToString();
                // STOCKCTRL UNIT DATA TYPE IS STRING
                stockCtrl.Unit = 1.ToString();

            }
        }
    }


    // HANDLE STOCK SELL
    private void stockCtrl_OnConfirm(object sender, EventArgs e)
    {
        int stockUnit = int.Parse(stockCtrl.Unit);

        // PASS STOCK UNIT AND STOCK ID TO STOCKS VIEW MODEL FUNCTION
        string response = StocksPageViewModel.SellStockByUnit(stockUnit, stock.MarketPrice, stock.Name);

        // STOCK IS SOLD
        if (response == "y")
        {
            DisplayAlert("Status", "Stock is sold", "OK");
            Shell.Current.GoToAsync("..");

        }
        // STOCK IS NOT SOLD
        else
        {
            DisplayAlert("Status", "Insufficient units to sell stock", "OK");
            Shell.Current.GoToAsync("..");
        }
    }

    // RETURN TO STOCKS PAGE ON CANCEL
    private void stockCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"..");
    }

    // DISPLAY ERROR
    private void stockCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}