using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Currency.UK
{
    public class Pound : UKCoin
    {
        public Pound()
        {
            this.MonetaryValue = 1.00;
            this.Name = "Pound Sterling";       
        }

        protected Pound(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
