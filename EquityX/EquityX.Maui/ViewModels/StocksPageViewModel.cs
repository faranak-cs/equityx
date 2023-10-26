using EquityX.Maui.ViewModels;
using EquityX.Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        };

        public static List<Stocks> GetStocks() => _stocks;

        public static Stocks GetStockById(int stockid)
        {
            var stock = _stocks.FirstOrDefault(x => x.StockId==stockid);

            if(stock != null)
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
    }

   


}
