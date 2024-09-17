using Currency;
using Currency.US;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Coininator 9000");

            //Make some Coins
            Nickel n = new Nickel();
            Penny p = new Penny();
            Quarter q = new Quarter();
            Dime d = new Dime();
            HalfDollar hd = new HalfDollar();
            DollarCoin doll = new DollarCoin();

            Console.WriteLine("List of US Coins\n");

            Console.WriteLine(n.About());
            Console.WriteLine(p.About());
            Console.WriteLine(q.About());
            Console.WriteLine(d.About());
            Console.WriteLine(hd.About());
            Console.WriteLine(doll.About());

            
            Console.ReadKey();

        }
    }
}
