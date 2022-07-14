using Prog;
namespace tests;

public class ProductShould
{
    [Theory]
    [InlineData(20.25, 24.30, 0.20)]
    [InlineData(20.25, 24.50, 0.21)]
    public void CalculatePriceWithTax(double priceBeforeTax, double priceAfterTax, double taxRate)
    {
        var product = new Product()
        {
            Price = priceBeforeTax
        };
        Product.TaxPercentage = taxRate;
        Assert.Equal(product.PriceWithTax, priceAfterTax);
    }
}