using Currency;
using Currency.US;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfAppCurrency.ViewModels
{
    public class MakeChangeViewModel : BaseViewModel
    {

        USCurrencyRepo repo;

        public USCurrencyRepo Repo
        {
            get { return repo; }
            set { repo = value; }
        }

        protected double repoTotal;
        public double RepoTotal
        {
            get
            {
                 if(repoTotal == 0)
                    repoTotal = repo.TotalValue();
                return repoTotal;
            }
            set
            {
                repoTotal = value;
                RaisePropertyChangedEvent("RepoTotal");
            }
        }

        protected ObservableCollection<ICoin> ocoins;

        public ObservableCollection<ICoin> OCoins
        {
            get {
                if(ocoins == null)
                    ocoins = new ObservableCollection<ICoin>(repo.Coins);
                return ocoins;
            }
            set
            {
                
                ocoins = value;
                RaisePropertyChangedEvent("OCoins");
            }
        }

        public ICommand MakeChangeCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public MakeChangeViewModel(USCurrencyRepo repo)
        {
            this.Repo = repo;
            OCoins.CollectionChanged += OCoins_CollectionChanged;

            MakeChangeCommand = new BasicCommand(UpdateMakeChange);
            SaveCommand = new BasicCommand(Save);
        }

        private void OCoins_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChangedEvent("OCoins");
        }

        private void Save()
        {
            MessageBoxResult result = MessageBox.Show("Do you want to save the repo?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Repo.Save();
                MessageBox.Show("Saved");
            }
            
        }

        private void UpdateMakeChange()
        {
            this.Repo = (USCurrencyRepo)repo.MakeChange(RepoTotal);
            OCoins = new ObservableCollection<ICoin>(repo.Coins);
        }
    }
}
