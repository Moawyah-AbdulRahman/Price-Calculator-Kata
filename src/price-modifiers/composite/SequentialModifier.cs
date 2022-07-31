namespace Prog
{
    public class SequentialModifier : CompositeModifier
    {

        public SequentialModifier(params PriceModifier[] modifiers) : base(modifiers) { }

        public override Price GetAmount(Product product)
        {
            Price priceBeforeModification = product.CurrentPrice;
            Price tbr = new Price(0, product.CurrentPrice.Currency);
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