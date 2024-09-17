using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency.US
{
    public class Dime : USCoin
    {
        public Dime(USCoinMintMark MintMark)
        {
            this.MonetaryValue = .1M;
            this.Name = "Dime";
            this.MintMark = MintMark;
            this.Portait = "Franklin D. Roosevelt";
            this.ReverseMotif = "torch, oak branch, olive branch";
        }

        public Dime() : this(USCoinMintMark.D)
        { }
    }
}
