using EquityX.Maui.FileHandler;
using EquityX.Maui.Models;

namespace EquityX.Maui.ViewModels;
public static class StocksPageViewModel
{
    // LIST OF STOCKS
    public static List<Stock> _stocks = new List<Stock>();

    // FILE PATH "STOCKS.JSON"
    private static string path = StorageManager.GetFilePath("stocks.json");

    // LOAD DATA FROM FILE
    private static void LoadsStocks()
    {
        var Stocks = StorageManager.LoadFromFile<List<Stock>>(path);

        if (Stocks != null)
        {
            _stocks = Stocks;
        }
    }

    /// <summary>
    /// GET STOCKS LIST
    /// </summary>
    /// <returns></returns>
    public static List<Stock> GetStocks()
    {
        LoadsStocks();
        return _stocks;
    }

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
                MarketPrice = stock.MarketPrice
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
        LoadsStocks();
        var stock = _stocks.FirstOrDefault(x => x.Name == stockName);

        if (stock != null)
        {
            return stock.MarketPrice;
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
            var totalPrice = stockUnit * stock.MarketPrice;

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
                    AssetSymbol = stock.Symbol,
                    AssetType = "stock",
                    Summary = new List<PurchaseHistory>
                    {
                        new PurchaseHistory { Unit = stockUnit, BuyPrice = stock.MarketPrice }
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
