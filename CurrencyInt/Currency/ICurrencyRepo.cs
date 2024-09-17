using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency
{
    public interface ICurrencyRepo
    {
        List<ICoin> Coins { get; set; }

        double TotalValue();

        int GetCoinCount();

        void AddCoin(ICoin c);

        ICoin RemoveCoin(ICoin c);

        string About();

        ICurrencyRepo MakeChange(double Amount);

        ICurrencyRepo MakeChange(double AmountTendered, double TotalCost);

        ICurrencyRepo Reduce();


    }
}
