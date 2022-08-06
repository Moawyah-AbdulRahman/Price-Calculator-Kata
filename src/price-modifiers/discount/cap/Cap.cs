namespace Prog;

public abstract class Cap: Discount
{
    protected readonly CompositeModifier _modifier;

    public Cap(CompositeModifier modifier)
    {
        if(modifier is null)
            throw new NullReferenceException("Cap's composite modifier cannot be null.");
        this._modifier = modifier;
        foreach (var mod in modifier._modifiers)
        {
            if(mod is not Discount)
                throw new ArgumentException("Cap's composite modifier must have only discount sub-modifiers.");
        }
    }
}