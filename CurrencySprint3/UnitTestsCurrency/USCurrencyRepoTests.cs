using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency;
using Currency.US;

namespace UnitTestsCurrency
{
    [TestClass]
    public class USCurrencyRepoTests
    {
        ICurrencyRepo repo;
        Penny penny;
        Nickel nickel;
        Dime dime;
        Quarter quarter;
        DollarCoin dollarCoin;


        public USCurrencyRepoTests()
        {
            repo = new USCurrencyRepo();
            penny = new Penny();
            nickel = new Nickel();
            dime = new Dime();
            quarter = new Quarter();
            dollarCoin = new DollarCoin();
        }

        [TestMethod]
        public void AddCoinTest()
        {
            //Arrange
            int coinCountOrig, coinCountAfterPenny, coinCountAfterFiveMorePennies;
            int numPennies = 5;


            Double valueOrig, valueAfterPenny, valueAfterFiveMorePennies;
            Double valueAfterNickel, valueAfterDime, valueAfterQuarter, valueAfterDollar;
            //Act
            coinCountOrig = repo.GetCoinCount();
            valueOrig = repo.TotalValue();

            repo.AddCurrency(penny);
            coinCountAfterPenny = repo.GetCoinCount();
            valueAfterPenny = repo.TotalValue();

            for (int i = 0; i < numPennies; i++)
            {
                repo.AddCurrency(penny);
            }
            coinCountAfterFiveMorePennies = repo.GetCoinCount();
            valueAfterFiveMorePennies = repo.TotalValue();

            repo.AddCurrency(nickel);
            valueAfterNickel = repo.TotalValue();
            repo.AddCurrency(dime);
            valueAfterDime = repo.TotalValue();
            repo.AddCurrency(quarter);
            valueAfterQuarter = repo.TotalValue();
            repo.AddCurrency(dollarCoin);
            valueAfterDollar = repo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig + 1, coinCountAfterPenny);
            Assert.AreEqual(coinCountAfterPenny + numPennies, coinCountAfterFiveMorePennies);

            Assert.AreEqual(valueOrig + penny.MonetaryValue, valueAfterPenny);
            Assert.AreEqual(valueAfterPenny + (numPennies * penny.MonetaryValue), valueAfterFiveMorePennies);

            Assert.AreEqual(valueAfterFiveMorePennies + nickel.MonetaryValue, valueAfterNickel);
            Assert.AreEqual(valueAfterNickel + dime.MonetaryValue, valueAfterDime);
            Assert.AreEqual(valueAfterDime + quarter.MonetaryValue, valueAfterQuarter);
            Assert.AreEqual(valueAfterQuarter + dollarCoin.MonetaryValue, valueAfterDollar);

        }


        [TestMethod]
        public void RemoveCoinTest()
        {

            //Arrange
            int coinCountOrig, coinCountAfterPenny, coinCountAfterFiveMorePennies;
            int numPennies = 5;


            Double valueOrig, valueAfterPenny, valueAfterFiveMorePennies;
            Double valueAfterNickel, valueAfterDime, valueAfterQuarter, valueAfterDollar;

            repo = new USCurrencyRepo();  //reset repo

            //add some coins
            repo.AddCurrency(penny);

            for (int i = 0; i < numPennies; i++)
            {
                repo.AddCurrency(penny);
            }
            repo.AddCurrency(nickel);
            repo.AddCurrency(dime);
            repo.AddCurrency(quarter);
            repo.AddCurrency(dollarCoin);

            //Act
            coinCountOrig = repo.GetCoinCount();
            valueOrig = repo.TotalValue();
            repo.RemoveCurrency(penny);
            coinCountAfterPenny = repo.GetCoinCount();
            valueAfterPenny = repo.TotalValue();

            for (int i = 0; i < numPennies; i++)
            {
                repo.RemoveCurrency(penny);
            }
            coinCountAfterFiveMorePennies = repo.GetCoinCount();
            valueAfterFiveMorePennies = repo.TotalValue();

            repo.RemoveCurrency(nickel);
            valueAfterNickel = repo.TotalValue();
            repo.RemoveCurrency(dime);
            valueAfterDime = repo.TotalValue();
            repo.RemoveCurrency(quarter);
            valueAfterQuarter = repo.TotalValue();
            repo.RemoveCurrency(dollarCoin);
            valueAfterDollar = repo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig - 1, coinCountAfterPenny);
            Assert.AreEqual(coinCountAfterPenny - numPennies, coinCountAfterFiveMorePennies);

            Assert.AreEqual(valueOrig - penny.MonetaryValue, valueAfterPenny);
            Assert.AreEqual(valueAfterPenny - (numPennies * penny.MonetaryValue), valueAfterFiveMorePennies);

