using Currency;
using Currency.US;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestsCurrency
{
    [TestClass]
    public class CoinTests
    {
        [TestMethod]
        [ExpectedException(typeof(MissingMethodException), "Cannot create an abstract class.")] //Since it's abstact it doesn't have constructor it will throw a MissingMethodException 
        public void CointIsAbstract_Throws()
        {
            var ae = Activator.CreateInstance<Coin>(); //Will throw an exception
        }

        [TestMethod]
        public void CointIsAICoin()
        {
            //Arrange
            ICoin coin = new Penny(); //Do I need an subclass to test this?
            //Act 

            //Assert
            Assert.IsInstanceOfType(coin, typeof(ICoin));
        }

    }
}
