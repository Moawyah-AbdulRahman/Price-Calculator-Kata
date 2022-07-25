namespace Prog
{
    public class PercentExpense : Expense
    {
        private readonly double _rate;

        public PercentExpense(string discription, double rate) : base(discription)
        {
            if(rate<0)
                throw new ArgumentException("Percent expense cannot be negative");
            _rate = rate;
        }

        public override double GetAmount(Product product)
        {
            return (_rate * product.BasePrice).RoundTwoDecimalPlaces();
        }
    }
}