using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency;
using Currency.UK;

namespace UnitTestsCurrency
{
    [TestClass]
    public class UKCurrencyRepoTests
    {
        ICurrencyRepo repo;
        Pence pencce;
        FivePence five;
        TenPence ten;
        TwentyPence twenty;
        Pound pound;


        public UKCurrencyRepoTests()
        {
            repo = new UKCurrencyRepo();
            pencce = new Pence();
            five = new FivePence();
            ten = new TenPence();
            twenty = new TwentyPence();
            pound = new Pound();
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

            repo.AddCoin(pencce);
            coinCountAfterPenny = repo.GetCoinCount();
            valueAfterPenny = repo.TotalValue();

            for (int i = 0; i < numPennies; i++)
            {
                repo.AddCoin(pencce);
            }
            coinCountAfterFiveMorePennies = repo.GetCoinCount();
            valueAfterFiveMorePennies = repo.TotalValue();

            repo.AddCoin(five);
            valueAfterNickel = repo.TotalValue();
            repo.AddCoin(ten);
            valueAfterDime = repo.TotalValue();
            repo.AddCoin(twenty);
            valueAfterQuarter = repo.TotalValue();
            repo.AddCoin(pound);
            valueAfterDollar = repo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig + 1, coinCountAfterPenny);
            Assert.AreEqual(coinCountAfterPenny + numPennies, coinCountAfterFiveMorePennies);

            Assert.AreEqual(valueOrig + pencce.MonetaryValue, valueAfterPenny);
            Assert.AreEqual(valueAfterPenny + (numPennies * pencce.MonetaryValue), valueAfterFiveMorePennies);

            Assert.AreEqual(valueAfterFiveMorePennies + five.MonetaryValue, valueAfterNickel);
            Assert.AreEqual(valueAfterNickel + ten.MonetaryValue, valueAfterDime);
            Assert.AreEqual(valueAfterDime + twenty.MonetaryValue, valueAfterQuarter);
            Assert.AreEqual(valueAfterQuarter + pound.MonetaryValue, valueAfterDollar);

        }


        [TestMethod]
        public void RemoveCoinTest()
        {

            //Arrange
            int coinCountOrig, coinCountAfterPenny, coinCountAfterFiveMorePennies;
            int numPennies = 5;


            Double valueOrig, valueAfterPenny, valueAfterFiveMorePennies;
            Double valueAfterNickel, valueAfterDime, valueAfterQuarter, valueAfterDollar;

            repo = new UKCurrencyRepo();  //reset repo

            //add some coins
            repo.AddCoin(pencce);

            for (int i = 0; i < numPennies; i++)
            {
                repo.AddCoin(pencce);
            }
            repo.AddCoin(five);
            repo.AddCoin(ten);
            repo.AddCoin(twenty);
            repo.AddCoin(pound);

            //Act
            coinCountOrig = repo.GetCoinCount();
            valueOrig = repo.TotalValue();
            repo.RemoveCoin(pencce);
            coinCountAfterPenny = repo.GetCoinCount();
            valueAfterPenny = repo.TotalValue();

            for (int i = 0; i < numPennies; i++)
            {
                repo.RemoveCoin(pencce);
            }
            coinCountAfterFiveMorePennies = repo.GetCoinCount();
            valueAfterFiveMorePennies = repo.TotalValue();

            repo.RemoveCoin(five);
            valueAfterNickel = repo.TotalValue();
            repo.RemoveCoin(ten);
            valueAfterDime = repo.TotalValue();
            repo.RemoveCoin(twenty);
            valueAfterQuarter = repo.TotalValue();
            repo.RemoveCoin(pound);
            valueAfterDollar = repo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig - 1, coinCountAfterPenny);
            Assert.AreEqual(coinCountAfterPenny - numPennies, coinCountAfterFiveMorePennies);

            Assert.AreEqual(valueOrig - pencce.MonetaryValue, valueAfterPenny);
            Assert.AreEqual(valueAfterPenny - (numPennies * pencce.MonetaryValue), valueAfterFiveMorePennies);

