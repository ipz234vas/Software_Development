namespace WarehouseLibrary.Interfaces
{
    public interface IReporting<T>
    {
        T GenerateIncomingReport();
        T GenerateOutcomingReport();
        T GenerateInventoryReport(IWarehouse warehouse);
    }
}
