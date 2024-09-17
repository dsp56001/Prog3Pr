using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency;

namespace WpfAppCurrency.Models
{

    public class WPFCurrencyRepo : SaveableCurrenyRepo
    {

        
        public WPFCurrencyRepo(List<ICoin> coins) : base(coins)
        {
            
        }

        public double RepoTotal
        {
            get
            {

                return this.TotalValue();
            }
        }

        

    }

}
