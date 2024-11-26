using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Currency.US
{
    [Serializable]
    public class Nickel : USCoin
    {
        public Nickel(USCoinMintMark MintMark)
        {
            this.MonetaryValue = .05;
            this.Name = "Nickel";
            this.MintMark = MintMark;
        }

        public Nickel() : this(USCoinMintMark.D)
        { }

        protected Nickel(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
