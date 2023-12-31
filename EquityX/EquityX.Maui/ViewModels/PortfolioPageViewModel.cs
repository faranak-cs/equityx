using EquityX.Maui.FileHandler;
using EquityX.Maui.Models;

namespace EquityX.Maui.ViewModels;

public static class PortfolioPageViewModel
{
    /// <summary>
    /// LIST FOR PORTFOLIO PAGE
    /// </summary>
    public static List<Asset> _assets = new List<Asset>();

    // FILE PATH "ASSETS.JSON"
    private static string path = StorageManager.GetFilePath("assets.json");

    // STORE DATA INTO FILE
    private static void StoreAssets()
    {
        StorageManager.StoreToFile(path, _assets);
    }

    // LOAD DATA FROM FILE
    private static void LoadAssets()
    {
        var Assets = StorageManager.LoadFromFile<List<Asset>>(path);

        if (Assets != null)
        {
            _assets = Assets;
        }
    }

    /// <summary>
    /// GET ASSETS
    /// </summary>
    /// <returns></returns>
    public static List<Asset> GetAssets()
    {
        LoadAssets();
        return _assets;
    }

    /// <summary>
    /// TOTAL ASSET VALUE
    /// </summary>
    /// <returns></returns>
    public static double GetSum()
    {
        LoadAssets();

        double sum = 0;
        foreach (var asset in _assets)
        {
            sum += asset.Investment;

        }
        return sum;
    }

    /// <summary>
    /// UPDATE SUMMARY
    /// </summary>
    public static void UpdateSummary()
    {
        LoadAssets();

        foreach (var asset in _assets)
        {
            var stockCurrentPrice = StocksPageViewModel.GetStockPriceByName(asset.Name);
            foreach (var purchase in asset.Summary)
            {
                double totalBuyPrice = purchase.Unit * purchase.BuyPrice;
                double totalCurrentPrice = purchase.Unit * stockCurrentPrice;
                purchase.Difference = totalCurrentPrice - totalBuyPrice;
                purchase.CurrentPrice = stockCurrentPrice;
            }
        }

        StoreAssets();
    }


    /// <summary>
    /// GET ASSET BY ID
    /// </summary>
    /// <param name="assetId"></param>
    /// <returns></returns>
    public static Asset GetAssetById(int assetId)
    {
        LoadAssets();
        var asset = _assets.FirstOrDefault(x => x.AssetId == assetId);

        if (asset != null)
        {
            return new Asset
            {
                AssetId = asset.AssetId,
                Name = asset.Name,
                Investment = asset.Investment,
                Unit = asset.Unit,
                Summary = asset.Summary
            };
        }

        return null;
    }

    /// <summary>
    /// GET ASSET BY NAME
    /// </summary>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public static Asset GetAssetByName(string assetName)
    {
        LoadAssets();
        var asset = _assets.FirstOrDefault(x => x.Name == assetName);

        if (asset != null)
        {
            return new Asset
            {
                AssetId = asset.AssetId,
                Name = asset.Name,
                Investment = asset.Investment,
                Unit = asset.Unit,
                // CHECK ?
                Summary = asset.Summary,

            };
        }

        return null;
    }

    /// <summary>
    /// THIS WILL HANDLE THE LOGIC TO ADD THE ASSET
    /// </summary>
    /// <param name="asset"></param>
    public static void AddAsset(Asset asset)
    {
        LoadAssets();

        // PORTFOLIO PAGE
        var existingAsset = _assets.FirstOrDefault(x => x.Name == asset.Name);
        if (existingAsset == null)
        {
            // STOCK DOES NOT EXIST IN THE LIST
            if (_assets.Count == 0)
            {
                // LIST IS EMPTY
                asset.AssetId = 0;
                _assets.Add(asset);
            }
            else
            {
                // LIST IS NOT EMPTY
                asset.AssetId = (_assets.Max(x => x.AssetId)) + 1;
                _assets.Add(asset);
            }
        }
        else
        {
            // STOCK EXIST IN THE LIST
            existingAsset.Investment += asset.Investment;
            existingAsset.Unit += asset.Unit;
            existingAsset.Summary.AddRange(asset.Summary);
        }

        StoreAssets();
    }

    /// <summary>
    /// THIS WILL HANDLE THE LOGIC TO REMOVE THE ASSET
    /// </summary>
    /// <param name="stockUnit"></param>
    /// <param name="assetName"></param>
    /// <param name="stockPrice"></param>
    public static void RemoveAsset(int stockUnit, string assetName, double stockPrice)
    {
        LoadAssets();

        var asset = _assets.FirstOrDefault(x => x.Name == assetName);

        if (stockUnit == asset.Unit)
        {
            _assets.Remove(asset);
        }
        else
        {
            var totalAmount = stockUnit * stockPrice;
            asset.Unit -= stockUnit;
            asset.Investment -= totalAmount;
        }

        StoreAssets();
    }
}
