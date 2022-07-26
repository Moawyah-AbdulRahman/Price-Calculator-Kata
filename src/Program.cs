namespace Prog
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Case 1: additive");
            PriceModifier modifier = new AtomicModifier(
                new SpecialDiscount(12345, 0.07),
                new Tax(0.21),
                new UniversalDiscount(0.15),
                new PercentExpense("Packaging", 0.01),
                new AbsoluteExpense("Transport", 2.2)
            );
            ProductReporter reporter = new ConsoleProductReporter(modifier);
            var product = new Product(reporter, "The little prince", 12345, 20.25);

            System.Console.WriteLine("Case 2: multiplicative");
            var otherModifier = new AtomicModifier(
                new SequentialModifier(
                    new UniversalDiscount(0.15),
                    new SpecialDiscount(12345, 0.07)
                ),
                new Tax(0.21),
                new PercentExpense("Packaging", 0.01),
                new AbsoluteExpense("Transport", 2.2)
            );
            reporter.SetPriceModifyer(otherModifier);
        }
    }
}