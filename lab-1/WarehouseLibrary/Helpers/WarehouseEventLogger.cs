using WarehouseLibrary.Interfaces;
using WarehouseLibrary.Models;

namespace WarehouseLibrary.Helpers
{
    public class WarehouseEventLogger
    {
        private readonly List<IWarehouseItem> _incomingTransactions = new();
        private readonly List<IWarehouseItem> _outcomingTransactions = new();

        public IReadOnlyList<IWarehouseItem> IncomingTransactions => _incomingTransactions.AsReadOnly();
        public IReadOnlyList<IWarehouseItem> OutcomingTransactions => _outcomingTransactions.AsReadOnly();

        public void LogIncoming(IWarehouseItem item)
        {
            _incomingTransactions.Add(new WarehouseItem(item));
        }

        public void LogOutcoming(IWarehouseItem item)
        {
            _outcomingTransactions.Add(new WarehouseItem(item));
        }
    }
}
