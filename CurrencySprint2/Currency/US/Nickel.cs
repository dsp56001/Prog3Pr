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
            this.MonetaryValue = .05M;
            this.Name = "Nickel";
            this.MintMark = MintMark;
            this.Portait = "Thomas Jefferson";
            this.ReverseMotif = "Monticello";
        }

        public Nickel() : this(USCoinMintMark.D)
        { }
    }
}
