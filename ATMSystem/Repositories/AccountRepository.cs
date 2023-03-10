namespace ATMSystem.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly List<Account> _accounts;

    public AccountRepository(List<Account> accounts)
    {
        _accounts = accounts;
    }

    public List<Account> GetAll()
    {
        return _accounts;
    }

    public Account? Get(int accountNumber)
    {
        return _accounts.Find(x => x.AccountNumber == accountNumber);
    }

    public void Add(Account account)
    {
        _accounts.Add(account);
    }

    public void Delete(Account account)
    {
        _accounts.Remove(account);
    }

    public Account? Find(Predicate<Account> predicate)
    {
        return _accounts.Find(predicate);
    }
}