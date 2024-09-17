using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency;
using Moq;

namespace UnitTestsCurrency
{
    [TestClass]
    public class BankNoteTest
    {
        [TestMethod]
        public void USBankNoteTest()
        {
            //Arrange
            var mockUSBankNote = new Mock<IBankNote>();

            var mockUSBankRepo = new Mock<ICurrencyRepo>();


            //Act
            mockUSBankNote.Setup(bn => bn.Name).Equals("One Dollar BankNote");
            mockUSBankNote.Setup(bn => bn.MonetaryValue).Equals(1.0);
            mockUSBankNote.Setup(bn => bn.Year).Equals(System.DateTime.Now.Year);
            mockUSBankNote.Setup(bn => bn.About()).Returns("Fake US Dollar");

            var change = new Mock<ICurrencyRepo>();
            change.Setup(c => c.TotalValue().Equals(1.0));

            mockUSBankRepo.Setup(r => r.MakeChange(
                It.IsAny<Double>())).Returns(change.Object);




            //Assert
            Assert.AreEqual("1.0", mockUSBankNote.Object.MonetaryValue);
            Assert.AreEqual(mockUSBankRepo.Object.MakeChange(1.0), change.Object.TotalValue());
        }
    }
}
