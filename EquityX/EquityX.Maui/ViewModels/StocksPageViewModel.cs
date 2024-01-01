using EquityX.Maui.DataSource;
using EquityX.Maui.FileHandler;
using EquityX.Maui.Models;

namespace EquityX.Maui.ViewModels;
public static class StocksPageViewModel
{
    // USED TO CALL FUNCTION "GetRestData"
    private static RESTManager restManager = new RESTManager();

    // LIST OF STOCKS
    public static List<Stock> _stocks;

    // FILE PATH "STOCKS.JSON"
    private static string path = StorageManager.GetFilePath("stocks.json");

    // THIS WILL BE CALLED AS SOON AS THE USER HITS STOCKS PAGE
    public static async Task InitiateRestCall()
    {
        // PERFORM TWO FUNCTIONS
        // 1. REST CALL
        // 2. STORE DATA INTO FILE
        await restManager.GetRestData(path);

        // LOAD DATA FROM FILE
        var Stocks = StorageManager.LoadFromFile<List<Stock>>(path);

        if (Stocks != null)
        {
            _stocks = Stocks;
        }
    }

    // CONSTRUCTOR
    static StocksPageViewModel()
    {
        Task task = InitiateRestCall();
    }

    /// <summary>
    /// GET LIST
    /// </summary>
    /// <returns></returns>
    public static List<Stock> GetStocks() => _stocks;

    /// <summary>
    /// GET STOCK BY ID 
    /// </summary>
    /// <param name="stockid"></param>
    /// <returns></returns>
    public static Stock GetStockById(int stockid)
    {
        var stock = _stocks.FirstOrDefault(x => x.StockId == stockid);

        if (stock != null)
        {
            return new Stock
            {
                StockId = stock.StockId,
                Name = stock.Name,
                Price = stock.Price
            };

        }
        return null;
    }

    /// <summary>
    /// GET STOCK PRICE BY NAME
    /// </summary>
    /// <param name="stockName"></param>
    /// <returns></returns>
    public static double GetStockPriceByName(string stockName)
    {
        var stock = _stocks.FirstOrDefault(x => x.Name == stockName);

        if (stock != null)
        {
            return stock.Price;
        }
        return 0;
    }

    /// <summary>
    /// BUY STOCK LOGIC
    /// </summary>
    /// <param name="stockUnit"></param>
    /// <param name="stockId"></param>
    /// <returns></returns>
    public static string BuyStockByUnit(int stockUnit, int stockId)
    {
        // SHORTCUT
        var user = HomePageViewModel.GetUserById(0);

        // GET THE STOCK SELECTED BY THE USER
        var stock = _stocks.FirstOrDefault(x => x.StockId == stockId);

        if (stock != null)
        {
            var totalPrice = stockUnit * stock.Price;

            // HOW CAN I ACCESS THE FUNDS? DEPENDENCY INJECTION SINGLETON
            if (totalPrice <= user.Funds)
            {
                // UPDATE THE FUNDS
                HomePageViewModel.UpdateFunds(user.Id, totalPrice, "decrease");

                // ADD THE STOCK INTO ASSETS
                PortfolioPageViewModel.AddAsset(new Models.Asset
                {
                    Unit = stockUnit,
                    Name = stock.Name,
                    Investment = totalPrice,
                    Summary = new List<PurchaseHistory>
                    {
                        new PurchaseHistory { Unit = stockUnit, BuyPrice = stock.Price }
                    }
                });


                return "y";
            }
            else
            {
                return "n";
            }
        }
        else { return "n"; }

    }

    // SELL STOCK LOGIC
    public static string SellStockByUnit(int stockUnit, double stockPrice, string stockName)
    {
        // GET SELECTED STOCK FROM ASSETS
        var asset = PortfolioPageViewModel.GetAssetByName(stockName);

        if (asset == null)
        {
            // USER DOES NOT HAVE THE SELECTED STOCK IN ASSETS
            return "n";
        }
        else
        {
            if (stockUnit > asset.Unit)
            {
                return "n";
            }
            else
            {
                var money = stockPrice * stockUnit;

                // SHORTCUT 
                var user = HomePageViewModel.GetUserById(0);

                // UPDATE THE FUNDS
                HomePageViewModel.UpdateFunds(user.Id, money, "increase");

                // REMOVE SELECTED STOCK FROM ASSETS
                PortfolioPageViewModel.RemoveAsset(stockUnit, stockName, stockPrice);

                return "y";
            }
        }
    }
}
