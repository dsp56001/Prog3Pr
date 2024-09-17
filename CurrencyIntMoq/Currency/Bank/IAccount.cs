using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency.US;

namespace Currency.Bank
{
    public interface IAccount
    {
        IBankUser User { get; }
        int AccountNumber { get; }

        decimal Balance { get; }

        ICurrencyRepo GetAccountRepo();
    }

    public class Account : IAccount
    {
        public IBankUser User => throw new NotImplementedException();

        public int AccountNumber => throw new NotImplementedException();

        public decimal Balance => throw new NotImplementedException();

        public ICurrencyRepo GetAccountRepo()
        {
            return USCurrencyRepo.CreateChange((double)Balance);
        }
    }

}
