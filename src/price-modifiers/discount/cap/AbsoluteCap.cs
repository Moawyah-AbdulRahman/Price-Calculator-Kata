namespace Prog
{
    public class AbsoluteCap : Cap
    {
        private readonly double _value;

        public AbsoluteCap(CompositeModifier modifier, double value) : base(modifier)
        {
            if (value < 0)
                throw new ArgumentException("AbsoluteCap's value cannot be negative.");
            this._value = value;
        }

        public override double GetAmount(Product product)
        {
            return Math.Max(_modifier.GetAmount(product), -_value);
        }
    }
}