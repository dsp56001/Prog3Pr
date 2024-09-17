using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Currency.UK
{
    public class TwoPound : UKCoin
    {
        public TwoPound()
        {
            this.MonetaryValue = 2.00;
            this.Name = "Ten Pee";       
        }

        protected TwoPound(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
