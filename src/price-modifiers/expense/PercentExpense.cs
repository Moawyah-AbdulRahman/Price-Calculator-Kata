namespace Prog
{
    public class PercentExpense : Expense
    {
        private readonly double _rate;

        public PercentExpense(string discription, double rate) : base(discription)
        {
            if (rate < 0)
                throw new ArgumentException("Percent expense cannot be negative");
            _rate = rate;
        }

        public override Price GetAmount(Product product)
        {
            return (product.BasePrice * _rate).RoundTwoDecimalPlaces();
        }
    }
}