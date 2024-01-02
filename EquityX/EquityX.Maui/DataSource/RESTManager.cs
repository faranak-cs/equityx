using EquityX.Maui.FileHandler;
using EquityX.Maui.Models;

namespace EquityX.Maui.DataSource;
public class RESTManager
{
    List<Stock> stocks = new List<Stock>();

    // FILE PATH "STOCKS.JSON"
    private static string filePath = StorageManager.GetFilePath("stocks.json");

    /// <summary>
    /// CALL REST API AND
    /// STORE DATA INTO FILE
    /// </summary>
    /// <returns></returns>
    public async Task GetRestData()
    {
        Root root = await REST.FetchStocksData();

        if (root != null)
        {
            int id = 0;
            foreach (var result in root.quoteResponse.result)
            {
                Stock stock = new Stock
                {
                    StockId = id,
                    Name = result.shortName,
                    Symbol = result.symbol,
                    MarketPrice = result.regularMarketPrice,
                    MarketChangePercent = Math.Round(result.regularMarketChangePercent, 2)
                };
                stocks.Add(stock);
                id++;
            }

            // DELETE PREVIOUS DATA
            //string delPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filePath);
            //File.Delete(delPath);

            // STORE DATA INTO FILE
            StorageManager.StoreToFile(filePath, stocks);
        }

        // IF NO INTERNET, PROVIDE MOCK DATA
        else
        {
            // IF FILE IS EMPTY, PROVIDE MOCK DATA
            if (!(StorageManager.IsFileEmpty(filePath)))
            {
                stocks = GetMockData();
                // STORE DATA INTO FILE
                StorageManager.StoreToFile(filePath, stocks);
            }
            else
            {

            }
            {
                // OTHERWISE, USER WILL GET THE CACHED DATA
            }
        }
    }

    /// <summary>
    /// MOCK DATA AS OF 02/01/2024
    /// </summary>
    /// <returns></returns>
    public List<Stock> GetMockData()
    {
        return new List<Stock>
        {
            new Stock { StockId = 0, Name = "Microsoft Corporation", MarketPrice = 376.04, Symbol = "MSFT" },
            new Stock { StockId = 1, Name = "Apple Inc.", MarketPrice = 192.53, Symbol = "AAPL" },
            new Stock { StockId = 2, Name = "Alphabet Inc.", MarketPrice = 140.93, Symbol = "GOOG" },
            new Stock { StockId = 3, Name = "Amazon.com, Inc.", MarketPrice = 151.94, Symbol = "AMZN" },
            new Stock { StockId = 4, Name = "NVIDIA Corporation", MarketPrice = 495.22, Symbol = "NVDA" },
            new Stock { StockId = 5, Name = "Meta Platforms, Inc.", MarketPrice = 353.96, Symbol = "META" },
            new Stock { StockId = 6, Name = "Tesla, Inc.", MarketPrice = 248.48, Symbol = "TSLA" },
            new Stock { StockId = 7, Name = "Oracle Corporation", MarketPrice = 105.43, Symbol = "ORCL" },
            new Stock { StockId = 8, Name = "Intel Corporation", MarketPrice = 50.25, Symbol = "INTC" },
            new Stock { StockId = 9, Name = "International Business Machines", MarketPrice = 163.55, Symbol = "IBM" }
        };
    }
}
