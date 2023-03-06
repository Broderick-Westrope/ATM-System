namespace ATMSystem;

public class AccountManager
{
    private readonly IAccountRepository _repo;
    
    public AccountManager(IAccountRepository repo)
    {
        _repo = repo;
    }

    internal Account CreateAccount(string name, int pin)
    {
        var account = new Account(GenerateCardNumber(), name, pin);
        _repo.Add(account);

        return account;
    }

    internal Account? Login(int cardNumber, int pin)
    {
        var account = _repo.Get(cardNumber);
        if (account == null || !account.ComparePin(pin))
            return null;
        return account;
    }

    private static int GenerateCardNumber()
    {
        var rand = new Random();
        var cardNum = rand.Next(100000, 999999);
        return cardNum;
    }

    internal void ChangePin(Account oldAccount, int pin)
    {
        var newAccount = oldAccount with { Pin = pin };
        _repo.Delete(oldAccount.CardNumber);
        _repo.Add(newAccount);
    }
}