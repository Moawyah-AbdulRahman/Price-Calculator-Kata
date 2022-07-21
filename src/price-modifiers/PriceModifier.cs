namespace Prog
{
    public abstract class PriceModifier
    {
        public abstract double GetAmount(Product product);
        public virtual void ModifyPrice(Product product)
        {
            product.CurrentPrice += GetAmount(product);
        }
    }
}