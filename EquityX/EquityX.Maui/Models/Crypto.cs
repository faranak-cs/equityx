// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

namespace EquityX.Maui.Models;

public class Crypto
{
    public int CryptoId { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public double MarketPrice { get; set; }
    public double MarketChangePercent { get; set; }

    // USED FOR MARKET
    public double High { get; set; }
    public double Low { get; set; }
    public double Open { get; set; }
    public double Close { get; set; }
    public string FromCurrency { get; set; }
}
