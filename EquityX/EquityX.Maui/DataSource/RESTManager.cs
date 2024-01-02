// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

using EquityX.Maui.FileHandler;
using EquityX.Maui.Models;

namespace EquityX.Maui.DataSource;
public class RESTManager
{
    List<Stock> stocks = new List<Stock>();
    List<Crypto> cryptos = new List<Crypto>();

    // FILE PATH "STOCKS.JSON"
    private static string FilePathStock = StorageManager.GetFilePath("stocks.json");
    // FILE PATH "STOCKS.JSON"
    private static string FilePathCrypto = StorageManager.GetFilePath("cryptos.json");

    /// <summary>
    /// CALL REST API AND STORE
    /// STOCKS DATA INTO FILE
    /// </summary>
    /// <returns></returns>
    public async Task GetStockRestData()
    {
        StockRoot root = await REST.FetchStocksData();

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
                    MarketChangePercent = Math.Round(result.regularMarketChangePercent, 2),
                    High = result.regularMarketDayHigh,
                    Low = result.regularMarketDayLow,
                    Open = result.regularMarketOpen,
                    Close = result.regularMarketPreviousClose
                };
                stocks.Add(stock);
                id++;
            }

            // STORE DATA INTO FILE
            StorageManager.StoreToFile(FilePathStock, stocks);
        }

        // IF NO INTERNET, PROVIDE MOCK DATA
        else
        {
            // IF FILE IS EMPTY, PROVIDE MOCK DATA
            if (!(StorageManager.IsFileEmpty(FilePathStock)))
            {
                stocks = GetStockMockData();
                // STORE DATA INTO FILE
                StorageManager.StoreToFile(FilePathStock, stocks);
            }
            else
            {
                // OTHERWISE, USER WILL GET THE CACHED DATA
            }
        }
    }

    /// <summary>
    /// CALL REST API AND STORE
    /// CRYPTO DATA INTO FILE
    /// </summary>
    /// <returns></returns>
    public async Task GetCryptoRestData()
    {
        CryptoRoot root = await REST.FetchCryptoData();

        if (root != null)
        {
            int id = 0;
            foreach (var result in root.quoteResponse.result)
            {
                Crypto crypto = new Crypto
                {
                    CryptoId = id,
                    Name = result.shortName,
                    Symbol = result.symbol,
                    MarketPrice = Math.Round(result.regularMarketPrice, 4),
                    MarketChangePercent = Math.Round(result.regularMarketChangePercent, 2),
                    Open = result.regularMarketOpen,
                    Close = result.regularMarketPreviousClose,
                    High = result.regularMarketDayHigh,
                    Low = result.regularMarketDayLow,
                    FromCurrency = result.fromCurrency
                };
                cryptos.Add(crypto);
                id++;
            }

            // STORE DATA INTO FILE
            StorageManager.StoreToFile(FilePathCrypto, cryptos);
        }

        // IF NO INTERNET, PROVIDE MOCK DATA
        else
        {
            // IF FILE IS EMPTY, PROVIDE MOCK DATA
            if (!(StorageManager.IsFileEmpty(FilePathCrypto)))
            {
                cryptos = GetCryptoMockData();
                // STORE DATA INTO FILE
                StorageManager.StoreToFile(FilePathCrypto, cryptos);
            }
            else
            {
                // OTHERWISE, USER WILL GET THE CACHED DATA
            }
        }
    }

    /// <summary>
    /// STOCKS MOCK DATA AS OF 02/01/2024
    /// </summary>
    /// <returns></returns>
    public List<Stock> GetStockMockData()
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

    /// <summary>
    /// CRYPTO MOCK DATA AS OF 02/01/2024
    /// </summary>
    /// <returns></returns>
    public List<Crypto> GetCryptoMockData()
    {
        return new List<Crypto>
        {
            new Crypto { CryptoId = 0, Name = "Bitcoin USD", MarketPrice = 45006.6, Symbol = "BTC-USD" },
            new Crypto { CryptoId = 1, Name = "Ethereum USD", MarketPrice = 2354.848, Symbol = "ETH-USD" },
            new Crypto { CryptoId = 2, Name = "Solana USD", MarketPrice = 107.2685, Symbol = "SOL-USD" },
            new Crypto { CryptoId = 3, Name = "BNB USD", MarketPrice = 310.0576, Symbol = "BNB-USD" },
            new Crypto { CryptoId = 4, Name = "XRP USD", MarketPrice = 0.6235, Symbol = "XRP-USD" },
            new Crypto { CryptoId = 5, Name = "Dogecoin USD", MarketPrice = 0.0914, Symbol = "DOGE-USD" },
            new Crypto { CryptoId = 6, Name = "Chainlink USD", MarketPrice = 15.2793, Symbol = "LINK-USD" },
            new Crypto { CryptoId = 7, Name = "Litecoin USD", MarketPrice = 73.0615, Symbol = "LTC-USD" },
            new Crypto { CryptoId = 8, Name = "Tether USDt USD", MarketPrice = 1.0004, Symbol = "USDT-USD" },
            new Crypto { CryptoId = 9, Name = "Avalanche USD", MarketPrice = 40.9835, Symbol = "AVAX-USD" }
        };
    }
}
