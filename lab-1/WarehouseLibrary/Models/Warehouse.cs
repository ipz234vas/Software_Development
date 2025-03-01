using WarehouseLibrary.Interfaces;

namespace WarehouseLibrary.Models
{
    public class Warehouse : IWarehouse
    {
        public List<IWarehouseItem> Items { get; private set; }

        public Warehouse()
        {
            Items = new List<IWarehouseItem>();
        }

        private IWarehouseItem? FindItemByProduct(IProduct product) => Items.FirstOrDefault(i => i.Product.Equals(product));

        public void AddItem(IWarehouseItem item)
        {
            var existingItem = FindItemByProduct(item.Product);
            AddItem(existingItem, item);
        }

        private void AddItem(IWarehouseItem? existingItem, IWarehouseItem item)
        {
            if (existingItem != null)
                existingItem.Add(item);
            else
                Items.Add(item);
        }

        public void RemoveItem(IWarehouseItem item)
        {
            var existingItem = FindItemByProduct(item.Product);
            existingItem = ValidateRemoveItem(existingItem, item);
            RemoveItem(existingItem, item);
        }

        private void RemoveItem(IWarehouseItem existingItem, IWarehouseItem item)
        {
            if (existingItem.Count > item.Count)
                existingItem.Count -= item.Count;
            else
                Items.Remove(existingItem);
        }

        private IWarehouseItem ValidateRemoveItem(IWarehouseItem? existingItem, IWarehouseItem item)
        {
            if (existingItem == null)
                throw new InvalidOperationException("Product is not in the warehouse.");
            if (existingItem.Count < item.Count)
                throw new InvalidOperationException("There is not enough product count in the warehouse.");
            return existingItem;
        }
    }
}
