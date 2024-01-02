// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

namespace EquityX.Maui.Models;

public class Stock
{
    public int StockId { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public double MarketPrice { get; set; }
    public double MarketChangePercent { get; set; }


    // USED FOR MARKET 
    public string MarketState { get; set; }
    public long MarketCap { get; set; }
    public double High { get; set; }
    public double Low { get; set; }
    public int Volume { get; set; }
    public double Open { get; set; }
    public double Close { get; set; }

}
