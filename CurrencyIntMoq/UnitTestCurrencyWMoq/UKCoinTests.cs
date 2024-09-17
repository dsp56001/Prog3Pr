using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency.UK;
using Currency;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestsCurrency
{
    [TestClass]
    public class UKCoinTests
    {

        ICoin p;

        public UKCoinTests()
        {
            p = new Pence();
        }


        [TestMethod]
        public void UKCoinPenceConstructor()
        {
            //Arrange
            p = new Pence();
            //Act 

            //Assert
            
            Assert.AreEqual(System.DateTime.Now.Year, p.Year); //Current year is default year

        }

        

        [TestMethod]
        public void UKCoinPenceMonetaryValue()
        {
            //Arrange
            p = new Pence();
            //Act 
            //nothing should have .01;
            //Assert
            Assert.AreEqual(.01, p.MonetaryValue);
        }

        [TestMethod]
        public void UKCoinPenceAbout()
        {
            //Arrange
            p = new Pence();
            //Act 

            //Assert
            Assert.AreEqual("UK Pence is from 2017. It is worth $0.01.", p.About());
        }

        [TestMethod]
        public void UKCoinSerialize()
        {
            //Arrange
            List<ICoin> coinList, readCoinList;
            coinList = getCoinList();
            //Act 

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, coinList);
            stream.Position = 0;
            readCoinList = (List<ICoin>)formatter.Deserialize(stream);
            //Assert
            foreach (Coin c in coinList)
            {
                Assert.IsTrue(c is ISerializable);
            }
            CollectionAssert.AreEqual(coinList, readCoinList);

        }

        private List<ICoin> getCoinList()
        {
            ICoin n = new FivePence();
            ICoin pen = new Pence();
            ICoin q = new TwentyPence();
            ICoin d = new TenPence();
            ICoin hd = new FiftyPence();
            ICoin doll = new Pound();

            List<ICoin> coinList = new List<ICoin>
            {
                { doll },
                { hd },
                { q },
                { d },
                { n },
                { pen }
            };
            return coinList.OrderByDescending(c => c.MonetaryValue).ToList();

        }
    }
}
