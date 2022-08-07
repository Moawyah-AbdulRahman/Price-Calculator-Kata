using Moq;
using Prog;

namespace tests;

public class AbsoluteCapShould
{
    [Theory]
    [InlineData(4.0, 5.0, 4.0)]
    [InlineData(6.0, 5.0, 5.0)]
    public void NotReturnDiscountMoreThanCap(double cap, double discountAmount, 
        double expected)
    {
        var product = new Product();
        var mockComposite = new Mock<CompositeModifier>();
        mockComposite.Setup(m => m.GetAmount(product)).Returns(new Price(-discountAmount));
        var absoluteCap = new AbsoluteCap(mockComposite.Object, new Price(cap));

        var actual = absoluteCap.GetAmount(product).Value;

        Assert.InRange(actual - -expected, -0.00005, 0.00005);
    }
}