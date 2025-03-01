namespace WarehouseLibrary.Interfaces
{
    public interface IReportGenerator<T>
    {
        T GenerateIncomingReport(IEnumerable<IWarehouseItem> transactions);
        T GenerateInventoryReport(IWarehouse warehouse);
        T GenerateOutcomingReport(IEnumerable<IWarehouseItem> transactions);
    }
}
