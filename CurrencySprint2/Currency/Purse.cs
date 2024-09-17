using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency
{
    public class Purse
    {
        public List<Coin> Coins;

        public Purse()
        {
            this.Coins = new List<Coin>();
        }

        public decimal TotalValue()
        {
            decimal total = 0;
            foreach (Coin c in Coins)
            {
                total += c.MonetaryValue;
            }
            return total;
        }

        public void AddCoin(Coin c)
        {
            this.Coins.Add(c);
        }

        public void RemoveCoin(Coin c)
        {
            this.Coins.Remove(c);
        }

        public string About()
        {
            string strAbout = "Purse has " + this.Coins.Count + " coins.";

            strAbout += "\nHere is a list of the coins:";
            foreach (Coin c in Coins)
            {
                strAbout += "\n" + c.About();
            }

            strAbout += "\nThe total value of the purse is " + this.TotalValue();

            return strAbout;
        }

    }
}
