// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

namespace EquityX.Maui.Models;
public class CryptoQuoteResponse
{
    public List<CryptoResult> result { get; set; }
    public object error { get; set; }
}

public class CryptoResult
{
    public string language { get; set; }
    public string region { get; set; }
    public string quoteType { get; set; }
    public string typeDisp { get; set; }
    public string quoteSourceName { get; set; }
    public bool triggerable { get; set; }
    public string customPriceAlertConfidence { get; set; }
    public string currency { get; set; }
    public string marketState { get; set; }
    public double regularMarketChangePercent { get; set; }
    public double regularMarketPrice { get; set; }
    public string exchange { get; set; }
    public string shortName { get; set; }
    public string longName { get; set; }
    public string messageBoardId { get; set; }
    public string exchangeTimezoneName { get; set; }
    public string exchangeTimezoneShortName { get; set; }
    public int gmtOffSetMilliseconds { get; set; }
    public string market { get; set; }
    public bool esgPopulated { get; set; }
    public long firstTradeDateMilliseconds { get; set; }
    public int priceHint { get; set; }
    public long circulatingSupply { get; set; }
    public string lastMarket { get; set; }
    public long volume24Hr { get; set; }
    public long volumeAllCurrencies { get; set; }
    public string fromCurrency { get; set; }
    public string toCurrency { get; set; }
    public string coinMarketCapLink { get; set; }
    public double regularMarketChange { get; set; }
    public int regularMarketTime { get; set; }
    public double regularMarketDayHigh { get; set; }
    public string regularMarketDayRange { get; set; }
    public double regularMarketDayLow { get; set; }
    public long regularMarketVolume { get; set; }
    public double regularMarketPreviousClose { get; set; }
    public string fullExchangeName { get; set; }
    public double regularMarketOpen { get; set; }
    public long averageDailyVolume3Month { get; set; }
    public long averageDailyVolume10Day { get; set; }
    public int startDate { get; set; }
    public string coinImageUrl { get; set; }
    public string logoUrl { get; set; }
    public double fiftyTwoWeekLowChange { get; set; }
    public double fiftyTwoWeekLowChangePercent { get; set; }
    public string fiftyTwoWeekRange { get; set; }
    public double fiftyTwoWeekHighChange { get; set; }
    public double fiftyTwoWeekHighChangePercent { get; set; }
    public double fiftyTwoWeekLow { get; set; }
    public double fiftyTwoWeekHigh { get; set; }
    public double fiftyTwoWeekChangePercent { get; set; }
    public double fiftyDayAverage { get; set; }
    public double fiftyDayAverageChange { get; set; }
    public double fiftyDayAverageChangePercent { get; set; }
    public double twoHundredDayAverage { get; set; }
    public double twoHundredDayAverageChange { get; set; }
    public double twoHundredDayAverageChangePercent { get; set; }
    public long marketCap { get; set; }
    public int sourceInterval { get; set; }
    public int exchangeDataDelayedBy { get; set; }
    public bool tradeable { get; set; }
    public bool cryptoTradeable { get; set; }
    public string symbol { get; set; }
}
public class CryptoRoot
{
    public CryptoQuoteResponse quoteResponse { get; set; }
}

