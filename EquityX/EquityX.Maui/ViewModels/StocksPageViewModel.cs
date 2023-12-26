using EquityX.Maui.Models;

namespace EquityX.Maui.ViewModels
{
    //static repo for mockups/fake data
    public static class StocksPageViewModel
    {
        public static List<Stocks> _stocks = new List<Stocks>(){
        new Stocks {StockId=0, Name="Microsoft", Price=300 },
        new Stocks {StockId=1, Name="Apple", Price=350},
        new Stocks {StockId=2, Name="Tesla", Price=150 },
        new Stocks {StockId=3, Name="Google", Price=400 },
        new Stocks {StockId=4, Name="Systems", Price=370.5 },
        new Stocks {StockId=5, Name="NetSol", Price=290.75},
        new Stocks {StockId=6, Name="SadaPay", Price=150.20 },
        new Stocks {StockId=7, Name="NayaPay", Price=100.48 },
        new Stocks {StockId=8, Name="Amazon", Price=400 },
        new Stocks {StockId=9, Name="Walmart", Price=370.5 },
        new Stocks {StockId=10, Name="MasterCard", Price=290.75},
        new Stocks {StockId=11, Name="Visa", Price=150.20 },
        new Stocks {StockId=12, Name="Oracle", Price=100.48 },
        };

        public static List<Stocks> GetStocks() => _stocks;

        public static Stocks GetStockById(int stockid)
        {
            var stock = _stocks.FirstOrDefault(x => x.StockId == stockid);

            if (stock != null)
            {
                return new Stocks
                {
                    StockId = stock.StockId,
                    Name = stock.Name,
                    Price = stock.Price
                };

            }
            return null;
        }

        // BUY STOCK LOGIC
        public static string BuyStockByUnit(int stockUnit, int stockId)
        {
            // SHORTCUT
            var _users = HomePageViewModel.GetUsers();
            var user = _users.FirstOrDefault(x => x.Id == 0);

            // GET THE STOCK
            var stock = _stocks.FirstOrDefault(x => x.StockId == stockId);

            if (stock != null)
            {
                var totalPrice = stockUnit * stock.Price;

                // HOW CAN I ACCESS THE FUNDS?
                if (totalPrice <= user.Funds)
                {
                    user.Funds -= totalPrice;

                    // ADD THE STOCK INTO INVESTMENTS
                    PortfolioPageViewModel.AddAsset(new Models.Assets
                    {

                        Name = stock.Name,
                        Investment = stock.Price
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
        public static string SellStockByUnit(int stockUnit, int stockId)
        {
            if (stockUnit == 1)
            {
                return "y";
            }
            else
            {
                return "n";
            }

        }
    }




}
