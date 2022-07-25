namespace Prog
{
    public abstract class Expense : PriceModifier
    {
        public readonly string Discription;

        protected Expense(string discription)
        {
            if(discription is null)
                throw new NullReferenceException("Discription of an expense cannot be null.");
            Discription = discription;
        }
    }
}