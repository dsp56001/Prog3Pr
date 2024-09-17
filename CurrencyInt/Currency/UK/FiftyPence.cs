using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Currency.UK
{
    public class FiftyPence : UKCoin
    {

        public FiftyPence()
        {
            this.MonetaryValue = .50;
            this.Name = "Fifty Pee";
            
        }

        protected FiftyPence(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
