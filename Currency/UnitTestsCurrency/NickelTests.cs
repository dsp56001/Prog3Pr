using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency.US;
using Currency;
using System.Collections.Generic;

namespace UnitTestsCurrency
{
    [TestClass]
    public class NickelTests
    {
        

        public void NickelConstructor()
        {
            //Arrange
            Nickel p, philiNickel;
            //Act 
            p = new Nickel();
            philiNickel = new Nickel(USCoinMintMark.P);
            //Assert
            Assert.AreEqual("D", p.MintMark); //D is the default mint mark
            Assert.AreEqual(System.DateTime.Now.Year, p.Year); //Current Year is default year

            Assert.AreEqual("P", philiNickel.MintMark);

        }

        [TestMethod]
        public void NickelMonetaryValue()
        {
            //Arrange
            Nickel p;
            //Act 
            p = new Nickel();
            //Assert
            Assert.AreEqual(.05M, p.MonetaryValue);
        }

        [TestMethod]
        public void NickelAbout()
        {
            //Arrange
            Nickel p;
            //Act 
            p = new Nickel();
            //Assert
            Assert.AreEqual($"US Nickel is from {System.DateTime.Now.Year}. It is worth $0.05. It was made in Denver", p.About());
        }


    }

   
}
