using WarehouseLibrary.Helpers;
using WarehouseLibrary.Interfaces;

namespace WarehouseLibrary.Services
{
    public class WarehouseManager : IWarehouseManager
    {
        private readonly IWarehouse _warehouse;
        private readonly WarehouseEventLogger _logger;

        public WarehouseManager(IWarehouse warehouse, WarehouseEventLogger logger)
        {
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddItem(IWarehouseItem item)
        {
            _warehouse.AddItem(item);
            _logger.LogIncoming(item);
        }

        public void RemoveItem(IWarehouseItem item)
        {
            _warehouse.RemoveItem(item);
            _logger.LogOutcoming(item);
        }
    }

}
