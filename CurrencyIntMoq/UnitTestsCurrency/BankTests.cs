using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency;
using Moq;
using Currency.Bank;
using System.Collections.Generic;
using GSF.Security;

namespace UnitTestsCurrency
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void GetRepoFromBankAccountTest()
        {
            //Arrange
            
            IBank bank;
            ICurrencyRepo repo;
            int testAccountNumber = 1;
            decimal testAccountValue = 100;

            var mockAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockSecurityProvider = new Mock<ISecurityProvider>();

            var mockUser = new Mock<IBankUser>();
            var mockAccount = new Mock<IAccount>();
            //Act
            mockSecurityProvider.Setup(m => m.SecurityProviderType).Equals(SecurityProviderType.SecureEnough);

            mockUser.Setup(u => u.UserName).Equals("testUser");
            mockUser.Setup(u => u.IsValidated).Equals(true);

            mockAccount.Setup(a => a.AccountNumber).Equals(testAccountNumber);
            mockAccount.Setup(a => a.Balance).Equals(testAccountValue);
            mockAccount.Setup(a => a.User).Equals(mockUser);

            

            bank = new Bank(mockAuthenticationManager.Object, mockSecurityProvider.Object);
            bank.Accounts = new List<IAccount>() { mockAccount.Object };

            var account = bank.GetAccount(mockAccount.Object.AccountNumber, mockUser.Object);
            repo = account.GetAccountRepo();
            //Assert
            Assert.AreEqual(repo.TotalValue(), account.Balance);
        }
    }
}
