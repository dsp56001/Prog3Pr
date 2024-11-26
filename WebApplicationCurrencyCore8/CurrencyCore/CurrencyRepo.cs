using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency
{
    public class CurrencyRepo : ICurrencyRepo
    {
        public List<ICurrency> Currency { get; set; }
        public List<ICurrency> Coins { get => this.getCoinList(); set => throw new NotImplementedException(); }

        public CurrencyRepo()
        {
            this.Currency = new List<ICurrency>();
        }

        protected virtual List<ICurrency> getCoinList()
        {
            return null;
        }

        public CurrencyRepo(List<ICurrency> Coins)
        {
            this.Currency = Coins;
        }

        /// <summary>
        /// Total Value of all the coins in the service
        /// </summary>
        /// <returns>Total Value</returns>
        public double TotalValue()
        {
            double total = 0;
            foreach (ICurrency c in Currency)
            {
                total += c.MonetaryValue;
            }
            return total;
        }

        public int GetCoinCount()
        {
            return Currency.Count;
        }
        
        /// <summary>
        /// Add a coind to the bank
        /// </summary>
        /// <param name="c"></param>
        public virtual void AddCurrency(ICurrency c)
        {
            this.Currency.Add(c);
        }

        /// <summary>
        /// Removes a coin from the bank.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>return a coin if the removed coin is found. Returns null if nothing is found</returns>
        public virtual ICurrency RemoveCurrency(ICurrency c)
        {
            if (this.Currency.Remove(c))
                return c;
            return null;
        }

        /// <summary>
        /// Tells the total number of coins in the bank. Has Each coins descibe itself with it about method.
        /// Shows the total monetary value of the bank.
        /// </summary>
        /// <returns></returns>
        public string About()
        {
            string strAbout = "Currency Repo has " + this.Currency.Count + " items.";

            strAbout += "\nHere is a list of the coins:";
            foreach (ICurrency c in Currency)
            {
                strAbout += "\n" + c.About();
            }

            strAbout += "\nThe total value of the service is ";
            //strAbout += this.TotalValue();
            strAbout += String.Format("{0:C}", this.TotalValue());

            return strAbout;
        }

        /// <summary>
        /// Returns a bank of change determined by the amount.
        /// </summary>
        /// <param name="Amount">Amount of Change</param>
        /// <returns></returns>
        public virtual ICurrencyRepo MakeChange(double Amount)
        {
            return MakeChange(Amount, 0);
        }

        /// <summary>
        /// Returns a bank of change determined by the Coast and Amount of money tendered
        /// </summary>
        /// <param name="AmountTendered">Money Tendered</param>
        /// <param name="TotalCost">Total Cost</param>
        /// <returns></returns>
        public virtual ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            CurrencyRepo p = new CurrencyRepo();
            //Can't really do it with out knowing what curreny type this is
            
            return p;
        }

        public static ICurrencyRepo CreateChange(double Amount)
        {
            return CreateChange(Amount, 0);
        }

        public static ICurrencyRepo CreateChange(double AmountTendered, double TotalCost)
        {
            CurrencyRepo p = new CurrencyRepo();
            //Can't really do it with out knowing what curreny type this is

            return p;
        }

        public virtual ICurrencyRepo SortByCurrency<T>()
        {
            ICurrencyRepo sorted = new CurrencyRepo();
            foreach(ICurrency  cur in this.Currency)
            {
                if(cur is T)
                {
                    sorted.AddCurrency(cur);
                }
            }
            return sorted;

        }

        public virtual ICurrencyRepo Reduce()
        {
            throw new NotImplementedException();
        }
    }
}
