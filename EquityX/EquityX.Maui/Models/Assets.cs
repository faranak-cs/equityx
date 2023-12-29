namespace EquityX.Maui.Models
{
    public class Assets
    {
        public int AssetId { get; set; }
        public string Name { get; set; }
        public double Investment { get; set; }
        public int Unit { get; set; }

        public List<StockHistory> Summary { get; set; }
    }

    public class StockHistory
    {
        public int Unit { get; set; }
        public double BuyPrice { get; set; }
    }

}
