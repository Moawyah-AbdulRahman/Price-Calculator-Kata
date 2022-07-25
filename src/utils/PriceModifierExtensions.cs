namespace Prog
{
    public static class PriceModifierExtensions
    {

        public static double GetDiscountAmount(this PriceModifier priceModifier, Product product)
        {
            GuardAgainstNulls(priceModifier, product);

            if (priceModifier is CompositeModifier)
            {
                return GetDiscountInCompositeModifier((CompositeModifier)priceModifier, product);
            }

            if (priceModifier is Discount)
                return -priceModifier.GetAmount(product);

            return 0.0;
        }

        public static double GetTaxAmount(this PriceModifier priceModifier, Product product)
        {
            GuardAgainstNulls(priceModifier, product);

            if (priceModifier is Tax)
                return priceModifier.GetAmount(product);

            if (priceModifier is not CompositeModifier)
                return 0;

            return ((CompositeModifier)priceModifier)._modifiers.Aggregate(0.0, (s, m) => s + m.GetTaxAmount(product));
        }

        public static IEnumerable<Expense> GetExpenses(this PriceModifier priceModifier)
        {
            GuardAgainstNulls(priceModifier, new Product());
            List<Expense> tbr = new List<Expense>();
            if (priceModifier is not CompositeModifier)
                return tbr;

            foreach (var modifier in ((CompositeModifier)priceModifier)._modifiers)
            {
                if (modifier is Expense)
                    tbr.Add((Expense)modifier);
                if (modifier is CompositeModifier)
                    tbr.AddRange(modifier.GetExpenses());
            }
            return tbr;
        }

        private static void GuardAgainstNulls(PriceModifier priceModifier, Product product)
        {
            if (priceModifier is null)
                throw new ArgumentException("Cannot call GetDiscountAmount on null.");
            if (product is null)
                throw new ArgumentException("Cannot calculate discount amount of null.");
        }

        private static double GetDiscountInCompositeModifier(CompositeModifier priceModifier, Product product)
        {
            double priceBeforeModification = product.CurrentPrice;

            double total = 0.0;
            foreach (var modifier in priceModifier._modifiers)
            {
                if (modifier is Discount)
                    total += -modifier.GetAmount(product);

                if (modifier is CompositeModifier)
                    total += GetDiscountInCompositeModifier((CompositeModifier)modifier, product);

                if (priceModifier is SequentialModifier)
                    modifier.ModifyPrice(product);

            }

            product.CurrentPrice = priceBeforeModification;
            return total;
        }

    }
}