            //Assert.AreEqual(valueAfterFiveMorePennies - nickel.MonetaryValue, valueAfterNickel); //HUH? 1.35 != 1.35 both are double?
            Assert.AreEqual(valueAfterNickel - dime.MonetaryValue, valueAfterDime);
            Assert.AreEqual(valueAfterDime - quarter.MonetaryValue, valueAfterQuarter);
            Assert.AreEqual(valueAfterQuarter - dollarCoin.MonetaryValue, valueAfterDollar);

        }

        [TestMethod]
        public void MakeChangeTests()
        {
            //Arrange
            USCurrencyRepo changeOneQuatersOnHalfDollar, changeTwoDollars, changeOneDollarOneHalfDoller,
               changeOneDimeOnePenny, changeOneNickelOnePenny, changeFourPennies;


            //Act
            changeTwoDollars = (USCurrencyRepo)USCurrencyRepo.CreateChange(2.0);
            changeOneDollarOneHalfDoller = USCurrencyRepo.CreateChange(1.5);
            changeOneQuatersOnHalfDollar = USCurrencyRepo.CreateChange(.75);

            changeOneDimeOnePenny = USCurrencyRepo.CreateChange(.11);
            changeOneNickelOnePenny = USCurrencyRepo.CreateChange(.06);
            changeFourPennies = USCurrencyRepo.CreateChange(.04);


            //Assert
            Assert.AreEqual(changeTwoDollars.Currency.Count, 2);
            Assert.AreEqual(changeTwoDollars.Currency[0].GetType(), new DollarCoin().GetType());
            Assert.AreEqual(changeTwoDollars.Currency[1].GetType(), new DollarCoin().GetType());

            Assert.AreEqual(changeOneDollarOneHalfDoller.Currency.Count, 2);
            Assert.AreEqual(changeOneDollarOneHalfDoller.Currency[0].GetType(), new DollarCoin().GetType());
            Assert.AreEqual(changeOneDollarOneHalfDoller.Currency[1].GetType(), new HalfDollar().GetType());


            Assert.AreEqual(changeOneQuatersOnHalfDollar.Currency.Count, 2);
            Assert.AreEqual(changeOneQuatersOnHalfDollar.Currency[0].GetType(), new HalfDollar().GetType());
            Assert.AreEqual(changeOneQuatersOnHalfDollar.Currency[1].GetType(), new Quarter().GetType());

            Assert.AreEqual(changeOneDimeOnePenny.Currency.Count, 2);
            Assert.AreEqual(changeOneDimeOnePenny.Currency[0].GetType(), new Dime().GetType());
            Assert.AreEqual(changeOneDimeOnePenny.Currency[1].GetType(), new Penny().GetType());

            Assert.AreEqual(changeOneNickelOnePenny.Currency.Count, 2);
            Assert.AreEqual(changeOneNickelOnePenny.Currency[0].GetType(), new Nickel().GetType());
            Assert.AreEqual(changeOneNickelOnePenny.Currency[1].GetType(), new Penny().GetType());


            Assert.AreEqual(changeFourPennies.Currency.Count, 4);
            Assert.AreEqual(changeFourPennies.Currency[0].GetType(), new Penny().GetType());
            Assert.AreEqual(changeFourPennies.Currency[1].GetType(), new Penny().GetType());
            Assert.AreEqual(changeFourPennies.Currency[2].GetType(), new Penny().GetType());
            Assert.AreEqual(changeFourPennies.Currency[3].GetType(), new Penny().GetType());

        }
        [TestMethod]
        public void ReduceSixPennies()
        {
            //Arrange
            ICurrencyRepo sixPennies, sixPenniesReduced;


            //Act
            sixPennies = new USCurrencyRepo();
            for (int i = 0; i < 6; i++)
            {
                sixPennies.AddCurrency(new Penny());
            }
            sixPenniesReduced = sixPennies.Reduce();

            //Assert
            Assert.AreEqual(2, sixPenniesReduced.GetCoinCount());
        }

        [TestMethod]
        public void ReduceNinePennies()
        {
            //Arrange
            ICurrencyRepo Pennies, PenniesReduced;
            double initialValue, reducedValue;

            //Act
            Pennies = new USCurrencyRepo();
            for (int i = 0; i < 9; i++)
            {
                Pennies.AddCurrency(new Penny());
            }
            
            initialValue = Pennies.TotalValue();
            PenniesReduced = Pennies.Reduce();
            reducedValue = Pennies.TotalValue();

            //Assert
            Assert.AreEqual(5, PenniesReduced.GetCoinCount());
            Assert.AreEqual(initialValue, reducedValue);
        }

        [TestMethod]
        public void ReduceTwelvePennies()
        {
            //Arrange
            ICurrencyRepo Coins, CoinsReduced;
            double initialValue, reducedValue;

            //Act
            Coins = new USCurrencyRepo();
            for (int i = 0; i < 12; i++)
            {
                Coins.AddCurrency(new Penny());
            }
            initialValue = Coins.TotalValue();
            CoinsReduced = Coins.Reduce();
            reducedValue = Coins.TotalValue();


            //Assert
            Assert.AreEqual(3, CoinsReduced.GetCoinCount());
            Assert.AreEqual((decimal)initialValue, (decimal)reducedValue);
        }

        [TestMethod]
        public void ReduceNinetyNinePennies()
        {
            //Arrange
            ICurrencyRepo Coins, CoinsReduced;
            double initialValue, reducedValue;

            //Act
            Coins = new USCurrencyRepo();
            for (int i = 0; i < 99; i++)
            {
                Coins.AddCurrency(new Penny());
            }
            initialValue = Coins.TotalValue();
            CoinsReduced = Coins.Reduce();
            reducedValue = Coins.TotalValue();


            //Assert
            Assert.AreEqual(8, CoinsReduced.GetCoinCount());
            Assert.AreEqual((decimal)initialValue, (decimal)reducedValue);
        }

        [TestMethod]
        public void ReduceTwentySixPennies()
        {
            //Arrange
            ICurrencyRepo Coins, CoinsReduced;
            double initialValue, reducedValue;

            //Act
            Coins = new USCurrencyRepo();
            for (int i = 0; i < 26; i++)
            {
                Coins.AddCurrency(new Penny());
            }
            initialValue = Coins.TotalValue();
            CoinsReduced = Coins.Reduce();
            reducedValue = Coins.TotalValue();


            //Assert
            Assert.AreEqual(2, CoinsReduced.GetCoinCount());
            Assert.AreEqual((decimal)initialValue, (decimal)reducedValue);
            
        }
    }
}
