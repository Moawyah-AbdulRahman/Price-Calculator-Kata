using Prog;

namespace tests;

public class PercentExpenseShould
{
    [Theory]
    [InlineData(20.25, 0.2, 4.05)]
    [InlineData(20.25, 0.21, 4.2525)]
    public void CalculateExpenseAmountCorrectly(double price, double expenseRate, 
        double expectedExpenseAmount)
    {
        var expense = new PercentExpense("", expenseRate);
        var product = new Product();
        product.CurrentPrice = new Price(price);

        var actualExpenseAmount = expense.GetAmount(product).Value;

        Assert.InRange( actualExpenseAmount - expectedExpenseAmount,-0.00005, 0.00005);
    }
}