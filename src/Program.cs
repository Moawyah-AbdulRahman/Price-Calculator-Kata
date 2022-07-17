namespace Prog
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var calculator=new ProductPriceCalculator();
            var product = new Product()
            {
                Name = "The Little Prince",
                UPC = 12345,
                Price = 20.25,
            };
            calculator.DiscountPercentage = 0.15;
            Console.WriteLine(product);
            Console.WriteLine($"Tax={calculator.TaxPercentage*100}%, Discount={calculator.DiscountPercentage*100}%");
            Console.WriteLine($"Tax amount=${calculator.TaxAmount(product)}, Discount amount=${calculator.DiscountAmount(product)}");
            Console.WriteLine($"Price before=${product.Price}, Price after=${calculator.PriceAfterTaxAndDiscount(product)}.");
        }
    }
}