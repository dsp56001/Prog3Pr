using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency.US
{
    public class Quarter : USCoin
    {
        public Quarter(USCoinMintMark MintMark)
        {
            this.MonetaryValue = .25M;
            this.Name = "Quarter";
            this.MintMark = MintMark;
        }

        public Quarter() : this(USCoinMintMark.D)
        { }
    }
}
