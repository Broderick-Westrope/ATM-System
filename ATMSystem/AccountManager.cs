namespace ATMSystem;

public class AccountManager
{
    internal string CreateAccount(string name, int pin)
    {
        var cardNumber = GenerateCardNumber();

        //TODO: Add new account details to database
        

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