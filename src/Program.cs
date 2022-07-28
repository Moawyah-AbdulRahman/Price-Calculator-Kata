namespace Prog
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Case 1:");
            PriceModifier modifier = new AtomicModifier(
                new PercentCap(
                    new AtomicModifier(
                        new UniversalDiscount(0.15),
                        new SpecialDiscount(12345, 0.07)
                    ), 0.20
                ),
                new Tax(0.21)
            );
            ProductReporter reporter = new ConsoleProductReporter(modifier);
            var product = new Product(reporter, "The little prince", 12345, new Price(20.25));

            System.Console.WriteLine("Case 2:");
            var secondModifier = new AtomicModifier(
                new AbsoluteCap(
                    new AtomicModifier(
                        new UniversalDiscount(0.15),
                        new SpecialDiscount(12345, 0.07)
                    ), new Price(4, product.BasePrice.Currency)
                ),
                new Tax(0.21)
            );
            reporter.SetPriceModifyer(secondModifier);

            System.Console.WriteLine("Case 3:");
            var thirdModifier = new AtomicModifier(
                new PercentCap(
                    new AtomicModifier(
                        new UniversalDiscount(0.15),
                        new SpecialDiscount(12345, 0.07)
                    ), 0.30
                ),
                new Tax(0.21)
            );
            reporter.SetPriceModifyer(thirdModifier);
        }
    }
}