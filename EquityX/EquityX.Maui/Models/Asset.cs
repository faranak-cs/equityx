namespace EquityX.Maui.Models;

public class Asset
{
    public int AssetId { get; set; }
    public string Name { get; set; }
    public double Investment { get; set; }
    public int Unit { get; set; }
    public List<PurchaseHistory> Summary { get; set; }
}

public class PurchaseHistory
{
    public int Unit { get; set; }
    public double BuyPrice { get; set; }
    public double CurrentPrice { get; set; }
    public double Difference { get; set; }

}
