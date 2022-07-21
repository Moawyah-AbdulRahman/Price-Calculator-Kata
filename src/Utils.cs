namespace Prog
{
    public static class Utils
    {
        public static double RoundTwoDecimalPlaces(this double value)
        {
            return Math.Round(value * 100) / 100;
        }

        public static double GetDiscountAmount(this PriceModifier priceModifier, Product product)
        {
            if (priceModifier is null)
                throw new ArgumentException("Cannot call GetDiscountAmount on null.");
            if (product is null)
                throw new ArgumentException("Cannot calculate discount amount of null.");

            if (priceModifier is CompositeModifier)
            {
                return GetDiscountInCompositeModifier((priceModifier as CompositeModifier)!, product);
            }

            if (priceModifier is Discount)
                return -priceModifier.GetAmount(product);

            return 0.0;
        }

        private static double GetDiscountInCompositeModifier(CompositeModifier priceModifier, Product product)
        {
            double priceBeforeModification = product.CurrentPrice;
            product.CurrentPrice = product.BasePrice;

            double total = 0.0;
            foreach (var modifier in priceModifier._modifiers)
            {
                if (modifier is Discount)
                    total += -modifier.GetAmount(product);
                modifier.ModifyPrice(product);
            }

            product.CurrentPrice = priceBeforeModification;

            return total;
        }
    }
}