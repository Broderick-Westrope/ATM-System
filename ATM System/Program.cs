using System.Diagnostics;
using static System.Int32;

namespace ATM_System;

public class Program
{
    private static int pinLength = 4;
    private static int cardNumLength = 6;
    
    static void Main()
    {
        var accountManager = new AccountManager();

        Console.WriteLine("Are you a returning user? [y/N]");
        var input = Console.ReadLine();
        if (input == "Y" || input == "y")
        {
            accountManager.CreateAccount(GetName(), GetPin());
        }
        else
        {
            accountManager.Login(GetCardNumber(), GetPin());
        }
    }

    static string GetName()
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
                Console.WriteLine(e + " Try again.");
                // throw; 
                continue;
            }

            break;
        }

        return name;
    }

    static int GetCardNumber()
    {
        int cardNum;
        while (true)
        {
            Console.Write("Enter your " + cardNumLength + " digit card number: ");
            var input = Console.ReadLine();
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new Exception("Card number was empty or null.");
                }
                
                if (input.Length != cardNumLength)
                {
                    throw new Exception("Card number was not " + cardNumLength + " digits long.");
                }

                cardNum = Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e + " Try again.");
                // throw; 
                continue;
            }

            break;
        }

        return cardNum;

    }

    static int GetPin()
    {
        int pin;
        while (true)
        {
            Console.Write("Enter your " + pinLength + " digit pin: ");
            var input = Console.ReadLine();
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new Exception("Pin was empty or null.");
                }
                
                if (input.Length != pinLength)
                {
                    throw new Exception("Pin was not " + pinLength + " digits long.");
                }
                
                pin = Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e + " Try again.");
                // throw; 
                continue;
            }

            break;
        }

        return pin;
    }
}