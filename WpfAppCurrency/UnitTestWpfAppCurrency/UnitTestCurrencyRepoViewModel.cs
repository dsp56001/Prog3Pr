using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfAppCurrency.ViewModels;
using Currency;
using Currency.US;
using System.Collections.ObjectModel;

namespace UnitTestWpfAppCurrency
{
    [TestClass]
    public class UnitTestCurrencyRepoViewModel
    {

        ICurrencyRepo repo;
        CurrenyRepoViewModel vm;

        public UnitTestCurrencyRepoViewModel()
        {

        }

        [TestMethod]
        public void Coins_For_ComboBoxCoins_Collections_AreSame() 
        {
            //Arrange
            repo = new USCurrencyRepo();
            vm = new CurrenyRepoViewModel(repo);

            ObservableCollection<ICoin> testCoinsforcdCoins;

            //Act
            testCoinsforcdCoins = vm.CoinsforcdCoins;
            //Assert
            CollectionAssert.AreEqual(((USCurrencyRepo)repo).CurrencyList, testCoinsforcdCoins);

        }

        //TODO test INotifyPropertyChanged
    }
}
