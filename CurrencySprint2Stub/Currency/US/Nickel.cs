using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency.US
{
    public class Nickel : USCoin
    {
        public Nickel(USCoinMintMark MintMark)
        {
            
        }

        public Nickel() : this(USCoinMintMark.D)
        { }
    }
}
