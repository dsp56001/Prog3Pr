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
        Nickel n;

        public NickelTests()
        {
            n = new Nickel();
        }

        public void NickelConstructor()
        {
            //Arrange
            Nickel n, philiNickel;
            //Act 
            n = new Nickel();
            philiNickel = new Nickel(USCoinMintMark.P);
            //Assert
            Assert.AreEqual("D", n.MintMark); //D is the default mint mark
            Assert.AreEqual(System.DateTime.Now.Year, n.Year); //Current Year is default year

            Assert.AreEqual("P", philiNickel.MintMark);

        }

        [TestMethod]
        public void NickelMonetaryValue()
        {
            //Arrange
            Nickel n;
            //Act 
            n = new Nickel();
            //Assert
            Assert.AreEqual(.05M, n.MonetaryValue);
        }

        [TestMethod]
        public void NickelAbout()
        {
            //Arrange
            Nickel n;
            //Act 
            n = new Nickel();
            //Assert
            Assert.AreEqual($"US Nickel is from {System.DateTime.Now.Year}. It is worth $0.05. It was made in Denver", n.About());
        }

        [TestMethod]
        public void NickelPortaitIsNotNull()
        {
            //Assert
            Assert.IsNotNull(n.Portait);
        }

        [TestMethod]
        public void NickelReverseMotifIsNotNull()
        {
            //Assert
            Assert.IsNotNull(n.ReverseMotif);
        }

        [TestMethod]
        public void NickelPortraitDefaultValue()
        {
            //Arrange
            string expectedPortrait;
            //Act
            expectedPortrait = "Thomas Jefferson";
            
            //Assert
            Assert.AreEqual(expectedPortrait, n.Portait);
        }

        [TestMethod]
        public void NickelreverseMotifDefaultValue()
        {
            //Arrange
            string expectedReverseMotif;
            //Act
            expectedReverseMotif = "Monticello";
            //Assert
            Assert.AreEqual(expectedReverseMotif, n.ReverseMotif);
        }


    }

   
}
