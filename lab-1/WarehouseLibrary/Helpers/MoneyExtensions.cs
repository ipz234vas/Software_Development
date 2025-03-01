using WarehouseLibrary.Interfaces;
using static WarehouseLibrary.Helpers.MoneyConvertor;
namespace WarehouseLibrary.Helpers
{
    public static class MoneyExtensions
    {
        public static IMoney GetIncreased(this IMoney a, IMoney b)
        {
            MoneyValidator.ValidateSameCurrency(a, b);
            int newMinorUnits = ConvertToMinorUnits(a) + ConvertToMinorUnits(b);
            return ConvertFromMinorUnits(a.Currency, newMinorUnits);
        }

        public static IMoney GetDecreased(this IMoney a, IMoney b)
        {
            MoneyValidator.ValidateSameCurrency(a, b);
            int newMinorUnits = ConvertToMinorUnits(a) - ConvertToMinorUnits(b);
            MoneyValidator.ValidateMinorUnits(newMinorUnits);

            return ConvertFromMinorUnits(a.Currency, newMinorUnits);
        }

        public static IMoney GetMultiplied(this IMoney a, decimal multiplier)
        {
            MoneyValidator.ValidateMultiplier(multiplier);

            int newMinorUnits = (int)(ConvertToMinorUnits(a) * multiplier);
            return ConvertFromMinorUnits(a.Currency, newMinorUnits);
        }

        public static IMoney GetDivided(this IMoney a, decimal divisor)
        {
            MoneyValidator.ValidateDivisor(divisor);

            int newMinorUnits = (int)(ConvertToMinorUnits(a) / divisor);
            return ConvertFromMinorUnits(a.Currency, newMinorUnits);
        }
    }
}