using ATMSystem.Repositories;

namespace ATMSystem;

public class AccountManager
{
    private readonly IAccountRepository _repo;
    
    public AccountManager(IAccountRepository repo)
    {
        _repo = repo;
    }
    
    internal Account? Login(int cardNumber, int pin)
    {
        var account = _repo.Get(cardNumber);
        if (account == null || account.Pin != pin)
            return null;
        return account;
    }
    
    internal void ChangePin(Account oldAccount, int pin)
    {
        var newAccount = oldAccount with { Pin = pin };
        _repo.Delete(oldAccount);
        _repo.Add(newAccount);
    }
}