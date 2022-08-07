namespace Prog;

public class AbsoluteCap : Cap
{
    private readonly Price _value;

    public AbsoluteCap(CompositeModifier modifier, Price value) : base(modifier)
    {
        if (value < 0)
            throw new ArgumentException("AbsoluteCap's value cannot be negative.");
        this._value = value;
    }

    public override Price GetAmount(Product product)
    {
        return PriceExtensions.Max(_modifier.GetAmount(product), -_value);
    }
}