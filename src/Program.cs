namespace Prog
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            PriceModifier modifier = new SequentialModifier(
             new SpecialDiscount(12345, 0.07),
             new AtomicModifier(
                new Tax(0.2),
                new UniversalDiscount(0.15)
             )
            );
            ProductReporter reporter = new ConsoleProductReporter(modifier);
            var product = new Product(reporter, "The little prince", 12345, 20.25);

        }
    }
}