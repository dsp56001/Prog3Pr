using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.UK
{
    public class UKCurrencyRepo : SaveableCurrenyRepo
    {
        public UKCurrencyRepo()
        {

        }

        public UKCurrencyRepo(List<ICoin> Coins) : base(Coins)
        {
        }

        private static List<ICoin> getCoinLIst()
        {
            
            ICoin pen = new Pence();
            ICoin twoP = new TwoPence();
            ICoin fiveP = new FivePence();
            ICoin tenP = new TenPence();
            ICoin tweP = new TwentyPence();
            ICoin fifP = new FivePence();
            ICoin quid = new Pound();
            ICoin tquid = new TwoPound();


            List<ICoin> coinList = new List<ICoin>
            {
                { tquid },
                { quid },
                { fifP },
                { tweP },
                { tenP },
                { fiveP },
                { twoP },
                { pen },
            };
            return coinList.OrderByDescending(c => c.MonetaryValue).ToList();

        }
    }
}
