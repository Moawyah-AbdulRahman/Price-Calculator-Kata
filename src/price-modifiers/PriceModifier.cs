namespace Prog
{
    public interface PriceModifier
    {
        double GetAmount(Product product);
        virtual void ModifyPrice(Product product)
        {
            product.CurrentPrice += GetAmount(product);
        }
    }
}