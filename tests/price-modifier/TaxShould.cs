using Moq;
using Prog;

namespace tests;

public class TaxShould
{

    [Theory]
    [InlineData(20.25, 0.2, 4.05)]
    [InlineData(20.25, 0.21, 4.2525)]
    public void CalculateTaxAmountCorrectly(double price, double taxRate, 
        double expectedTaxAmount)
    {
        var tax = new Tax(taxRate);
        var product = new Product();
        product.CurrentPrice = new Price(price);

        var actualTaxAmount = tax.GetAmount(product).Value;

        Assert.InRange( actualTaxAmount - expectedTaxAmount,-0.00005, 0.00005);
    }
}