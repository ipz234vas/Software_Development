namespace WarehouseLibrary.Interfaces
{
    public interface IWarehouse
    {
        List<IWarehouseItem> Items { get; }
        void AddItem(IWarehouseItem item);
        void RemoveItem(IWarehouseItem item);
    }
}
