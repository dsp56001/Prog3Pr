using Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCurrencyCore31.ViewModels
{
    public class RepoViewModel
    {
        ICurrencyRepo repo;

        public RepoViewModel(ICurrencyRepo repo)
        {
            this.repo = repo;
        }

        public double TotalValue
        {
            get { return repo.TotalValue(); }
        }

        public void MakeChange(Double Amount)
        {
            repo = repo.MakeChange(Amount);
        }

        public List<ICurrency> Coins
        {
            get { return repo.Coins; }
        }
    }
}
