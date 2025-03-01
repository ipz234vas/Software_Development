using WarehouseLibrary.Interfaces;

namespace WarehouseLibrary.Helpers
{
    public class WarehouseEventDispatcher
    {
        public event Action<IWarehouseItem>? ItemAdded;
        public event Action<IWarehouseItem>? ItemRemoved;

        public void NotifyItemAdded(IWarehouseItem item) => ItemAdded?.Invoke(item);
        public void NotifyItemRemoved(IWarehouseItem item) => ItemRemoved?.Invoke(item);
    }
}
