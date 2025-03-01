namespace WarehouseLibrary.Interfaces
{
    public interface IMoney
    {
        ICurrency Currency { get; set; }
        int IntegerPart { get; set; }
        int FractionalPart { get; set; }
    }
}
