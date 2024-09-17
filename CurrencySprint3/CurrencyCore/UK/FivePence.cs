using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Currency.UK
{
    public class FivePence : UKCoin
    {
        public FivePence()
        {
            this.MonetaryValue = .05;
            this.Name = "Five Pee"; 
        }

        protected FivePence(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
