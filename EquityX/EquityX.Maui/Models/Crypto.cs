using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityX.Maui.Models
{
    public class Crypto
    {
        public int CryptoId { get; set; }
        public string Name { get; set; }

        // use decimal for money
        public double Price { get; set; }

    }
}
