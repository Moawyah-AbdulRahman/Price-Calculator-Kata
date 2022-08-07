namespace Prog;

public partial class Price
{
    public Price RoundFourDecimalPlaces()
    {
        return new Price(Math.Round(Value * 10000) / 10000, Currency);
    }
    

    public int CompareTo(Price? other)
    {
        if (other is null)
            throw new NullReferenceException("Cannot compare a price with null");
        return Value.CompareTo(other.Value);
    }

    public static Price operator +(Price a, Price b) => new Price(a.Value + b.Value, a.Currency);
    public static Price operator *(Price a, double b) => new Price(a.Value * b);

    public static bool operator <(Price a, Price b) => a.Value < b.Value;
    public static bool operator >(Price a, Price b) => b < a;
    public static bool operator <(Price a, double b) => a.Value < b;
    public static bool operator >(Price a, double b) => a.Value > b;

    public static Price operator -(Price a) => new Price(-a.Value, a.Currency);

}
public static class PriceExtensions
{
    public static Price Max(params Price[] prices)
    {
        if (prices.Length == 0)
            throw new ArgumentException("");
        return prices.MaxBy(price => price.Value)!;
    }

}