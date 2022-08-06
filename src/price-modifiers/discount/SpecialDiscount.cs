namespace Prog;

public class SpecialDiscount : Discount
{
    private readonly uint _upc;
    private readonly double _discountRate;
    public SpecialDiscount(uint upc, double discountRate)
    {
        if (discountRate <= 0 || discountRate >= 1)
            throw new ArgumentException("Discount Rate must be between 0 and 1");
        _upc = upc;
        _discountRate = discountRate;
    }
    public override Price GetAmount(Product product)
    {
        return product.UPC == _upc ?
            -product.CurrentPrice * _discountRate :
            new Price(0.0, product.CurrentPrice.Currency);
    }
}