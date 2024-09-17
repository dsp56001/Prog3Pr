using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Currency.UK
{
    public class UKCoin : Coin
    {
        public UKCoin()
        {
            
        }

        protected UKCoin(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        /// <summary>
        /// Tells informatrion about  a US Coin
        /// </summary>
        /// <returns></returns>
        public override string About()
        {
            string strAbout = base.About();
            
            return "UK " + strAbout;
        }
    }
}
