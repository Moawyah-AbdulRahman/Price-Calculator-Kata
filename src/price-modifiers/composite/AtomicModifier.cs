namespace Prog
{
    public class AtomicModifier : CompositeModifier
    {
        public AtomicModifier(params PriceModifier[] modifiers) : base(modifiers) { }
        public override Price GetAmount(Product product)
        {
            return _modifiers.Aggregate(new Price(0.0), (a, m) => a + m.GetAmount(product));
        }
    }
}