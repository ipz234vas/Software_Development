using System.Text;
using WarehouseLibrary.Helpers;
using WarehouseLibrary.Interfaces;
using WarehouseLibrary.Models;

namespace WarehouseLibrary.Services
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
