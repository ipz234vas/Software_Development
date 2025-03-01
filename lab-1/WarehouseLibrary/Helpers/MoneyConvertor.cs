using WarehouseLibrary.Interfaces;
using WarehouseLibrary.Models;

namespace WarehouseLibrary.Helpers
{
    public static class MoneyConvertor
    {
        public static int ConvertToMinorUnits(IMoney money) => money.IntegerPart * 100 + money.FractionalPart;

        public static IMoney ConvertFromMinorUnits(ICurrency currency, int totalMinorUnits)
        {
            MoneyValidator.ValidateMinorUnits(totalMinorUnits);

            return new Money(currency, totalMinorUnits / 100, totalMinorUnits % 100);
        }

        public static IMoney ConvertToCurrency(IMoney money, ICurrency currency)
        {
            MoneyValidator.ValidateMoneyWithCurrency(money);
            MoneyValidator.ValidateCurrency(currency);

            IMoney moneyInUSD = money.GetDivided(money.Currency.ExchangeRateToUSD);

            IMoney moneyInNewCurrency = moneyInUSD.GetMultiplied(currency.ExchangeRateToUSD);

            moneyInNewCurrency.Currency = currency;

            return moneyInNewCurrency;
        }
    }
}
