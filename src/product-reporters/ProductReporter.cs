namespace Prog
{
    public abstract class ProductReporter
    {

        protected ICollection<Product> _products;
        protected PriceModifier _priceModifier;
        public ProductReporter(PriceModifier priceModifier)
        {
            if (priceModifier is null)
                throw new NullReferenceException("Reporter's priceModifier cannot be null");
            _priceModifier = priceModifier;
            _products = new List<Product>();
        }

        public void Subscribe(Product product)
        {
            _products.Add(product);
            ReportSingleDiscount(product);
        }

        public void SetPriceModifyer(PriceModifier priceModifier)
        {
            if (priceModifier is null)
                throw new NullReferenceException("Reporter's priceModifier cannot be null");
            _priceModifier = priceModifier;
            ReportAllDiscounts();
        }

        protected string GetSingleReport(Product product)
        {
            var discountAmount = _priceModifier.GetDiscountAmount(product).RoundFourDecimalPlaces();
            var taxAmount =_priceModifier.GetTaxAmount(product);
            var priceBeforeModification = product.CurrentPrice;
            product.CurrentPrice = product.BasePrice;
            _priceModifier.ModifyPrice(product);
            var tbr = product.ToString()
                + $"\nFinal Price: {product.CurrentPrice}$\n"
                + (taxAmount > 0 ? $"Tax: {taxAmount}$\n" : "")
                + (discountAmount > 0 ? $"Discount: {discountAmount}$\n" : "");
            foreach(var expense in _priceModifier.GetExpenses())
            {
                tbr += $"{expense.Discription}: {expense.GetAmount(product)}$\n";
            }

            product.CurrentPrice = priceBeforeModification;

            return tbr;
        }

        public abstract void ReportSingleDiscount(Product product);

        public abstract void ReportAllDiscounts();
    }
}