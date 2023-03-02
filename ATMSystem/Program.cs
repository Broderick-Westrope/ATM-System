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

        Console.WriteLine("Are you a returning user? [y/N]");
        var input = Console.ReadLine();
        if (input == "Y" || input == "y")
        {
            var result = accountManager.CreateAccount(GetName(), GetPin());
            //TODO: check that the returned string was not null or empty
            Console.WriteLine(result);
        }
        else
        {
            if (!accountManager.Login(GetCardNumber(), GetPin()))
            {  
                throw new Exception("Unable to log-in using the provided credentials.");
            }
        }
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