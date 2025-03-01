using WarehouseLibrary.Helpers;
using WarehouseLibrary.Interfaces;

namespace WarehouseLibrary.Services
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
