namespace ATMSystem;

public class Account : IEquatable<Account>
{
    public int CardNumber { get; }

    public string Name { get; }

    public int Pin { get; }

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
        return obj.GetType() == GetType() && Equals((Account)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CardNumber, Name, Pin);
    }
}