using WarehouseLibrary.Interfaces;

namespace WarehouseLibrary.Models
{
    public class Currency : ICurrency
    {
        private string _currencyCode;
        private decimal _exchangeRateToUSD;

        public string CurrencyCode
        {
            get => _currencyCode;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Currency code cannot be empty!", nameof(value));
                _currencyCode = value;
            }
        }

        public decimal ExchangeRateToUSD
        {
            get => _exchangeRateToUSD;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Exchange rate to USD should be more than 0!", nameof(value));
                _exchangeRateToUSD = value;
            }
        }

        public Currency(string currencyCode, decimal exchangeRateToUSD)
        {
            CurrencyCode = currencyCode;
            ExchangeRateToUSD = exchangeRateToUSD;
        }
    }

}
