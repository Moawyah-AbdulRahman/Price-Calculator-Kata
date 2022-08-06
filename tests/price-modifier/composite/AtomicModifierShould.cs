using Moq;
using Prog;

namespace tests;

public class AtomicModifierShould
{
    [Theory]
    [InlineData(5.0, 1.0, 2.0, 3.0, -1.0)]
    [InlineData(3.25, 2.0, 1.5, -0.25)]
    public void CalculateAllStaticAmountModifiersAtOnce(double expectedAmount,
        params double[] modificationAmounts)
    {
        //Arrange
        Product product = new Product();
        var mockObjects = new List<PriceModifier>();
        foreach (var amount in modificationAmounts)
        {
            var mock = new Mock<PriceModifier>();
            mock.Setup(m => m.GetAmount(It.IsAny<Product>())).Returns(new Price(amount));
            mockObjects.Add(mock.Object);
        }
        var sut = new AtomicModifier(mockObjects.ToArray());
        //Act
        var actualAmount = sut.GetAmount(product).Value;
        //Assert
        Assert.InRange(actualAmount - expectedAmount, -0.00005, 0.00005);
    }

    [Theory]
    [InlineData(10, 4.0, 0.2, -0.1, 0.3)]
    [InlineData(5, 0.6, 0.22, 0.15, -0.25)]
    public void CalculateAllRateAmountModifiersAtOnce(double price, double expectedAmount,
        params double[] modificationRates)
    {
        //Arrange
        Product product = new Product
        {
            BasePrice = new Price(price),
            CurrentPrice = new Price(price),
        };
        var mockObjects = new List<PriceModifier>();
        foreach (var rate in modificationRates)
        {
            var mock = new Mock<PriceModifier>();
            mock.Setup(m => m.GetAmount(It.IsAny<Product>()))
                .Returns(product.CurrentPrice * rate);
            mockObjects.Add(mock.Object);
        }
        var sut = new AtomicModifier(mockObjects.ToArray());
        //Act
        var actualAmount = sut.GetAmount(product).Value;
        //Assert
        Assert.InRange(actualAmount - expectedAmount, -0.00005, 0.00005);
    }
}