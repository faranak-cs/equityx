// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

using EquityX.Maui.FileHandler;
using EquityX.Maui.Models;

namespace EquityX.Maui.ViewModels;
public static class CryptoPageViewModel
{
    // LIST OF CRYPTOCURRENCIES
    public static List<Crypto> _cryptos = new List<Crypto>();

    // FILE PATH "CRYPTOS.JSON"
    private static string path = StorageManager.GetFilePath("cryptos.json");

    // LOAD DATA FROM FILE
    private static void LoadsCryptos()
    {
        var Cryptos = StorageManager.LoadFromFile<List<Crypto>>(path);

        if (Cryptos != null)
        {
            _cryptos = Cryptos;
        }
    }

    /// <summary>
    /// GET CRYPTOCURRENCIES LIST
    /// </summary>
    /// <returns></returns>
    public static List<Crypto> GetCryptos()
    {
        LoadsCryptos();
        return _cryptos;
    }

    /// <summary>
    /// GET CRYPTO BY ID
    /// </summary>
    /// <param name="cryptoid"></param>
    /// <returns></returns>
    public static Crypto GetCryptoById(int cryptoid)
    {
        var crypto = _cryptos.FirstOrDefault(x => x.CryptoId == cryptoid);

        if (crypto != null)
        {
            return new Crypto
            {
                CryptoId = crypto.CryptoId,
                Name = crypto.Name,
                MarketPrice = crypto.MarketPrice,
            };
        }
        return null;
    }

    /// <summary>
    /// GET CRYPTO PRICE BY NAME
    /// </summary>
    /// <param name="cryptoName"></param>
    /// <returns></returns>
    public static double GetCryptoPriceByName(string cryptoName)
    {
        LoadsCryptos();
        var crypto = _cryptos.FirstOrDefault(x => x.Name == cryptoName);

        if (crypto != null)
        {
            return crypto.MarketPrice;
        }
        return 0;
    }

    /// <summary>
    /// BUY CRYPTO LOGIC
    /// </summary>
    /// <param name="cryptoUnit"></param>
    /// <param name="cryptoId"></param>
    /// <returns></returns>
    public static string BuyCryptoByUnit(int cryptoUnit, int cryptoId)
    {
        // GET USER
        var user = HomePageViewModel.GetUserById(0);

        // GET THE CRYPTO SELECTED BY THE USER
        var crypto = _cryptos.FirstOrDefault(x => x.CryptoId == cryptoId);

        if (crypto != null)
        {
            var totalPrice = cryptoUnit * crypto.MarketPrice;

            if (totalPrice <= user.Funds)
            {
                // UPDATE THE FUNDS
                HomePageViewModel.UpdateFunds(user.Id, totalPrice, "decrease");

                // ADD THE CRYPTO INTO ASSETS
                PortfolioPageViewModel.AddAsset(new Models.Asset
                {
                    Unit = cryptoUnit,
                    Name = crypto.Name,
                    Investment = totalPrice,
                    AssetSymbol = crypto.Symbol,
                    AssetType = "crypto",
                    Summary = new List<PurchaseHistory>
                    {
                        new PurchaseHistory { Unit = cryptoUnit, BuyPrice = crypto.MarketPrice }
                    }
                });


                return "y";
            }
            else
            {
                return "n";
            }
        }
        else { return "n"; }

    }

    // SELL CRYPTO LOGIC
    public static string SellCryptoByUnit(int cryptoUnit, double cryptoPrice, string cryptoName)
    {
        // GET SELECTED CRYPTO FROM ASSETS
        var asset = PortfolioPageViewModel.GetAssetByName(cryptoName);

        if (asset == null)
        {
            // USER DOES NOT HAVE THE SELECTED CRYPTO IN ASSETS
            return "n";
        }
        else
        {
            if (cryptoUnit > asset.Unit)
            {
                return "n";
            }
            else
            {
                var money = cryptoPrice * cryptoUnit;

                // GET USER
                var user = HomePageViewModel.GetUserById(0);

                // UPDATE THE FUNDS
                HomePageViewModel.UpdateFunds(user.Id, money, "increase");

                // REMOVE SELECTED CRYPTO FROM ASSETS
                PortfolioPageViewModel.RemoveAsset(cryptoUnit, cryptoName, cryptoPrice);

                return "y";
            }
        }
    }
}
