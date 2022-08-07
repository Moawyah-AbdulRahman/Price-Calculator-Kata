namespace Prog;

public abstract class PriceModifier
{
    public abstract Price GetAmount(Product product);
    public virtual void ModifyPrice(Product product)
    {
        product.CurrentPrice += GetAmount(product);
    }
}