namespace Prog
{
    public class Tax : PriceModifier
    {
        private readonly double _rate;

        public Tax() : this(0.2) { }

        public Tax(double rate)
        {
            if (rate < 0)
                throw new ArgumentException("Tax rate can't be negative.");
            _rate = rate;
        }

        public override Price GetAmount(Product product)
        {
            return (product.CurrentPrice * _rate).RoundFourDecimalPlaces();
        }

    }
}