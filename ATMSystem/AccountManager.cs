namespace ATMSystem;

public class AccountManager
{
    private AccountRepository repo;

    //? Is it right to put this declaration in this scope? Is there any way to limit access to only the repo?
    private List<Account> _accounts = new();


    public AccountManager()
    {
        repo = new AccountRepository(_accounts);
    }

    internal int CreateAccount(string name, int pin)
    {
        var cardNumber = GenerateCardNumber();
        repo.Add(new Account(cardNumber, name, pin));

        return cardNumber;
    }

    internal bool Login(int cardNumber, int pin)
    {
        var account = repo.Get(cardNumber);
        return account != null && account.ComparePin(pin);
    }

    private static int GenerateCardNumber()
    {
        var rand = new Random();
        var cardNum = rand.Next(100000, 999999);
        return cardNum;
    }
}