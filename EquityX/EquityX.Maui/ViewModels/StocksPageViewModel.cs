using EquityX.Maui.Models;

namespace EquityX.Maui.ViewModels;

//static repo for mockups/fake data
public static class StocksPageViewModel
{
    public static List<Stock> _stocks = new List<Stock>()
    {
        new Stock {StockId=0, Name="Microsoft", Price=300 },
        new Stock {StockId=1, Name="Apple", Price=350},
        new Stock {StockId=2, Name="Tesla", Price=150 },
        new Stock {StockId=3, Name="Google", Price=400 },
        new Stock {StockId=4, Name="Systems", Price=370.5 },
        new Stock {StockId=5, Name="NetSol", Price=290.75},
        new Stock {StockId=6, Name="SadaPay", Price=150.20 },
        new Stock {StockId=7, Name="NayaPay", Price=100.48 },
        new Stock {StockId=8, Name="Amazon", Price=400 },
        new Stock {StockId=9, Name="Walmart", Price=370.5 },
        new Stock {StockId=10, Name="MasterCard", Price=290.75},
        new Stock {StockId=11, Name="Visa", Price=150.20 },
        new Stock {StockId=12, Name="Oracle", Price=100.48 }
    };

    /// <summary>
    /// LIST
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
