namespace WarehouseLibrary.Interfaces
{
    public interface ICurrency
    {
        string CurrencyCode { get; set; }
        decimal ExchangeRateToUSD { get; set; }
    }
}