namespace Prog
{
    public class AbsoluteExpense : Expense
    {
        private readonly Price _value;

        public AbsoluteExpense(string discription, Price value) : base(discription)
        {
            if(value<0)
                throw new ArgumentException("Absolute expense value cannot be negative");
            this._value = value.RoundFourDecimalPlaces();
        }

        public override Price GetAmount(Product product)
        {
            return _value;
        }
    }
}