using WarehouseLibrary.Interfaces;

namespace WarehouseLibrary.Models
{
    public class Money : IMoney
    {
        private int _integerPart;
        private int _fractionalPart;
        private ICurrency _currency;

        public ICurrency Currency
        {
            get => _currency;
            set => _currency = value ?? throw new ArgumentNullException(nameof(value), "Currency cannot be null!");
        }

        public int IntegerPart
        {
            get => _integerPart;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Integer part cannot be negative!", nameof(value));
                _integerPart = value;
            }
        }

        public int FractionalPart
        {
            get => _fractionalPart;
            set
            {
                if (value < 0 || value > 99)
                    throw new ArgumentException("Fractional part must be between 0 and 99!", nameof(value));
                _fractionalPart = value;
            }
        }

        public Money(ICurrency currency, int integerPart = 0, int fractionalPart = 0)
        {
            Currency = currency;
            IntegerPart = integerPart;
            FractionalPart = fractionalPart;
        }

        public override string ToString() =>
            $"{IntegerPart},{FractionalPart:D2} {Currency.CurrencyCode}";
    }
}
