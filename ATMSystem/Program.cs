using ATMSystem.Handlers.CreateAccount;
using ATMSystem.Repositories;
using static System.Int32;

namespace ATMSystem;

public abstract class Program
{
    private const int PinLength = 4;
    private const int AccountNumLength = 6;

    private static void Main()
    {
        var accountList = new List<Account>();
        var repo = new AccountRepository(accountList);
        var accountManager = new AccountManager(repo);
        var createAccountHandler = new CreateAccountHandler(repo);
        Account? account;

        Console.WriteLine("Are you a returning user? [y/N]");
        var input = Console.ReadLine();

        if (input is "Y" or "y")
        {
            // TODO: write tests for login
            account = Login(accountManager);
        }
        else
        {
            account = createAccountHandler.Handle(new CreateAccount(ReadName(), ReadPin()));
            Console.WriteLine(
                $@"Account created with the following credentials:
	Name: {account.Name}
	Account Number: {account.AccountNumber}
");
        }

        Console.WriteLine(
            @"Would you like to:
	[C]hange Pin
	[W]ithdraw
	[D]eposit
	[V]iew Balance
	[T]ransfer
	[L]og Out
	[Q]uit
");
        input = Console.ReadLine();

        // TODO: add other use cases here

        if (input is "C" or "c")
        {
            Console.WriteLine("Changing Pin:");
            accountManager.ChangePin(account, ReadPin());
        }
        else
        {
            throw new Exception("Unimplemented Functionality.");
        }
    }

    private static Account Login(AccountManager accountManager)
    {
        var account = accountManager.Login(ReadAccountNumber(), ReadPin());
        if (account == null) throw new Exception("Failed to log-in using the provided credentials.");

        Console.WriteLine(
            $@"Successfully logged into the account with the following credentials:
	Name: {account.Name}
	Account Number: {account.AccountNumber}
");
        return account;
    }

    private static string ReadName()
    {
        string name;
        while (true)
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine()!;
            try
            {
                if (string.IsNullOrEmpty(name)) throw new Exception("Pin was empty or null.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e} Try again.");
                continue;
            }

            break;
        }

        return name;
    }

    private static int ReadAccountNumber()
    {
        int accountNum;
        while (true)
        {
            Console.Write($"Enter your {AccountNumLength} digit account number: ");
            var input = Console.ReadLine();
            try
            {
                if (string.IsNullOrEmpty(input)) throw new Exception("Account number was empty or null.");

                if (input.Length != AccountNumLength)
                    throw new Exception($"Account number was not {AccountNumLength} digits long.");

                accountNum = Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e} Try again.");
                continue;
            }

            break;
        }

        return accountNum;
    }

    private static int ReadPin()
    {
        int pin;
        while (true)
        {
            Console.Write($"Enter your {PinLength} digit pin: ");
            var input = Console.ReadLine();
            try
            {
                if (string.IsNullOrEmpty(input)) throw new Exception("Pin was empty or null.");

                if (input.Length != PinLength) throw new Exception($"Pin was not {PinLength} digits long.");

                pin = Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e} Try again.");
                continue;
            }

            break;
        }

        return pin;
    }
}