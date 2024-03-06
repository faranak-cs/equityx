// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

using EquityX.Maui.Models;
using Newtonsoft.Json;

namespace EquityX.Maui.DataSource;
public class REST
{
    private const string API_KEY = "ENTER YOUR API KEY HERE";

    private const string API_URL = "https://yfapi.net/v6/finance/quote?region=US&lang=en&symbols=";

    // TEN STOCKS ARE ALLOWED IN AN API CALL
    private const string StockSymbols = "MSFT,AAPL,GOOG,AMZN,NVDA,META,TSLA,ORCL,INTC,IBM";

    // TEN CRYPTOCURRENCIES ARE ALLOWED IN AN API CALL
    private const string CryptoSymbols = "BTC-USD,ETH-USD,SOL-USD,BNB-USD,XRP-USD,DOGE-USD,LINK-USD,LTC-USD,USDT-USD,AVAX-USD";

    // GET STOCKS DATA FROM REST API
    public static async Task<StockRoot> FetchStocksData()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return null;

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{API_URL}{StockSymbols}");
            request.Headers.Add("X-API-KEY", API_KEY);

            try
            {
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<StockRoot>(json);
                    return data;
                }
                else
                {
                    return null;
                }
            }

            catch
            {
                // Handle exception
                return null;
            }
        }
    }

    // GET CRYPTOCURRENCIES DATA FROM REST API
    public static async Task<CryptoRoot> FetchCryptoData()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return null;

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{API_URL}{CryptoSymbols}");
            request.Headers.Add("X-API-KEY", API_KEY);

            try
            {
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CryptoRoot>(json);
                    return data;
                }
                else
                {
                    return null;
                }
            }

            catch
            {
                // Handle exception
                return null;
            }
        }
    }

}
