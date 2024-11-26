using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Currency.US
{
    [Serializable]
    public class HalfDollar : USCoin
    {
        public HalfDollar()
        {
            this.MonetaryValue = .5;
            this.Name = "Half Dollar";
        }

        protected HalfDollar(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
