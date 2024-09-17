using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Currency.US
{
    [Serializable]
    public class Penny : USCoin
    {

        public Penny(USCoinMintMark MintMark)
        {
            this.MonetaryValue = .01;
            this.Name = "Penny";
            this.MintMark = MintMark;
        }

        public Penny() : this (USCoinMintMark.D)
        {    }

        protected Penny(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
