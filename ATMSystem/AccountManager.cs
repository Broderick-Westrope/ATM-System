namespace ATMSystem;

public class AccountManager
{
    private AccountRepository repo;

    //? Is it right to put this declaration in this scope? Is there any way to limit access to only the repo?
    private List<Account> accounts = new();


    public AccountManager()
    {
        repo = new AccountRepository(accounts);
    }

    internal string CreateAccount(string name, int pin)
    {
        var cardNumber = GenerateCardNumber();
        repo.Add(new Account(cardNumber, name, pin));

        return
            $"Your account has been created with the following credentials.\nName: {name}\nCard Number: {cardNumber}\nPin: {pin}";
    }

    internal bool Login(int cardNumber, int pin)
    {
        //TODO check login details against database

        return true;
    }

    private static int GenerateCardNumber()
    {
        var rand = new Random();
        var cardNum = rand.Next(100000, 999999);
        return cardNum;
    }
}