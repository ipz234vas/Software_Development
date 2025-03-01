namespace WarehouseLibrary.Interfaces
{
    public interface IWarehouseManager
    {
        void AddItem(IWarehouseItem item);
        void RemoveItem(IWarehouseItem item);
    }
}
