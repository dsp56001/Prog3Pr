using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Currency.US
{
    public class USCurrencyRepo : CurrencyRepo
    {

        public USCurrencyRepo()
        {

        }

        public USCurrencyRepo(List<ICurrency> currency) : base(currency)
        {
        }

        protected override List<ICurrency> getCoinList()
        {
            return getCurrencyList();
        }

        private static List<ICurrency> getCurrencyList()
        {
            ICoin n = new Nickel();
            ICoin pen = new Penny();
            ICoin q = new Quarter();
            ICoin d = new Dime();
            ICoin hd = new HalfDollar();
            ICoin doll = new DollarCoin();

            List<ICurrency> curList = new List<ICurrency>
            {
                { doll },
                { hd },
                { q },
                { d },
                { n },
                { pen }
            };
            return curList.OrderByDescending(c=>c.MonetaryValue).ToList();

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
            foreach(USCoin c in coinList)
            {
                while (Change >= (Decimal)c.MonetaryValue)
                {

                    change.AddCurrency(c);
                    Change -= (Decimal)c.MonetaryValue;
                }
            }

            

            return change;
        }

        public static new USCurrencyRepo CreateChange(double Amount)
        {
            return CreateChange(Amount, 0);
        }

        public static new USCurrencyRepo CreateChange(double AmountTendered, double TotalCost)
        {
            USCurrencyRepo change = new USCurrencyRepo();

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
