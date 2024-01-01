using EquityX.Maui.FileHandler;
using EquityX.Maui.Models;

namespace EquityX.Maui.DataSource;
public class RESTManager
{
    List<Stock> stocks = new List<Stock>();

    /// <summary>
    /// STORE REST DATA INTO FILE
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public async Task GetRestData(string filePath)
    {
        Root root = await REST.FetchStocksData();

        if (stocks != null)
        {
            int id = 0;
            foreach (var result in root.quoteResponse.result)
            {
                Stock stock = new Stock
                {
                    StockId = id,
                    Name = result.shortName,
                    Symbol = result.symbol,
                    Price = result.regularMarketPrice
                };
                stocks.Add(stock);
                id++;
            }

            // DELETE PREVIOUS DATA
            //string delPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filePath);
            //File.Delete(delPath);

            // STORE NEW DATA INTO FILE
            StorageManager.StoreToFile(filePath, stocks);
        }
        else
        {
            // IF NO INTERNET, PROVIDE MOCK DATA
            stocks = GetMockData();
            // STORE DATA INTO FILE
            StorageManager.StoreToFile(filePath, stocks);

        }
    }

    /// <summary>
    /// MOCK DATA
    /// </summary>
    /// <returns></returns>
    public List<Stock> GetMockData()
    {
        return new List<Stock>
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
    }

}
