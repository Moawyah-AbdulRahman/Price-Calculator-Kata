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
            BasePrice = priceBeforeTax
        };
        _calculator.TaxPercentage = taxRate;
        Assert.Equal(_calculator.GetPriceAfterTax(product), priceAfterTax);
    }

    [Theory]
    [InlineData(20.25, 4.05, 0.20)]
    [InlineData(20.25, 4.25, 0.21)]
    public void CalculateTaxAmount(double price, double taxAmount, double taxRate)
    {
        var product = new Product()
        {
            BasePrice = price
        };
        _calculator.TaxPercentage = taxRate;
        Assert.Equal(_calculator.GetTaxAmount(product), taxAmount);
    }

    [Theory]
    [InlineData(20.25, 4.05, 0.20)]
    [InlineData(20.25, 4.25, 0.21)]
    public void CalculateUniversalDiscountAmount(double price, double discountAmount, double discountRate)
    {
        var product = new Product()
        {
            BasePrice = price
        };
        _calculator.UniversalDiscountPercentage = discountRate;
        Assert.Equal(_calculator.GetUniversalDiscountAmount(product), discountAmount);
    }

    [Theory]
    [InlineData(20.25, 21.26, 0.20, 0.15)]
    public void CalculatePriceAfterTaxAndUniversalDiscount(double priceBefore, double priceAfter,
    double taxRate, double discountRate)
    {
        var product = new Product()
        {
            BasePrice = priceBefore
        };
        _calculator.TaxPercentage = taxRate;
        _calculator.UniversalDiscountPercentage = discountRate;
        Assert.Equal(_calculator.GetPriceAfterTaxAndDiscounts(product), priceAfter);
    }

    [Theory]
    [InlineData(20.25, 4.05, 123, 123, 0.2)]
    [InlineData(20.25, 0, 331, 133, 0.2)]
    [InlineData(100, 15, 12, 12, 0.15)]
    public void CalculateUPCDiscountAmount(double price, double discountAmount, uint discountUPC,
    uint productUPC, double UPCDiscountPercentage)
    {
        var product = new Product()
        {
            BasePrice = price,
            UPC = productUPC,
        };
        _calculator.SetUPCDiscount(discountUPC, UPCDiscountPercentage);
        Assert.Equal(_calculator.GetUPCDiscountAmount(product), discountAmount);
    }

    [Theory]
    [InlineData(20.25, 19.84, 12345, 12345, 0.2, 0.15, 0.07)]
    [InlineData(20.25, 21.46, 789, 12345, 0.21, 0.15, 0.07)]
    public void CalculatePriceAfterTaxAndAllDiscounts(double priceBefore, double priceAfter, uint discountUPC,
        uint productUPC, double taxPercentage, double universalDiscountPercentage, double UPCDiscountPercentage)
    {
        var product = new Product()
        {
            BasePrice = priceBefore,
            UPC = productUPC,
        };
        _calculator.TaxPercentage = taxPercentage;
        _calculator.UniversalDiscountPercentage = universalDiscountPercentage;
        _calculator.SetUPCDiscount(discountUPC, UPCDiscountPercentage);
        Assert.Equal(_calculator.GetPriceAfterTaxAndDiscounts(product), priceAfter);
    }

    [Theory]
    [InlineData(20.25, 4.46, 12345, 12345, 0.15, 0.07)]
    [InlineData(20.25, 3.04, 789, 12345, 0.15, 0.07)]
    public void CalculateAllDiscountsAmount(double priceBefore, double priceAfter, uint discountUPC,
            uint productUPC, double universalDiscountPercentage, double UPCDiscountPercentage)
    {
        var product = new Product()
        {
            BasePrice = priceBefore,
            UPC = productUPC,
        };
        _calculator.UniversalDiscountPercentage = universalDiscountPercentage;
        _calculator.SetUPCDiscount(discountUPC, UPCDiscountPercentage);
        Assert.Equal(_calculator.GetAllDiscountsAmount(product), priceAfter);
    }

}