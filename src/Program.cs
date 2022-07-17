namespace Prog
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("No Discounts :'( ");
            var calculator = new ProductPriceCalculator();
            var reporter = new ProductReporter(calculator);
            var prod1 = new Product(reporter, "The Little Prince", 12345, 20.25);
            var prod2 = new Product(reporter, "The Big Prince", 54321, 100);
            Console.WriteLine("Discounts Applied :^) ");
            calculator.DiscountPercentage = 0.15;

        }
    }
}