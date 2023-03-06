namespace ATMSystem;

public class AccountManager
{
    private readonly IAccountRepository _repo;
    
    public AccountManager(IAccountRepository repo)
    {
        _repo = repo;
    }

    internal int CreateAccount(string name, int pin)
    {
        var cardNumber = GenerateCardNumber();
        _repo.Add(new Account(cardNumber, name, pin));

        return cardNumber;
    }

    internal bool Login(int cardNumber, int pin)
    {
        var account = _repo.Get(cardNumber);
        return account != null && account.ComparePin(pin);
    }

    private static int GenerateCardNumber()
    {
        var rand = new Random();
        var cardNum = rand.Next(100000, 999999);
        return cardNum;
    }
}