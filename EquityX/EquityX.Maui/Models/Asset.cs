namespace EquityX.Maui.Models;

public class Asset
{
    public int AssetId { get; set; }
    public string Name { get; set; }
    public double Investment { get; set; }
    public int Unit { get; set; }
    public string AssetSymbol { get; set; }
    public string AssetType { get; set; }
    public double TotalDifference { get; set; }
    public List<PurchaseHistory> Summary { get; set; }
}

public class PurchaseHistory
{
    public int Unit { get; set; }
    public double BuyPrice { get; set; }
    public double CurrentPrice { get; set; }
    public double Difference { get; set; }

}
