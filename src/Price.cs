namespace Prog
{
    public partial class Price : IComparable<Price>
    {
        public Price(double value) : this(value, "USD") { }
        public Price(double value, string currency)
        {
            if (currency is null)
                throw new NullReferenceException("Price's currency cannot be null");
            if (currency.Length != 3 || currency.Any(c => !char.IsLetter(c)))
                throw new ArgumentException("Currency should be indicated using ISO-3 codes");
            Value = value;
            Currency = currency;
        }

        public double Value { get; }
        public string Currency { get; }

        public override string ToString()
        {
            return Math.Round(Value*100)/100 +" "+ Currency;
        }

    }
}