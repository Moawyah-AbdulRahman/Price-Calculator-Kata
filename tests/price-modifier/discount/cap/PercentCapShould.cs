using Moq;
using Prog;

namespace tests;

public class PercentCapShould
{
    [Theory]
    [InlineData(0.4, 10.0, 5.0, 4.0)]
    [InlineData(0.6, 10.0, 5.0, 5.0)]
    public void NotReturnDiscountMoreThanCap(double capRate, double price,
        double discountAmount, double expected)
    {
        var product = new Product
        {
            BasePrice = new Price(price),
            CurrentPrice = new Price(price),
        };
        var mockComposite = new Mock<CompositeModifier>();
        mockComposite.Setup(m => m.GetAmount(product)).Returns(new Price(-discountAmount));
        var absoluteCap = new PercentCap(mockComposite.Object, capRate);

        var actual = absoluteCap.GetAmount(product).Value;

        Assert.InRange(actual - -expected, -0.00005, 0.00005);
    }
}