using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency.US;

namespace UnitTestsCurrency
{
    [TestClass]
    public class PennyTests
    {

        Penny p;

        public PennyTests()
        {
            p = new Penny();
        }

        public void PennyConstructor()
        {
            //Arrange
            Penny p, philiPenny;
            //Act 
            p = new Penny();
            philiPenny = new Penny(USCoinMintMark.P);
            //Assert
            Assert.AreEqual("D", p.MintMark); //D is the default mint mark
            Assert.AreEqual(System.DateTime.Now.Year, p.Year); //Current Year is default year

            Assert.AreEqual("P", philiPenny.MintMark);

        }

        [TestMethod]
        public void PennyMonetaryValue()
        {
            //Arrange
            decimal pennyValue = .01M;
            //Go ahead try a double
            //Act 
            p = new Penny();
            //Assert
            Assert.AreEqual(pennyValue, p.MonetaryValue);
        }

        [TestMethod]
        public void PennyAbout()
        {
            //Arrange
            
            double pennyValue = .01f;
            //Act 
            p = new Penny();
            //Assert
            Assert.AreEqual($"US Penny is from {System.DateTime.Now.Year}. It is worth {pennyValue:c}. It was made in Denver", p.About());
        }

        [TestMethod]
        public void PennyPortaitIsNotNull()
        {
            //Assert
            Assert.IsNotNull(p.Portait);
        }

        [TestMethod]
        public void PennyreverseMotifIsNotNull()
        {
            //Assert
            Assert.IsNotNull(p.ReverseMotif);
        }

        [TestMethod]
        public void PennyPortraitDefaultValue()
        {
            //Arrange
            string expectedPennyPortrait;
            //Act
            expectedPennyPortrait = "Abraham Lincoln";
            //Assert
            Assert.AreEqual(expectedPennyPortrait,  p.Portait);
        }

        [TestMethod]
        public void PennyreverseMotifDefaultValue()
        {
            //Arrange
            string expectedPennyReverseMotif;
            //Act
            expectedPennyReverseMotif = "Union shield";
            //Assert
            Assert.AreEqual(expectedPennyReverseMotif   , p.ReverseMotif);
        }
    }
}
