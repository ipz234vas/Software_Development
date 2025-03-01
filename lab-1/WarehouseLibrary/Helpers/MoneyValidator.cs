using WarehouseLibrary.Interfaces;

namespace WarehouseLibrary.Helpers
{
    public static class MoneyValidator
    {
        public static void ValidateMoneyWithCurrency(IMoney money)
        {
            if (money == null)
                throw new ArgumentNullException(nameof(money), "Money cannot be null!");

            if (money.Currency.ExchangeRateToUSD <= 0)
                throw new InvalidOperationException("Source currency exchange rate must be greater than zero!");
        }

        public static void ValidateCurrency(ICurrency currency)
        {
            if (currency == null)
                throw new ArgumentNullException(nameof(currency), "Target currency cannot be null!");

            if (currency.ExchangeRateToUSD <= 0)
                throw new ArgumentOutOfRangeException(nameof(currency), "Exchange rate must be greater than zero!");
        }

        public static void ValidateSameCurrency(IMoney a, IMoney b)
        {
            if (!a.Currency.Equals(b.Currency))
                throw new InvalidOperationException("Cannot perform operations on different currencies.");
        }

        public static void ValidateMultiplier(decimal multiplier)
        {
            if (multiplier < 0)
                throw new ArgumentException("Multiplier cannot be negative", nameof(multiplier));
        }

        public static void ValidateDivisor(decimal divisor)
        {
            if (divisor <= 0)
                throw new ArgumentException("Divisor must be more than 0!", nameof(divisor));
        }

        public static void ValidateMinorUnits(int minorUnits)
        {
            if (minorUnits < 0)
                throw new InvalidOperationException("Minor units cannot be negative!");
        }
    }
}
