namespace Prog
{
    public class Product
    {
        public string? Name { get; set; }
        public uint UPC { get; set; }
        private double RoundTwoDecimalPlaces(double value) => Math.Round(value * 100) / 100;
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
                _price = RoundTwoDecimalPlaces(value);
            }
        }

        public override string ToString()
            => $"Product: Name= {Name}, UPC= {UPC}, Price= {Price}.";

    }
}