namespace ATMSystem;

public class Account
{
    private int CardNumber { get; }

    private string Name { get; }

    private int Pin { get; }

    public Account(int cardNumber, string name, int pin)
    {
        CardNumber = cardNumber;
        Name = name;
        Pin = pin;
    }

    public bool CompareCardNumber(int cardNumber)
    {
        return cardNumber == CardNumber;
    }

    public bool ComparePin(int pin)
    {
        return pin == Pin;
    }
}