using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency.US
{
    public class Penny : USCoin
    {

        public Penny(USCoinMintMark MintMark)
        {
            this.MonetaryValue = .01M;
            this.Name = "Penny";
            this.MintMark = MintMark;
            this.Portait = "Abraham Lincoln";
            this.ReverseMotif = "Union shield";
            
        }

        public Penny() : this (USCoinMintMark.D)
        {    }
    }
}
