using Currency;
using Currency.US;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestsCurrency
{
    [TestClass]
    public class BankNoteTests
    {
        [TestMethod]
        [ExpectedException(typeof(MissingMethodException), "Cannot create an abstract class.")] //Since it's abstact it doesn't have constructor it will throw a MissingMethodException 
        public void CointIsAbstract_Throws()
        {
            var ae = Activator.CreateInstance<BankNote>(); //Will throw an exception
        }

        [TestMethod]
        public void BankNoteIsAIBankNote()
        {
            //Arrange
            BankNote bn = new USDollarBill(); //Do I need an subclass to test this?
                                               //Act 

            //Assert
            Assert.IsInstanceOfType(bn, typeof(IBankNote));
        }
    }

    
}
