using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency
{
    public class PiggyBank 
    {
        public List<ICoin> Coins;

        public PiggyBank()
        {
            this.Coins = new List<ICoin>();
        }

        /// <summary>
        /// Total Value of all the coins in the piggy bank
        /// </summary>
        /// <returns>Total Value</returns>
        public decimal TotalValue()
        {
            decimal total = 0;
            foreach (ICoin c in Coins)
            {
                total += c.MonetaryValue;
            }
            return total;
        }
        
        /// <summary>
        /// Add a coind to the bank
        /// </summary>
        /// <param name="c"></param>
        public void AddCoin(ICoin c)
        {
            this.Coins.Add(c);
        }

        /// <summary>
        /// Removes a coin from the bank
        /// </summary>
        /// <param name="c"></param>
        public void RemoveCoin(ICoin c)
        {
            this.Coins.Remove(c);
        }

        /// <summary>
        /// Tells the total number of coins in the bank. Has Each coins descibe itself with it about method.
        /// Shows the total monetary value of the bank.
        /// </summary>
        /// <returns></returns>
        public string About()
        {
            string strAbout = "Piggy Bank has " + this.Coins.Count + " coins.";

            strAbout += "\nHere is a list of the coins:";
            foreach (ICoin c in Coins)
            {
                strAbout += "\n" + c.About();
            }

            strAbout += "\nThe total value of the bank is ";
            //strAbout += this.TotalValue();
            strAbout += String.Format("{0:C}", this.TotalValue());

            return strAbout;
        }

        /// <summary>
        /// Returns a bank of change determined by the amount.
        /// </summary>
        /// <param name="Amount">Amount of Change</param>
        /// <returns></returns>
        public PiggyBank MakeChange(double Amount)
        {
            return MakeChange(Amount, 0);
        }

        /// <summary>
        /// Returns a bank of change determined by the Coast and Amount of money tendered
        /// </summary>
        /// <param name="AmountTendered">Money Tendered</param>
        /// <param name="TotalCost">Total Cost</param>
        /// <returns></returns>
        public virtual PiggyBank MakeChange(double AmountTendered, double TotalCost)
        {
            PiggyBank p = new PiggyBank();
           
            
            return p;
        }
    }
}
