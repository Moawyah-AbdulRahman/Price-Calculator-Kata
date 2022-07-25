namespace Prog
{
    public static class Utils
    {
        public static double RoundTwoDecimalPlaces(this double value)
        {
            return Math.Round(value * 100) / 100;
        }
    }
}