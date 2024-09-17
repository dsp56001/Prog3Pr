using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency
{
    public abstract class Coin : ICoin 
    {
        
        public int Year { get; set; }
        public decimal MonetaryValue { get; set; }
        //public double  CollectorsValue;
        public string Name { get; set; }
        public string Portait { get; set; }
        public string ReverseMotif { get; set; }

        public Coin()
        {
            this.Name = "Coin";
            this.Year = System.DateTime.Now.Year;
            
        }

        /// <summary>
        /// Tells infomation about a Coin
        /// </summary>
        /// <returns></returns>
        public virtual string About()
        {
            string strAbout = "";
            strAbout += string.Format("{0} is from {1}. It is worth {2}",
                this.Name,
                this.Year,
                
                String.Format("{0:C}",this.MonetaryValue)
            );
            return strAbout;
        }
    }    
}
