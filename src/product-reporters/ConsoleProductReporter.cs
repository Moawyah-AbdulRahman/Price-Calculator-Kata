using System.Linq;

namespace Prog
{
    public class ConsoleProductReporter : ProductReporter
    {
        public ConsoleProductReporter(PriceModifier priceModifier) : base(priceModifier) { }

        public override void ReportAll()
        {
            foreach (var product in _products)
            {
                ReportSingle(product);
            }
        }

        public override void ReportSingle(Product product)
        {
            Console.WriteLine(GetSingleReport(product));
        }
    }
}