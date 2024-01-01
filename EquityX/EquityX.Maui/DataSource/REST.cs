using EquityX.Maui.Models;
using Newtonsoft.Json;

namespace EquityX.Maui.DataSource;
public class REST
{
    private const string API_KEY = "HFxyRZz4cc73DYba7hkQD5EQUsIidi1gaYpt3AQW";
    private const string API_URL = "https://yfapi.net/v6/finance/quote?region=US&lang=en&symbols=";
    // TEN STOCKS ARE ALLOWED IN AN API CALL
    private const string symbols = "MSFT,AAPL,GOOG,AMZN,NVDA,META,TSLA,ORCL,INTC,IBM";

    public static async Task<Root> FetchStocksData()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return null;

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{API_URL}{symbols}");
            request.Headers.Add("X-API-KEY", API_KEY);

            try
            {
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Root>(json);
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
