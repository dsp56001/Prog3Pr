using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency
{
    public interface ICurrencyRepo
    {
        List<ICurrency> Currency { get; set; }

        double TotalValue();

        int GetCoinCount();

        void AddCurrency(ICurrency c);

        ICurrency RemoveCurrency(ICurrency c);

        string About();

        ICurrencyRepo MakeChange(double Amount);

        ICurrencyRepo MakeChange(double AmountTendered, double TotalCost);

        ICurrencyRepo SortByCurrency<T>();

        ICurrencyRepo Reduce();


    }
}
