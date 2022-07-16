namespace Prog
{
    public class Product
    {
        private static double _taxPercentage = 0.20;
        public static double TaxPercentage
        {
            get => _taxPercentage;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Tax percentage cannot be negative.");
                }
                _taxPercentage = value;
            }
        }

        public string? Name { get; set; }

        public uint UPC { get; set; }

        private double _price;
        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("price cannot be negative.");
                }
                _price = Round(value);
            }
        }

        private double Round(double value) => Math.Round(value * 100) / 100;
        public double PriceWithTax { get => Round((1 + TaxPercentage) * Price); }

        public override string ToString()
            => $"Product: Name= {Name}, UPC= {UPC}, Price Before Tax= {Price}, Price After Tax: {PriceWithTax}.";

    }
}