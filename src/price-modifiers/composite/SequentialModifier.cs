namespace Prog
{
    public class SequentialModifier : CompositeModifier
    {

        public SequentialModifier(params PriceModifier[] modifiers) : base(modifiers) { }

        public override double GetAmount(Product product)
        {
            double priceBeforeModification = product.CurrentPrice;
            double tbr = 0;
            foreach (var modifier in _modifiers)
            {
                tbr += modifier.GetAmount(product);
                modifier.ModifyPrice(product);
            }
            product.CurrentPrice = priceBeforeModification;
            return tbr;
        }
    }
}