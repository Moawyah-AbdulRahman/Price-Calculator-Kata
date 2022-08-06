using Moq;
using Prog;

namespace tests;

public class SequentialModifierShould
{
    [Theory]
    [InlineData(10, 4.04, 0.2, -0.1, 0.3)]
    [InlineData(5, 0.2613, 0.22, 0.15, -0.25)]
    public void CalculateRateAmountModifiersAtInOrder(double price, double expectedAmount,
        params double[] modificationRates)
    {
        //Arrange
        var runningPrice=new Price(price);
        Product product = new Product
        {
            BasePrice = new Price(price),
            CurrentPrice = new Price(price),
        };
        var mockObjects = new List<PriceModifier>();
        foreach (var rate in modificationRates)
        {
            var mock = new Mock<PriceModifier>();
            mock.Setup(m => m.GetAmount(product))
                .Returns(runningPrice*rate);
            runningPrice += runningPrice*rate;
            mockObjects.Add(mock.Object);
        }
        var sut = new SequentialModifier(mockObjects.ToArray());
        //Act
        var actualAmount = sut.GetAmount(product).Value;
        //Assert
        Assert.InRange(actualAmount - expectedAmount, -0.00005, 0.00005);
    }

}