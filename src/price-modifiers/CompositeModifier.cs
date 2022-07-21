namespace Prog
{
    public class CompositeModifier : PriceModifier
    {
        public readonly IEnumerable<PriceModifier> _modifiers;

        public CompositeModifier(params PriceModifier[] modifiers)
        {
            if(modifiers==null)
                throw new NullReferenceException("CompositeModifier accepts 0..* modifiers but not null.");
            _modifiers = modifiers;
        }

        public override double GetAmount(Product product)
        {
            return _modifiers.Aggregate(0.0, (a, m) => a + m.GetAmount(product));
        }

    }
}