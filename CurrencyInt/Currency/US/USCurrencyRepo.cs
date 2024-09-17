using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Currency.US
{
    public class USCurrencyRepo : SaveableCurrenyRepo
    {

        public USCurrencyRepo()
        {

        }

        public USCurrencyRepo(List<ICoin> Coins) : base(Coins)
        {
        }

        private static List<ICoin> getCoinLIst()
        {
            ICoin n = new Nickel();
            ICoin pen = new Penny();
            ICoin q = new Quarter();
            ICoin d = new Dime();
            ICoin hd = new HalfDollar();
            ICoin doll = new DollarCoin();

            List<ICoin> coinList = new List<ICoin>
            {
                { doll },
                { hd },
                { q },
                { d },
                { n },
                { pen }
            };
            return coinList.OrderByDescending(c=>c.MonetaryValue).ToList();

        }

        public List<ICoin> CurrencyList
        {
            get { return getCoinLIst(); }
        }

        public override ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            USCurrencyRepo change = new USCurrencyRepo();

            Decimal Change = (Decimal)AmountTendered - (Decimal)TotalCost;


            List<ICoin> coinList = getCoinLIst();
            foreach(USCoin c in coinList)
            {
                while (Change >= (Decimal)c.MonetaryValue)
                {

                    change.AddCoin(c);
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

            List<ICoin> coinList = getCoinLIst();
            foreach (USCoin c in coinList)
            {
                while (Change >= (Decimal)c.MonetaryValue)
                {

                    change.AddCoin(c);
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
