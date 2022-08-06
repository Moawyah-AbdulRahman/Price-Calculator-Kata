using Prog;

namespace tests;

public class AbsoluteExpenseShould
{
    [Theory]
    [InlineData(5.2, 5.2)]
    [InlineData(6.8, 6.8)]
    public void CalculateExpenseAmountCorrectly(double expenseAmount, double expected)
    {
        var expense = new AbsoluteExpense("", new Price(expenseAmount));
        var product = new Product();

        var actual = expense.GetAmount(product).Value;

        Assert.InRange(actual - expected, -0.00005, 0.00005);
    }
}