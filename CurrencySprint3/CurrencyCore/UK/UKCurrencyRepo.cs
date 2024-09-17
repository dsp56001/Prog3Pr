using Currency.US;
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

        public UKCurrencyRepo(List<ICurrency> Coins) : base(Coins)
        {
        }

        private static List<ICurrency> getCoinLIst()
        {
            return getCurrencyList();
        }

        private static List<ICurrency> getCurrencyList()
        {

            ICoin pen = new Pence();
            ICoin twoP = new TwoPence();
            ICoin fiveP = new FivePence();
            ICoin tenP = new TenPence();
            ICoin tweP = new TwentyPence();
            ICoin fifP = new FivePence();
            ICoin quid = new Pound();
            ICoin tquid = new TwoPound();


            List<ICurrency> coinList = new List<ICurrency>
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

        public List<ICurrency> CurrencyList
        {
            get { return getCurrencyList(); }
        }

        public override ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            USCurrencyRepo change = new USCurrencyRepo();

            Decimal Change = (Decimal)AmountTendered - (Decimal)TotalCost;


            List<ICurrency> coinList = getCurrencyList();
            foreach (USCoin c in coinList)
            {
                while (Change >= (Decimal)c.MonetaryValue)
                {

                    change.AddCurrency(c);
                    Change -= (Decimal)c.MonetaryValue;
                }
            }



            return change;
        }

        public static new UKCurrencyRepo CreateChange(double Amount)
        {
            return CreateChange(Amount, 0);
        }

        public static new UKCurrencyRepo CreateChange(double AmountTendered, double TotalCost)
        {
            UKCurrencyRepo change = new UKCurrencyRepo();

            Decimal Change = (Decimal)AmountTendered - (Decimal)TotalCost;

            List<ICurrency> curencyList = getCurrencyList();
            foreach (USCoin c in curencyList)
            {
                while (Change >= (Decimal)c.MonetaryValue)
                {

                    change.AddCurrency(c);
                    Change -= (Decimal)c.MonetaryValue;
                }
            }

            return change;
        }

        public override ICurrencyRepo Reduce()
        {
            ICurrencyRepo reduced = this.MakeChange(this.TotalValue());
            return reduced;
        }
    }
}
