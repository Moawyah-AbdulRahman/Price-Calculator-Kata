using Prog;

namespace tests;

public class UniversalDiscountShould
{
    [Theory]
    [InlineData(20.25, 0.2, -4.05)]
    [InlineData(20.25, 0.21, -4.2525)]
    public void CalculateDiscountAmountCorrectly(double price, double discountRate, 
        double expectedDiscountAmount)
    {
        var discount = new UniversalDiscount(discountRate);
        var product = new Product();
        product.CurrentPrice = new Price(price);

        var actualdiscountAmount = discount.GetAmount(product).Value;

        Assert.InRange( actualdiscountAmount - expectedDiscountAmount,-0.00005, 0.00005);
    }
}