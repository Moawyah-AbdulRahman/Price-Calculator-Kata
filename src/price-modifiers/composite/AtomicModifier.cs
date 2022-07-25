namespace Prog
{
    public class AtomicModifier : CompositeModifier
    {
        public AtomicModifier(params PriceModifier[] modifiers) : base(modifiers) { }
        
        public override double GetAmount(Product product)
        {
            return _modifiers.Aggregate(0.0, (a, m) => a + m.GetAmount(product));
        }

    }
}