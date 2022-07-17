namespace Prog
{
    public class ProductReporter
    {
        private ICollection<Product> _products;
        private ProductPriceCalculator _calculator;
        public ProductReporter(ProductPriceCalculator calculator)
        {
            _products = new List<Product>();
            _calculator = calculator;
            calculator.SetReporter(this);
            ReportAllDiscounts();
        }
        public void Subscribe(Product product)
        {
            _products.Add(product);
            ReportSingleDiscount(product);
        }

        public void ReportAllDiscounts()
        {
            var reports = from product in _products
                          select SingleReport(product);
            foreach (var report in reports)
            {
                Console.WriteLine(report);
            }
        }

        public void ReportSingleDiscount(Product product) => Console.WriteLine(SingleReport(product));

        private string SingleReport(Product product)
            => product.ToString()
            + $"\nFinal Price: {_calculator.PriceAfterTaxAndDiscount(product)}\n"
            + (_calculator.DiscountPercentage > 0 ? $"Discount = {_calculator.DiscountAmount(product)}.\n" : "");
    }
}