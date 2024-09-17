using Currency;
using Currency.US;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;



namespace WpfAppCurrency.ViewModels
{
    public class CurrenyRepoViewModel : BaseViewModel
    {
        ICurrencyRepo repo;

        private ObservableCollection<ICoin> coinsForcbCoins;
        public ObservableCollection<ICoin> CoinsforcdCoins
        {
            get { return coinsForcbCoins;}
            set { coinsForcbCoins = value; }
        }

        protected string coinName;
        public string CoinName {
            get {
                return coinName; }
            set {
                if (value != coinName)
                {
                    coinName = value;
                    RaisePropertyChangedEvent("CoinName");
                }
                    
            }
        }

        protected int coinNum;
        public int CoinNum
        {
            get
            {
                return coinNum;
            }
            set
            {
                if (value != CoinNum)
                {
                    coinNum = value;
                    RaisePropertyChangedEvent("CoinNum");
                }

            }
        }

       

        public double RepoTotal
        {
            get
            {
                return repo.TotalValue();
            }
        }
        
        ICurrencyRepo Repo
        {
            get {
                
                return repo; }
            set { repo = value;  }
        }

        public ICommand AddCoinCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public CurrenyRepoViewModel(ICurrencyRepo repo) 
        {
            this.repo = repo;
            AddCoinCommand = new BasicCommand(AddCointToRepo);
            LoadCommand = new BasicCommand(LoadRepoFromDisc);
            SaveCommand = new BasicCommand(SaveRepoToDisc);
            NewCommand = new BasicCommand(LoadNewRepo);
            CoinsforcdCoins = new ObservableCollection<ICoin>(
                ((USCurrencyRepo)repo).CurrencyList
            );
            this.CoinNum = 1;
        }

        private void LoadNewRepo()
        {
            repo = new USCurrencyRepo();
            RaisePropertyChangedEvent("RepoTotal");
        }

        private void SaveRepoToDisc()
        {
            if (Repo is USCurrencyRepo)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save the repo?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ((USCurrencyRepo)Repo).Save();
                    MessageBox.Show("Saved");
                }
                
            }
        }

        private void LoadRepoFromDisc()
        {
            if (Repo is USCurrencyRepo)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to load the repo?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.Repo.Coins = ((USCurrencyRepo)Repo).Load().ToList();
                    MessageBox.Show("Loaded");
                    RaisePropertyChangedEvent("RepoTotal");
                }

                
            }
        }

        public ICoin GetCoinByName(string Name)
        {
            var coin = from c in CoinsforcdCoins
                       where c.ToString() == Name
                       select c;
            return coin.First();
        }

        private void AddCointToRepo()
        {
            for (int i = 0; i < this.CoinNum; i++)
            {
                this.AddCoin(GetCoinByName(coinName));
            }    
        }
        
        public void AddCoin(ICoin c)
        {
            repo.AddCoin(c);
            RaisePropertyChangedEvent("RepoTotal");
        }
        
        public ICoin RemoveCoin(ICoin c)
        {
            var coin = repo.RemoveCoin(c);
            RaisePropertyChangedEvent("RepoTotal");
            return coin ;
        }

    }
}
