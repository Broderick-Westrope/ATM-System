using System.Linq.Expressions;

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

    public Account? Get(int cardNumber)
    {
        return _accounts.Find(x => x.CompareCardNumber(cardNumber));
    }

    public void Add(Account account)
    {
        _accounts.Add(account);
    }

    public void Delete(int cardNumber)
    {
        var account = _accounts.Find(x => x.CardNumber == cardNumber);
        if (account is not null)
        {
            _accounts.Remove(account);
        }
    }

    public Account? Find(Predicate<Account> predicate)
    {
        return _accounts.Find(predicate);
    }
}