using System.Reflection;
using Moq;
using Moq.Protected;
using Prog;

namespace tests;

public class ProductReporterShould
{
    private Mock<PriceModifier> _mockModifier;
    private Mock<ProductReporter> _mockReporter;

    public ProductReporterShould()
    {
        _mockModifier = new Mock<PriceModifier>();
        _mockReporter = new Mock<ProductReporter>(_mockModifier.Object);
    }

    [Fact]
    public void ReportAllWhenModifierChanges()
    {
        _mockReporter.Object.SetPriceModifier(_mockModifier.Object);

        _mockReporter.Verify(r => r.ReportAll());
    }
}