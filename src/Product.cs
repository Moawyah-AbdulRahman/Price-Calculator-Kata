namespace Prog;

public class Product
{
    public Product()
    {
        Name = "";
        UPC = 0;
        _basePrice = _currentPrice = new Price();
    }
    public Product(ProductReporter reporter) : this(reporter, "", 0, new Price()) { }
    public Product(ProductReporter reporter, string name, uint upc, Price price)
    {
        if (reporter == null)
            throw new NullReferenceException("You sent a null reporter to a product.");
        Name = name;
        UPC = upc;
        CurrentPrice = _basePrice = _currentPrice = price;
        reporter.Subscribe(this);
    }

    public string? Name { get; set; }

    public uint UPC { get; set; }

    private Price _basePrice;
    public Price BasePrice
    {
        get => _basePrice;
        set
        {
            if (value is null)
                throw new NullReferenceException("Product's price cannot be null.");
            CurrentPrice = _basePrice = value.RoundFourDecimalPlaces();
        }
    }

    private Price _currentPrice;
    public Price CurrentPrice
    {
        get => _currentPrice;
        set => _currentPrice = PriceExtensions.Max(value.RoundFourDecimalPlaces(), new Price(0.0, value.Currency));
    }

    public override string ToString()
    {
        return $"Product: Name= {Name}, UPC= {UPC}, Price= {BasePrice}.";
    }
}