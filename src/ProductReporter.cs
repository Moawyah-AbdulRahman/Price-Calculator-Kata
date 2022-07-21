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

        public void ReportSingleDiscountByUPC(uint upc)
        {
            var product = _products.FirstOrDefault(p => p.UPC == upc);
            if (product == null) return;
            ReportSingleDiscount(product);
        }
        public void ReportSingleDiscount(Product product) => Console.WriteLine(SingleReport(product));
        private string SingleReport(Product product)
            => product.ToString()
            + $"\nFinal Price: {_calculator.PriceAfterTaxAndDiscounts(product)}\n"
            + (_calculator.AllDiscountsAmount(product) > 0 ? 
            $"Total Discount = {_calculator.AllDiscountsAmount(product)}.\n" : "");
    }
}