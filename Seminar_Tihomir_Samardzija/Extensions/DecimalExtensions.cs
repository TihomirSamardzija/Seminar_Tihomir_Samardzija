namespace Seminar_Tihomir_Samardzija.Extensions
{
    public static class DecimalExtensions
    {
        public static bool GreaterThan(this decimal input, decimal compared)
        {
            return input > compared;
        }

    }
}
