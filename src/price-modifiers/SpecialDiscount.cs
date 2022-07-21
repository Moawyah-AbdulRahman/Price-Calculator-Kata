namespace Prog
{
    public class SpecialDiscount : IDiscount
    {
        private readonly uint _upc;
        private readonly double _discountRate;
        public SpecialDiscount(uint upc, double discountRate)
        {
            if (discountRate <= 0 || discountRate >= 1)
                throw new ArgumentException("Discount Rate must be between 0 and 1");
            _upc = upc;
            _discountRate = discountRate;
        }
        public double GetAmount(Product product)
        {
            return product.UPC == _upc ? -product.BasePrice * _discountRate : 0.0;
        }
    }
}