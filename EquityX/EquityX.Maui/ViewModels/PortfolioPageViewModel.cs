using EquityX.Maui.Models;

namespace EquityX.Maui.ViewModels
{

    //static repo for mockups/fake data
    public static class PortfolioPageViewModel
    {
        //public static List<Assets> _assets = new List<Assets>()
        //{  new Assets {AssetId=0, Name="Google", Investment=400, Unit=1},
        //   new Assets {AssetId=1, Name="Google", Investment=400, Unit=1}
        //};

        /// <summary>
        /// LIST FOR PORTFOLIO PAGE
        /// </summary>
        public static List<Assets> _assets = new List<Assets>()
        {
            new Assets {AssetId=0, Name="Google", Investment=800, Unit=2}
        };

        public static List<Assets> GetAssets() => _assets;

        /// <summary>
        /// TOTAL ASSETS VALUE
        /// </summary>
        /// <returns></returns>
        public static double GetSum()
        {
            double sum = 0;
            foreach (var asset in _assets)
            {
                sum = sum + asset.Investment;

            }
            return sum;
        }


        //will be used to display history of individual asset
        //public static Assets GetAssetById(int assetId)
        //{
        //    var asset = _unique_assets.FirstOrDefault(x => x.AssetId == assetId);

        //    if (asset != null)
        //    {
        //        return new Assets
        //        {
        //            AssetId = asset.AssetId,
        //            Name = asset.Name,
        //            Investment = asset.Investment,
        //            Unit = asset.Unit
        //        };
        //    }

        //    return null;
        //}

        // GET ASSET BY NAME
        public static Assets GetAssetByName(string assetName)
        {
            var asset = _assets.FirstOrDefault(x => x.Name == assetName);

            if (asset != null)
            {
                return new Assets
                {
                    AssetId = asset.AssetId,
                    Name = asset.Name,
                    Investment = asset.Investment,
                    Unit = asset.Unit
                };
            }

            return null;
        }

        /// <summary>
        /// THIS WILL HANDLE THE LOGIC TO ADD THE ASSET
        /// </summary>
        /// <param name="asset"></param>
        public static void AddAsset(Assets asset)
        {
            // PORTFOLIO PAGE
            var existingAsset = _assets.FirstOrDefault(x => x.Name == asset.Name);
            if (existingAsset == null)
            {
                if (_assets.Count == 0)
                { // LIST IS EMPTY
                    asset.AssetId = 0;
                    _assets.Add(asset);
                }
                else
                { // LIST IS NOT EMPTY
                    asset.AssetId = (_assets.Max(x => x.AssetId)) + 1;
                    _assets.Add(asset);
                }
            }
            else
            {
                existingAsset.Investment += asset.Investment;
                existingAsset.Unit += asset.Unit;
            }
        }

        /// <summary>
        /// THIS WILL HANDLE THE LOGIC TO REMOVE THE ASSET
        /// </summary>
        /// <param name="stockUnit"></param>
        /// <param name="assetName"></param>
        /// <param name="stockPrice"></param>
        public static void RemoveAsset(int stockUnit, string assetName, double stockPrice)
        {
            var asset = _assets.FirstOrDefault(x => x.Name == assetName);

            if (stockUnit == asset.Unit)
            {
                _assets.Remove(asset);
            }
            else
            {
                var totalAmount = stockUnit * stockPrice;
                asset.Unit -= stockUnit;
                // HOW TO DECREASE THE INVESTMENT ?
                asset.Investment -= totalAmount;
            }
        }
    }
}
