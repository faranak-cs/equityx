using EquityX.Maui.Models;

namespace EquityX.Maui.ViewModels;

//static repo for mockups/fake data
public static class CryptoPageViewModel
{
    public static List<Crypto> _cryptos = new List<Crypto>()
    {
        new Crypto {CryptoId=0, Name="Bitcoin", Price=30000},
        new Crypto {CryptoId=1, Name="Ethereum", Price=1500},
        new Crypto {CryptoId=2, Name="Ripple", Price=100},
        new Crypto {CryptoId=3, Name="DogeCoin", Price=50}
    };

    /// <summary>
    /// LIST
    /// </summary>
    /// <returns></returns>
    public static List<Crypto> GetCryptos() => _cryptos;

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
                Price = crypto.Price,
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
        var crypto = _cryptos.FirstOrDefault(x => x.Name == cryptoName);

        if (crypto != null)
        {
            return crypto.Price;
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
        // SHORTCUT
        var user = HomePageViewModel.GetUserById(0);

        // GET THE CRYPTO SELECTED BY THE USER
        var crypto = _cryptos.FirstOrDefault(x => x.CryptoId == cryptoId);

        if (crypto != null)
        {
            var totalPrice = cryptoUnit * crypto.Price;

            // HOW CAN I ACCESS THE FUNDS? DEPENDENCY INJECTION SINGLETON
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
                    Summary = new List<PurchaseHistory>
                    {
                        new PurchaseHistory { Unit = cryptoUnit, BuyPrice = crypto.Price }
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

                // SHORTCUT 
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
