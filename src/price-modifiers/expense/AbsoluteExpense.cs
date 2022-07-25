namespace Prog
{
    public class AbsoluteExpense : Expense
    {
        private readonly double _value;

        public AbsoluteExpense(string discription, double value) : base(discription)
        {
            if(value<0)
                throw new ArgumentException("Absolute expense value cannot be negative");
            this._value = value.RoundTwoDecimalPlaces();
        }

        public override double GetAmount(Product product)
        {
            return _value;
        }
    }
}