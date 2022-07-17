using Prog;
namespace tests;

public class ProductPriceCalculatorShould
{
    private ProductPriceCalculator _calculator = new ProductPriceCalculator();
    [Theory]
    [InlineData(20.25, 24.30, 0.20)]
    [InlineData(20.25, 24.50, 0.21)]
    public void CalculatePriceAfterTax(double priceBeforeTax, double priceAfterTax, double taxRate)
    {
        var product = new Product()
        {
            Price = priceBeforeTax
        };
        _calculator.TaxPercentage = taxRate;
        Assert.Equal(_calculator.PriceAfterTax(product), priceAfterTax);
    }

    [Theory]
    [InlineData(20.25, 4.05, 0.20)]
    [InlineData(20.25, 4.25, 0.21)]
    public void CalculateTaxAmount(double price, double taxAmount, double taxRate)
    {
        var product = new Product()
        {
            Price = price
        };
        _calculator.TaxPercentage = taxRate;
        Assert.Equal(_calculator.TaxAmount(product), taxAmount);
    }

    [Theory]
    [InlineData(20.25, 16.20, 0.20)]
    public void CalculatePriceAfterDiscount(double priceBeforeDiscount, double priceAfterDiscount, double discountRate)
    {
        var product = new Product()
        {
            Price = priceBeforeDiscount
        };
        _calculator.DiscountPercentage = discountRate;
        Assert.Equal(_calculator.PriceAfterDiscount(product), priceAfterDiscount);
    }

    [Theory]
    [InlineData(20.25, 4.05, 0.20)]
    [InlineData(20.25, 4.25, 0.21)]
    public void CalculateDiscountAmount(double price, double discountAmount, double discountRate)
    {
        var product = new Product()
        {
            Price = price
        };
        _calculator.DiscountPercentage = discountRate;
        Assert.Equal(_calculator.DiscountAmount(product), discountAmount);
    }

    [Theory]
    [InlineData(20.25, 21.26, 0.20, 0.15)]
    public void CalculatePriceAfterTaxAndDiscount(double priceBefore, double priceAfter, double taxRate, double discountRate)
    {
        var product = new Product()
        {
            Price = priceBefore
        };
        _calculator.TaxPercentage= taxRate;
        _calculator.DiscountPercentage = discountRate;
        Assert.Equal(_calculator.PriceAfterTaxAndDiscount(product), priceAfter);
    }

}