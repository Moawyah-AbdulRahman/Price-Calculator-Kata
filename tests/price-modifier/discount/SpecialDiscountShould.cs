using Prog;

namespace tests;

public class SpecialDiscountShould
{

    [Theory]
    [InlineData(20.25, 0.2, -4.05)]
    [InlineData(20.25, 0.21, -4.2525)]
    public void CalculateDiscountCorrectly(double price, double discountRate,
        double expectedDiscountAmount)
    {
        var discount = new SpecialDiscount(12345, discountRate);
        var product = new Product();
        product.UPC = 12345;
        product.CurrentPrice = new Price(price);

        var actualdiscountAmount = discount.GetAmount(product).Value;

        Assert.InRange( actualdiscountAmount - expectedDiscountAmount,-0.00005, 0.00005);
    }

    [Theory]
    [InlineData(12345, 12345)]
    [InlineData(123, 456)]
    public void Return0AmountForNonMatchingUPC(uint productUPC, uint discountUPC)
    {
        var discount = new SpecialDiscount(discountUPC, 0.1);
        var product = new Product();
        product.UPC = productUPC;
        product.CurrentPrice = new Price(10);
        var expectedDiscountAmount = productUPC == discountUPC ? -1 : 0;

        var actualdiscountAmount = discount.GetAmount(product).Value;

        Assert.Equal(actualdiscountAmount, expectedDiscountAmount);
    }
}