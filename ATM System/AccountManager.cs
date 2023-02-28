namespace ATM_System;

public class AccountManager
{
    internal void CreateAccount(string name, int pin)
    {
    }

    internal void Login(int cardNumber, int pin)
    {
    }

    int GenerateCardNumber()
    {
        Random rand = new Random();
        int cardNum = rand.Next(100000, 999999);
        return cardNum;
    }
}