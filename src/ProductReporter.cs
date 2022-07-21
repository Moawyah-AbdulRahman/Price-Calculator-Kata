using System.Linq;

namespace Prog
{
    public class ProductReporter
    {
        private ICollection<Product> _products;
        private PriceModifier _priceModifier;
        public ProductReporter(PriceModifier priceModifier)
        {
            if (priceModifier == null)
                throw new NullReferenceException("Price modifier cannot be null.");
            _priceModifier = priceModifier;
            _products = new List<Product>();
        }
        public void Subscribe(Product product)
        {
            _products.Add(product);
            ReportSingleDiscount(product);
        }

        public void ReportAllDiscounts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine(GetSingleReport(product));
            }
        }

        public void ReportSingleDiscount(Product product)
        {
            Console.WriteLine(GetSingleReport(product));
        }

        private string GetSingleReport(Product product)
        {
            return product.ToString() + $"\nFinal Price: {product.CurrentPrice}\n";
        }

        private double GetDiscountAmount(Product product)
        {
            if(_priceModifier is CompositeModifier)
            {
                var x= (_priceModifier as CompositeModifier)!._modifiers;
            }
            return 0.0;
        }
    }
}