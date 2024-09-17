using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Currency.US
{
    [Serializable]
    public class Dime : USCoin
    {
        public Dime(USCoinMintMark MintMark)
        {
            this.MonetaryValue = .1;
            this.Name = "Dime";
            this.MintMark = MintMark;
        }

        public Dime() : this(USCoinMintMark.D)
        { }

        protected Dime(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
