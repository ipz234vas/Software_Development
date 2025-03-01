## Implementation of Software Principles

### 1. Program to Interface, Not Implementations
To achieve flexibility and scalability, interfaces were used instead of concrete implementations. This allows for easier dependency swapping and promotes loose coupling.

Example Usage: [ICurrency.cs](https://github.com/ipz234vas/Software_Development/blob/lab-1/lab-1/WarehouseLibrary/Interfaces/ICurrency.cs), [Currency.cs](https://github.com/ipz234vas/Software_Development/blob/lab-1/lab-1/WarehouseLibrary/Models/Currency.cs)
```csharp
 public interface ICurrency
 {
     string CurrencyCode { get; set; }
     decimal ExchangeRateToUSD { get; set; }
 }

public class Currency : ICurrency
{
    private string _currencyCode;
    private decimal _exchangeRateToUSD;

    public string CurrencyCode
    {
         //implementations
    }

    public decimal ExchangeRateToUSD
    {
        //implementations
    }

    //implementations
}
```

### 2. Single Responsibility Principle (SRP)
Each class has a single responsibility, ensuring better maintainability and readability. To achieve it, some classes were divided into separate components. For example, reporting functionality was separated into distinct interfaces and implementations.

**Example:** [IReporting.cs](https://github.com/ipz234vas/Software_Development/blob/lab-1/lab-1/WarehouseLibrary/Interfaces/IReporting.cs), [IReportGenerator.cs](https://github.com/ipz234vas/Software_Development/blob/lab-1/lab-1/WarehouseLibrary/Interfaces/IReportGenerator.cs)
```csharp
namespace WarehouseLibrary.Interfaces
{
    public interface IReporting<T>
    {
        T GenerateIncomingReport();
        T GenerateInventoryReport(IWarehouse warehouse);
        T GenerateOutcomingReport();
    }
}

namespace WarehouseLibrary.Interfaces
{
    public interface IReportGenerator<T>
    {
        T GenerateIncomingReport(IEnumerable<IWarehouseItem> transactions);
        T GenerateInventoryReport(IWarehouse warehouse);
        T GenerateOutcomingReport(IEnumerable<IWarehouseItem> transactions);
    }
}

using System.Text;
using WarehouseLibrary.Interfaces;

namespace WarehouseLibrary
{
    public class TextReportGenerator : IReportGenerator<string>
    {
        private readonly ICurrency _currency;
        public TextReportGenerator(ICurrency currency)
        {
            _currency = currency;
        }

        public string GenerateIncomingReport(IEnumerable<IWarehouseItem> transactions)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Incoming Report:");
            return GetReport(transactions, sb);
        }

        public string GenerateOutcomingReport(IEnumerable<IWarehouseItem> transactions)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Outcoming Report:");
            return GetReport(transactions, sb);
        }

        public string GenerateInventoryReport(IWarehouse warehouse)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report:");
            return GetFullReport(warehouse.Items, sb);
        }

        private string GetReport(IEnumerable<IWarehouseItem> items, StringBuilder builder)
        {
            IMoney total = new Money(_currency);
            foreach (var item in items)
            {
                var itemPrice = item.GetTotalPrice();
                total = total.GetIncreased(MoneyConvertor.ConvertToCurrency(itemPrice, _currency));
                builder.AppendLine(item.ToString());
            }
            builder.AppendLine($"Total sum in {_currency.CurrencyCode} = {total.ToString()}");
            return builder.ToString();
        }

        private string GetFullReport(IEnumerable<IWarehouseItem> items, StringBuilder builder)
        {
            foreach (var item in items)
            {
                builder.AppendLine("----------------");
                builder.AppendLine(item.GetFullInfo());
            }
            builder.AppendLine("----------------");
            return builder.ToString();
        }
    }
}

using WarehouseLibrary.Interfaces;

namespace WarehouseLibrary
{
    public class Reporting<T> : IReporting<T>
    {
        private readonly WarehouseEventLogger _logger;
        private readonly IReportGenerator<T> _reportGenerator;

        public Reporting(WarehouseEventLogger logger, IReportGenerator<T> reportGenerator)
        {
            _logger = logger;
            _reportGenerator = reportGenerator;
        }

        public T GenerateIncomingReport()
        {
            return _reportGenerator.GenerateIncomingReport(_logger.IncomingTransactions);
        }

        public T GenerateOutcomingReport()
        {
            return _reportGenerator.GenerateOutcomingReport(_logger.OutcomingTransactions);
        }

        public T GenerateInventoryReport(IWarehouse warehouse)
        {
            return _reportGenerator.GenerateInventoryReport(warehouse);
        }
    }
}
```

### 3. Open/Closed Principle
The code is designed to be open for extension but closed for modification by using abstract classes and interfaces. One of the greatest examples is [Money.cs](https://github.com/ipz234vas/Software_Development/blob/lab-1/lab-1/WarehouseLibrary/Models/Money.cs). Its functionality was extended by [MoneyExtensions.cs](https://github.com/ipz234vas/Software_Development/blob/lab-1/lab-1/WarehouseLibrary/Helpers/MoneyExtensions.cs). It also supports SRP.
**Example:**
```csharp
using WarehouseLibrary.Interfaces;

namespace WarehouseLibrary.Models
{
    public class Money : IMoney
    {
        private int _integerPart;
        private int _fractionalPart;
        private ICurrency _currency;

        //props

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

public static class MoneyExtensions
    {
        public static IMoney GetIncreased(this IMoney a, IMoney b)
        {
            MoneyValidator.ValidateSameCurrency(a, b);
            int newMinorUnits = ConvertToMinorUnits(a) + ConvertToMinorUnits(b);
            return ConvertFromMinorUnits(a.Currency, newMinorUnits);
        }
    //others methods
  }
```

### 4. Liskov Substitution Principle (Barbara Principle)
Subclasses can be used interchangeably with their base classes without altering the correctness of the program.
It is achived by providing [Interfaces](https://github.com/ipz234vas/Software_Development/tree/lab-1/lab-1/WarehouseLibrary/Interfaces) 

**Example:**
```csharp
 public interface ICurrency
 {
     string CurrencyCode { get; set; }
     decimal ExchangeRateToUSD { get; set; }
 }

public class Currency : ICurrency
{
    private string _currencyCode;
    private decimal _exchangeRateToUSD;

    public string CurrencyCode
    {
         //implementations
    }

    public decimal ExchangeRateToUSD
    {
        //implementations
    }

    //implementations
}
```

### 5. Dependency Inversion Principle
High-level modules do not depend on low-level modules. Instead, both depend on abstractions.
[Reporting Class](https://github.com/ipz234vas/Software_Development/blob/lab-1/lab-1/WarehouseLibrary/Services/Reporting.cs) does not depend on a specific implementation; rather, it is generic and can be used for formatting any type of report.

**Example:**
```csharp
public class Reporting<T> : IReporting<T>
{
    private readonly WarehouseEventLogger _logger;
    private readonly IReportGenerator<T> _reportGenerator;

    public Reporting(WarehouseEventLogger logger, IReportGenerator<T> reportGenerator)
    {
        _logger = logger;
        _reportGenerator = reportGenerator;
    }

    public T GenerateIncomingReport()
    {
        return _reportGenerator.GenerateIncomingReport(_logger.IncomingTransactions);
    }

    public T GenerateOutcomingReport()
    {
        return _reportGenerator.GenerateOutcomingReport(_logger.OutcomingTransactions);
    }

    public T GenerateInventoryReport(IWarehouse warehouse)
    {
        return _reportGenerator.GenerateInventoryReport(warehouse);
    }
}
```

### 6. Composition over Inheritance
Instead of inheritance, composition is used to promote flexibility. Instead of creating separate subclasses for different currencies, a single [ICurrency](https://github.com/ipz234vas/Software_Development/blob/lab-1/lab-1/WarehouseLibrary/Interfaces/ICurrency.cs) interface is used. This allows any new currency to be introduced without modifying existing code—just by implementing the interface and injecting it into [IMoney](https://github.com/ipz234vas/Software_Development/blob/lab-1/lab-1/WarehouseLibrary/Interfaces/IMoney.cs). 

**Example:**
```csharp
   public interface ICurrency
   {
       string CurrencyCode { get; set; }
       decimal ExchangeRateToUSD { get; set; }
   }

  public interface IMoney
  {
      ICurrency Currency { get; set; }
      int IntegerPart { get; set; }
      int FractionalPart { get; set; }
  }
```

### 7. Fail Fast Principle
Validation is performed at the earliest opportunity to prevent errors from propagating. It is applied wherever invalid data might occur, especially in properties. This approach ensures that issues are detected as soon as possible, preventing further execution with incorrect data.
A great example is the validation implemented in [Money line 11-37](https://github.com/ipz234vas/Software_Development/blob/2b06b8a1af3d10c7afe4cf99cae42badf5683877/lab-1/WarehouseLibrary/Models/Money.cs#L11)'s props

**Example:**
```csharp
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
```

### 8. DRY (Don't Repeat Yourself)
Code duplication is minimized by extracting reusable components and functions in [Helpers](https://github.com/ipz234vas/Software_Development/tree/lab-1/lab-1/WarehouseLibrary/Helpers) Such as [MoneyConvertor](https://github.com/ipz234vas/Software_Development/blob/lab-1/lab-1/WarehouseLibrary/Helpers/MoneyConvertor.cs).

**Example:**
```csharp
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
```

## Conclusion
By following these principles, the codebase is more maintainable, scalable, and robust.

