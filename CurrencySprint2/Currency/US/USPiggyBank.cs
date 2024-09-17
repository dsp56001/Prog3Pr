using System;
using System.Collections.Generic;
using System.Text;

namespace Currency.US
{
    class USPiggyBank : PiggyBank
    {
        public override PiggyBank MakeChange(double AmountTendered, double TotalCost)
        {
            PiggyBank p = new PiggyBank();

            Decimal Change = (Decimal)AmountTendered - (Decimal)TotalCost;


            Nickel n = new Nickel();
            Penny pen = new Penny();
            Quarter q = new Quarter();
            Dime d = new Dime();
            HalfDollar hd = new HalfDollar();
            DollarCoin doll = new DollarCoin();

            //Dollars
            while (Change > 1.0M)
            {
                p.AddCoin(doll);
                Change -= 1.0M;
            }
            //Half Dollars
            while (Change > .5M)
            {
                p.AddCoin(hd);
                Change -= .5M;
            }
            //Quarters
            while (Change > .25M)
            {
                p.AddCoin(q);
                Change -= .25M;
            }
            //Dimes
            while (Change > .1M)
            {
                p.AddCoin(d);
                Change -= .1M;
            }
            //Nickels
            while (Change > .05M)
            {
                p.AddCoin(n);
                Change -= .05M;
            }
            //Pennies
            while (Change > 0M)
            {
                p.AddCoin(pen);
                Change -= .01M;
            }

            return p;
        }
    }
}
