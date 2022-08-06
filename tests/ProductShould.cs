using Moq;
using Prog;

namespace tests;

public class ProductShould
{
    private Mock<PriceModifier> _mockModifier;
    private Mock<ProductReporter> _mockReporter;
    private Product _product;

    public ProductShould()
    {
        _mockModifier = new Mock<PriceModifier>();
        _mockReporter = new Mock<ProductReporter>(_mockModifier.Object);
        _product = new Product(_mockReporter.Object);
    }

    [Fact]
    public void SubsicribeToReporter()
    {
        _mockReporter.Verify(r => r.Subscribe(It.IsAny<Product>()));
    }

    
}
