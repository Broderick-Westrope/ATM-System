namespace ATMSystem;

public class Account : IEquatable<Account>
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

    public bool Equals(Account? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return CardNumber == other.CardNumber && Name == other.Name && Pin == other.Pin;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Account)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CardNumber, Name, Pin);
    }
}