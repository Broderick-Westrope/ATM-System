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
        //? What is the best approach to dealing with this null value?
        return _accounts.Find(x => x.CompareCardNumber(cardNumber));
    }

    public void Add(Account account)
    {
        _accounts.Add(account);
    }

    public void Delete(int cardNumber)
    {
        //? Is there a better list method for removing an object that matches a predicate? The same null value question as Get().
        _accounts.Remove(_accounts.Find(x => x.CompareCardNumber(cardNumber)));
    }

    //? Thoughts on this predicate function? Wanted to give it a shot and see where i could improve.
    public Account? Find(Predicate<Account> predicate)
    {
        return _accounts.Find(predicate);
    }
}