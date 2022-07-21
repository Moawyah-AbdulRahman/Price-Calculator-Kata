namespace Prog
{
    public class UniversalDiscount : IDiscount
    {
        private readonly double _rate;

        public UniversalDiscount(double rate)
        {
            if (rate < 0 || rate >= 1)
                throw new ArgumentException("Discount rate must be between 0 and 1.");
            _rate = rate;
        }

        public double GetAmount(Product product)
        {
            return -(_rate * product.BasePrice).RoundTwoDecimalPlaces();
        }

    }
}