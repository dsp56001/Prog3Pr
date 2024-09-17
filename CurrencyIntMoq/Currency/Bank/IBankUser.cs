namespace Currency.Bank
{
    public interface IBankUser
    {
        string UserName { get; }
        bool IsValidated { get; }
    }
}