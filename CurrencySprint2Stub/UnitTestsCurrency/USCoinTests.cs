using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency.US;
using Currency;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestsCurrency
{
    [TestClass]
    public class USCoinTests
    {

        Penny p;

        public USCoinTests()
        {
            p = new Penny();
        }

        [TestMethod]
        public void USCoinPennyConstructor()
        {
            //Arrange
            Penny p;
            //Act 
            p = new Penny();
            //Assert
            Assert.AreEqual(Currency.US.USCoinMintMark.D, p.MintMark); //D is the default mint mark
            Assert.AreEqual(System.DateTime.Now.Year, p.Year); //Current year is default year
            
        }

        [TestMethod]
        public void USCoinMintMark()
        {
            Assert.AreEqual(USCoin.GetMintNameFromMark(Currency.US.USCoinMintMark.D), "Denver");
            Assert.AreEqual(USCoin.GetMintNameFromMark(Currency.US.USCoinMintMark.P), "Philadephia");
            Assert.AreEqual(USCoin.GetMintNameFromMark(Currency.US.USCoinMintMark.S), "San Francisco");
            Assert.AreEqual(USCoin.GetMintNameFromMark(Currency.US.USCoinMintMark.W), "West Point");
        }

        [TestMethod]
        public void USCoinPennyMonetaryValue()
        {
            //Arrange
            Penny p;
            
            //Act 
            p = new Penny();
            //Assert
            Assert.AreEqual(.01M, p.MonetaryValue);
        }

        [TestMethod]
        public void USCoinPennyAbout()
        {
            //Arrange
            Penny p;
            //Act 
            p = new Penny();
            //Assert
            Assert.AreEqual($"US Penny is from {System.DateTime.Now.Year}. It is worth {p.MonetaryValue:c}. It was made in Denver", p.About());
        }

        [TestMethod]
        public void USCointIsAICoin()
        {
            //Arrange
            
            //Act 
            
            //Assert
            Assert.IsInstanceOfType(p, typeof(ICoin));
        }

        [TestMethod]
        public void USCointIsAUSCoin()
        {
            //Arrange
            
            //Act 
            
            //Assert
            Assert.IsInstanceOfType(p, typeof(USCoin));
        }


        [TestMethod]
        public void GetUSCoinList()
        {
            //Arrange
            var uscoins = USCoin.GetUSCoinList();
            //Act 
            List<Coin> expectedList = new List<Coin>()
            {
                new DollarCoin(),
                new HalfDollar(),
                new Quarter(),
                new Dime(),
                new Nickel(),
                new Penny(),
            };

            //Assert
            Assert.AreEqual(expectedList.Count, uscoins.Count);
            foreach (Coin coin in expectedList)
            {
                int index = expectedList.IndexOf(coin);
                Assert.AreEqual(expectedList[index].Name,
                    uscoins[index].Name
                    );
                Assert.AreEqual(expectedList[index].MonetaryValue,
                    uscoins[index].MonetaryValue
                    );
            }
        }

    }
}
