namespace Prog
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            PriceModifier modifier = new CompositeModifier(
             new Tax(0.2),
             new UniversalDiscount(0.15),
             new SpecialDiscount(12345, 0.07)
            );
            ProductReporter case1 = new ConsoleProductReporter(modifier);
            var product = new Product(case1, "The little prince", 12345, 20.25);

            modifier = new CompositeModifier(
                new Tax(0.21),
                new UniversalDiscount(0.15),
                new SpecialDiscount(789, 0.07)
            );
            ProductReporter case2 = new ConsoleProductReporter(modifier);
            case2.Subscribe(product);

        }
    }
}