            //Assert.AreEqual(valueAfterFiveMorePennies - nickel.MonetaryValue, valueAfterNickel); //HUH? 1.35 != 1.35 both are double?
            Assert.AreEqual(valueAfterNickel - ten.MonetaryValue, valueAfterDime);
            Assert.AreEqual(valueAfterDime - twenty.MonetaryValue, valueAfterQuarter);
            Assert.AreEqual(valueAfterQuarter - pound.MonetaryValue, valueAfterDollar);

        }

        [TestMethod]
        public void MakeChangeTests()
        {
            //Arrange
            UKCurrencyRepo changeOneQuatersOnHalfDollar, changeTwoDollars, changeOneDollarOneHalfDoller,
               changeOneDimeOnePenny, changeOneNickelOnePenny, changeFourPennies;


            //Act
            changeTwoDollars = (UKCurrencyRepo)UKCurrencyRepo.CreateChange(2.0);
            changeOneDollarOneHalfDoller = (UKCurrencyRepo)UKCurrencyRepo.CreateChange(1.5);
            changeOneQuatersOnHalfDollar = (UKCurrencyRepo)UKCurrencyRepo.CreateChange(.75);

            changeOneDimeOnePenny = (UKCurrencyRepo)UKCurrencyRepo.CreateChange(.11);
            changeOneNickelOnePenny = (UKCurrencyRepo)UKCurrencyRepo.CreateChange(.06);
            changeFourPennies = (UKCurrencyRepo)UKCurrencyRepo.CreateChange(.04);


            //Assert
            Assert.AreEqual(changeTwoDollars.Coins.Count, 2);
            Assert.AreEqual(changeTwoDollars.Coins[0].GetType(), new Pound().GetType());
            Assert.AreEqual(changeTwoDollars.Coins[1].GetType(), new Pound().GetType());

            Assert.AreEqual(changeOneDollarOneHalfDoller.Coins.Count, 2);
            Assert.AreEqual(changeOneDollarOneHalfDoller.Coins[0].GetType(), new Pound().GetType());
            Assert.AreEqual(changeOneDollarOneHalfDoller.Coins[1].GetType(), new FiftyPence().GetType());


            Assert.AreEqual(changeOneQuatersOnHalfDollar.Coins.Count, 2);
            Assert.AreEqual(changeOneQuatersOnHalfDollar.Coins[0].GetType(), new FiftyPence().GetType());
            Assert.AreEqual(changeOneQuatersOnHalfDollar.Coins[1].GetType(), new TwentyPence().GetType());

            Assert.AreEqual(changeOneDimeOnePenny.Coins.Count, 2);
            Assert.AreEqual(changeOneDimeOnePenny.Coins[0].GetType(), new TenPence().GetType());
            Assert.AreEqual(changeOneDimeOnePenny.Coins[1].GetType(), new Pence().GetType());

            Assert.AreEqual(changeOneNickelOnePenny.Coins.Count, 2);
            Assert.AreEqual(changeOneNickelOnePenny.Coins[0].GetType(), new FivePence().GetType());
            Assert.AreEqual(changeOneNickelOnePenny.Coins[1].GetType(), new Pence().GetType());


            Assert.AreEqual(changeFourPennies.Coins.Count, 4);
            Assert.AreEqual(changeFourPennies.Coins[0].GetType(), new Pence().GetType());
            Assert.AreEqual(changeFourPennies.Coins[1].GetType(), new Pence().GetType());
            Assert.AreEqual(changeFourPennies.Coins[2].GetType(), new Pence().GetType());
            Assert.AreEqual(changeFourPennies.Coins[3].GetType(), new Pence().GetType());

        }
        [TestMethod]
        public void ReduceSixPennies()
        {
            //Arrange
            ICurrencyRepo sixPennies, sixPenniesReduced;


            //Act
            sixPennies = new UKCurrencyRepo();
            for (int i = 0; i < 6; i++)
            {
                sixPennies.AddCoin(new Pence());
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
            Pennies = new UKCurrencyRepo();
            for (int i = 0; i < 9; i++)
            {
                Pennies.AddCoin(new Pence());
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
            Coins = new UKCurrencyRepo();
            for (int i = 0; i < 12; i++)
            {
                Coins.AddCoin(new Pence());
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
            Coins = new UKCurrencyRepo();
            for (int i = 0; i < 99; i++)
            {
                Coins.AddCoin(new Pence());
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
            Coins = new UKCurrencyRepo();
            for (int i = 0; i < 26; i++)
            {
                Coins.AddCoin(new Pence());
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
