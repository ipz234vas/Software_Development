namespace WarehouseLibrary.Interfaces
{
    public interface IWarehouseItem
    {
        IProduct Product { get; set; }
        int Count { get; set; }
        DateTime LastIncoming { get; set; }
        IMoney GetTotalPrice();
    }
}
