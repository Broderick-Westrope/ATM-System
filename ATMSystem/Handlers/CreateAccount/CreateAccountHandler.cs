using ATMSystem.Repositories;

namespace ATMSystem.Handlers.CreateAccount;

public class CreateAccountHandler
{
    private readonly IAccountRepository _accountRepository;

    public CreateAccountHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Account Handle(CreateAccount command)
    {
        if (command.Pin is < 1000 or > 9999) throw new ArgumentException("Pin is incorrect.");

        var account = new Account(GenerateCardNumber(), command.Name, command.Pin);
        _accountRepository.Add(account);
        return account;
    }

    private static int GenerateCardNumber()
    {
        var rand = new Random();
        var cardNum = rand.Next(100000, 999999);
        return cardNum;
    }
}