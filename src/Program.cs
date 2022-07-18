namespace Prog
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var calculator = new ProductPriceCalculator()
            {
                UniversalDiscountPercentage = 0.15,
                TaxPercentage = 0.2,
            };
            calculator.SetUPCDiscount(12345, 0.07);
            var reporter = new ProductReporter(calculator);
            var prod1 = new Product(reporter, "The Little Prince", 12345, 20.25);
            var prod2 = new Product(reporter, "The Big Prince", 789, 20.25);

        }
    }
}