namespace Prog
{
    public class ProductPriceCalculator
    {
        private double _taxPercentage = 0.20;
        public double TaxPercentage
        {
            get => _taxPercentage;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Tax percentage cannot be negative.");
                }
                _taxPercentage = value;
            }
        }

        private double _discountPercentage = 0;
        public double DiscountPercentage
        {
            get => _discountPercentage;
            set
            {
                if (value < 0 || value >= 1)
                {
                    throw new ArgumentException("discount percentage must be between 0 and 1.");
                }
                _discountPercentage = value;
            }
        }
        private double RoundTwoDecimalPlaces(double value) => Math.Round(value * 100) / 100;
        public double TaxAmount(Product product) 
            => RoundTwoDecimalPlaces(TaxPercentage * product.Price); 
        public double PriceAfterTax(Product product) 
            => RoundTwoDecimalPlaces(product.Price + TaxAmount(product)); 
        public double DiscountAmount(Product product) 
            => RoundTwoDecimalPlaces(DiscountPercentage * product.Price);
        public double PriceAfterDiscount(Product product) 
            => RoundTwoDecimalPlaces(product.Price - DiscountAmount(product));
        public double PriceAfterTaxAndDiscount(Product product) 
            => RoundTwoDecimalPlaces(product.Price + TaxAmount(product) - DiscountAmount(product));
    }
}