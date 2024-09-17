using Currency;
using Currency.US;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestsCurrency
{
    [TestClass]
    public class USBankNoteTests
    {
        USDollarBill dollar;

        public USBankNoteTests()
        {
            dollar = new USDollarBill();
        }

        
        [TestMethod]
        public void USDollatIsAIBankNote()
        {
            //Arrange
            
            //Act 
            
            //Assert
            Assert.IsInstanceOfType(dollar, typeof(IBankNote));
        }

        [TestMethod]
        public void USDollatIsAUSBankNote()
        {
            //Arrange

            //Act 

            //Assert
            Assert.IsInstanceOfType(dollar, typeof(USBankNote));
        }

        
    }
}
