namespace Prog
{
    public static class Program
    {
        public static Func<Product, string> PriceReport = product =>
        $"Product price reported as ${product.Price} before tax and ${product.PriceWithTax} after {Product.TaxPercentage * 100}% tax.";
        public static void Main(string[] args)
        {
            var product = new Product()
            {
                Name = "The Little Prince",
                UPC = 12345,
                Price = 20.25,
            };
            Console.WriteLine(product);
            Console.WriteLine(PriceReport(product));
            Product.TaxPercentage = 0.21;
            Console.WriteLine(PriceReport(product));
        }
    }
}