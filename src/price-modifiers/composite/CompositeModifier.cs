namespace Prog
{
    public abstract class CompositeModifier : PriceModifier
    {
        public readonly IEnumerable<PriceModifier> _modifiers;

        public CompositeModifier(params PriceModifier[] modifiers)
        {
            if (modifiers == null)
                throw new NullReferenceException("CompositeModifier accepts 0..* modifiers but not null.");
            _modifiers = modifiers;
        }
    }
}