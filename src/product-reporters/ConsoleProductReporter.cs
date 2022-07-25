using System.Linq;

namespace Prog
{
    public class ConsoleProductReporter : ProductReporter
    {
        public ConsoleProductReporter(PriceModifier priceModifier) : base(priceModifier) { }

        public override void ReportAllDiscounts()
        {
            foreach (var product in _products)
            {
                ReportSingleDiscount(product);
            }
        }

        public override void ReportSingleDiscount(Product product)
        {
            Console.WriteLine(GetSingleReport(product));
        }
    }
}