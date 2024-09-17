using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency.US
{
    public class DollarCoin : USCoin
    {
        public DollarCoin(USCoinMintMark MintMark)
        {
            this.MonetaryValue = 1;
            this.Name = "Dollar Coin";
            this.MintMark = MintMark;
        }

        public DollarCoin() : this(USCoinMintMark.D)
        { }
    }
}