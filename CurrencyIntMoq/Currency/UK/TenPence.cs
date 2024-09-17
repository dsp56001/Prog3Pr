using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Currency.UK
{
    public class TenPence : UKCoin
    {
        public TenPence()
        {
            this.MonetaryValue = .10;
            this.Name = "Ten Pee";       
        }

        protected TenPence(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
