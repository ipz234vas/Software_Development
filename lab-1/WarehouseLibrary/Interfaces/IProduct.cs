namespace WarehouseLibrary.Interfaces
{
    public interface IProduct
    {
        string Name { get; set; }
        string Description { get; set; }
        IMoney Price { get; set; }
        void DecreasePrice(IMoney money);
        void IncreasePrice(IMoney money);
    }
}
