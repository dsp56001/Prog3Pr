using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Currency.US
{
    [Serializable]
    public class Quarter : USCoin
    {
        public Quarter(USCoinMintMark MintMark)
        {
            this.MonetaryValue = .25;
            this.Name = "Quarter";
            this.MintMark = MintMark;
        }

        public Quarter() : this(USCoinMintMark.D)
        { }

        protected Quarter(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
