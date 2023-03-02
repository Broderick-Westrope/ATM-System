using System.Diagnostics;
using static System.Int32;

namespace ATMSystem;

public abstract class Program
{
    private const int PinLength = 4;
    private const int CardNumLength = 6;

    private static void Main()
    {
        var accountManager = new AccountManager();
        int cardNumber;

        Console.WriteLine("Are you a new user? [y/N]");
        var input = Console.ReadLine();
        
        if (input is "Y" or "y")
        {
            cardNumber = GetCardNumber();
            if (!accountManager.Login(cardNumber, GetPin()))
            {
                throw new Exception("Failed to log-in using the provided credentials.");
            }
            Console.WriteLine("Login successful.");
        }
        else
        {
            var name = GetName();
            cardNumber = accountManager.CreateAccount(name, GetPin());
            if (cardNumber is < 100000 or > 999999)
            {
                throw new Exception("The generated card number was not a six digit integer.");
            }
            Console.WriteLine($"Account created with the following credentials:\n\tName: {name}\n\tCard Number: {cardNumber}\n");
        }
        
        Console.WriteLine("Would you like to:\n\t[W]ithdraw\n\t[D]eposit\n\t[C]heck Balance\n\t[T]ransfer\n\t[L]og Out\n\t[Q]uit");
    }

    private static string GetName()
    {
        string name;
        while (true)
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine()!;
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("Pin was empty or null.");
                }
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

    private static int GetCardNumber()
    {
        int cardNum;
        while (true)
        {
            Console.Write($"Enter your {CardNumLength} digit card number: ");
            var input = Console.ReadLine();
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new Exception("Card number was empty or null.");
                }

                if (input.Length != CardNumLength)
                {
                    throw new Exception($"Card number was not {CardNumLength} digits long.");
                }

                cardNum = Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e} Try again.");
                continue;
            }

            break;
        }

        return cardNum;
    }

    private static int GetPin()
    {
        int pin;
        while (true)
        {
            Console.Write($"Enter your {PinLength} digit pin: ");
            var input = Console.ReadLine();
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new Exception("Pin was empty or null.");
                }

                if (input.Length != PinLength)
                {
                    throw new Exception($"Pin was not {PinLength} digits long.");
                }

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