using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Currency.UK
{
    class TwoPence : UKCoin
    {
        public TwoPence()
        {
            this.MonetaryValue = .02;
            this.Name = "Two Pence";       
        }

        protected TwoPence(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
