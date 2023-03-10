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

        var account = new Account(GenerateAccountNumber(), command.Name, command.Pin);
        _accountRepository.Add(account);
        return account;
    }

    private static int GenerateAccountNumber()
    {
        var rand = new Random();
        var accountNum = rand.Next(100000, 999999);
        return accountNum;
    }
}