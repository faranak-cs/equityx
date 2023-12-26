namespace EquityX.Maui.Views.StockDetail;
using EquityX.Maui.ViewModels;

[QueryProperty(nameof(UserId), "uid")]
[QueryProperty(nameof(StockId), "sid")]
public partial class BuyStock : ContentPage
{
    // CREATE OBJECT OF STOCKS CLASS
    private Models.Stocks stock;
    private Models.User user;
    public BuyStock()
    {
        InitializeComponent();
    }



    // CREATE "STOCKSID" PROPERTY TO GET ALL DETAILS
    public string StockId
    {
        set
        {
            stock = StocksPageViewModel.GetStockById(int.Parse(value));
            if (stock != null)
            {
                stockCtrl.Stock = stock.Name;
                // STOCKCTRL PRICE DATA TYPE IS STRING
                stockCtrl.Price = stock.Price.ToString();
                // STOCKCTRL UNIT DATA TYPE IS STRING
                stockCtrl.Unit = 1.ToString();

            }
        }
    }

    // CREATE "USERID" PROPERTY TO GET ALL DETAILS
    public string UserId
    {
        set
        {
            user = HomePageViewModel.GetUserById(int.Parse(value));
        }
    }

    // HANDLE STOCK BUY
    private void stockCtrl_OnConfirm(object sender, EventArgs e)
    {
        int stockUnit = int.Parse(stockCtrl.Unit);

        // PASS STOCK UNIT AND STOCK ID TO STOCKS VIEW MODEL FUNCTION
        string response = StocksPageViewModel.BuyStockByUnit(stockUnit, stock.StockId);

        // STOCK IS BOUGHT
        if (response == "y")
        {
            DisplayAlert("Status", "Stock is bought", "OK");
            Shell.Current.GoToAsync("..");

        }
        // STOCK IS NOT BOUGHT
        else
        {
            DisplayAlert("Status", "Insufficient Funds to Buy Stock", "OK");
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