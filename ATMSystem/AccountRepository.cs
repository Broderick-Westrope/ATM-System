namespace ATMSystem;

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

    public Account Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Add(Account account)
    {
        _accounts.Add(account);
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}