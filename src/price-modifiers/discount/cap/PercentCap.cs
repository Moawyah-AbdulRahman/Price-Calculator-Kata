namespace Prog
{
    public class PercentCap : Cap
    {
        private readonly double _rate;

        public PercentCap(CompositeModifier modifier, double rate) : base(modifier)
        {
            if(rate<0)
                throw new ArgumentException("PercentCap's rate cannot be negative."); 
            this._rate = rate;
        }

        public override Price GetAmount(Product product)
        {
            return PriceExtensions.Max(_modifier.GetAmount(product), -(product.CurrentPrice*_rate).RoundFourDecimalPlaces());
        }
    }
}