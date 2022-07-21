namespace Prog
{
    public class Product
    {
        public Product() { }

        public Product(ProductReporter reporter) : this(reporter, "", 0, 0.0) { }

        public Product(ProductReporter reporter, string name, uint upc, double price)
        {
            if (reporter == null)
                throw new NullReferenceException("You sent a null reporter.");
            Name = name;
            UPC = upc;
            BasePrice = price;
            reporter.Subscribe(this);
        }

        public string? Name { get; set; }

        public uint UPC { get; set; }

        private double _basePrice;
        public double BasePrice
        {
            get => _basePrice;
            set
            {
                if (value < 0)
                    throw new ArgumentException("price cannot be negative.");
                CurrentPrice = _basePrice = value.RoundTwoDecimalPlaces();
            }
        }

        private double _currentPrice;
        public double CurrentPrice
        {
            get => _currentPrice;
            set => _currentPrice = Math.Max(value.RoundTwoDecimalPlaces(), 0.0);
        }

        public override string ToString()
        {
            return $"Product: Name= {Name}, UPC= {UPC}, Price= {BasePrice}.";
        }
    }
}