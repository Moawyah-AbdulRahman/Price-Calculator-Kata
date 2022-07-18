namespace Prog
{
    public class ProductPriceCalculator
    {
        private ProductReporter? _reporter;
        public void SetReporter(ProductReporter value) => _reporter = value;

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

        private (uint UPC, double Percentage) _upcDiscount;
        public (uint UPC, double Percentage) UPCDiscount { get; }
        public void SetUPCDiscount(uint upc, double percentage)
        {
            if (percentage < 0 || percentage >= 1)
            {
                throw new ArgumentException("discount percentage must be between 0 and 1.");
            }
            _upcDiscount = (upc, percentage);
            _reporter?.ReportSingleDiscountByUPC(upc);
        }
        private double _universalDiscountPercentage = 0;
        public double UniversalDiscountPercentage
        {
            get => _universalDiscountPercentage;
            set
            {
                if (value < 0 || value >= 1)
                {
                    throw new ArgumentException("discount percentage must be between 0 and 1.");
                }
                _universalDiscountPercentage = value;
                _reporter?.ReportAllDiscounts();
            }
        }
        private double RoundTwoDecimalPlaces(double value) => Math.Round(value * 100) / 100;
        public double TaxAmount(Product product)
            => RoundTwoDecimalPlaces(TaxPercentage * product.Price);
        public double PriceAfterTax(Product product)
            => RoundTwoDecimalPlaces(product.Price + TaxAmount(product));
        public double UniversalDiscountAmount(Product product)
            => RoundTwoDecimalPlaces(UniversalDiscountPercentage * product.Price);
        public double UPCDiscountAmount(Product product)
            => _upcDiscount.UPC == product.UPC ? RoundTwoDecimalPlaces(_upcDiscount.Percentage * product.Price) : 0.0;
        public double PriceAfterTaxAndDiscounts(Product product)
            => Math.Max(RoundTwoDecimalPlaces( product.Price + TaxAmount(product) - AllDiscountsAmount(product)),0.0);
        public double AllDiscountsAmount(Product product) 
            => UniversalDiscountAmount(product) + UPCDiscountAmount(product);
    }
}