using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Bank
{
    public interface IBank
    {
        ISecurityProvider SecurityProvider { get; }
        IAuthenticationManager AuthenticationManager { get; }

        IAccount Account { get; }
        List<IAccount> Accounts { get; set; }
        IAccount GetAccount(int AccountNumber, IBankUser BankUser);
    }

    public class Bank : IBank
    {

        public ISecurityProvider SecurityProvider { get; }

        public IAuthenticationManager AuthenticationManager { get; }

        public IAccount Account { get; }

        public List<IAccount> Accounts { get; set; }

        public IAccount GetAccount(int AccountNumber, IBankUser User )
        {
            switch (AuthenticationManager.SecurityProvider.SecurityProviderType)
            {
                case SecurityProviderType.SecureEnough:
                case SecurityProviderType.SomeWhatSecure:
                    if (User.IsValidated)
                    {
                        return Accounts.Where(a => a.AccountNumber == AccountNumber).FirstOrDefault();
                    }
                    break;
                default:
                    return Accounts.Where(a => a.AccountNumber == AccountNumber).FirstOrDefault();
            }
            return  Accounts.Where(a => a.AccountNumber == AccountNumber).FirstOrDefault();
        }

        private void ActuallyCheckAuthAgain()
        {
            throw new NotImplementedException();
        }

        public Bank(IAuthenticationManager AuthenticationManager, ISecurityProvider SecurityProvider)
        {
            this.AuthenticationManager = AuthenticationManager;
            this.SecurityProvider = SecurityProvider;
        }

    }

    public interface IAuthenticationManager
    {
        ISecurityProvider SecurityProvider { get; set; }
    }

    public enum SecurityProviderType {  SomeWhatSecure, SecureEnough, VerySecure};

    public interface ISecurityProvider
    {
        SecurityProviderType SecurityProviderType { get; }
    }
}
