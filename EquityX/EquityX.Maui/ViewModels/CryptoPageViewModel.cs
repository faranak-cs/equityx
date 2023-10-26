using EquityX.Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityX.Maui.ViewModels
{
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

        public static List<Crypto> GetCryptos() => _cryptos;

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
    }
}
