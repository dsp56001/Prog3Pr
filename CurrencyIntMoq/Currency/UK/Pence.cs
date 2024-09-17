using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Currency.UK
{
    public class Pence : UKCoin
    {
        public Pence()
        {
            this.MonetaryValue = .01;
            this.Name = "Pence";
            
        }

        protected Pence(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
