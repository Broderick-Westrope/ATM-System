namespace ATMSystem;

public record Account(int CardNumber, string Name, int Pin)
{
    public bool CompareCardNumber(int cardNumber)
    {
        return cardNumber == CardNumber;
    }

    public bool ComparePin(int pin)
    {
        return pin == Pin;
    }
}