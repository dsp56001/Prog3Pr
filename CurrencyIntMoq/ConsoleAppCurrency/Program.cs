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

            //Piggy bank with 1.99 cents worth of coins
            Console.WriteLine("\nAdd one of each coins to the piggy bank\n");

            PiggyBank pb = new PiggyBank();
            pb.AddCoin(p);
            pb.AddCoin(n);
            pb.AddCoin(d);
            pb.AddCoin(q);
            pb.AddCoin(hd);
            pb.AddCoin(doll);
            Console.WriteLine("\nPiggy bank with one of each coin has a value of " + string.Format("{0:c}",
                pb.TotalValue()));

            Console.WriteLine(pb.About());

            //Make Change Total is $8.02 cash tendered is $10.00    
            Console.WriteLine("\nMake Change Total is $8.02 cash tendered is $10.00");
            PiggyBank c = new PiggyBank();
            c =  c.MakeChange(10, 8.02);
            Console.WriteLine("\nTo make change the piggy bank will return.");
            Console.WriteLine(c.About());


            Console.ReadKey();

        }
    }
}
