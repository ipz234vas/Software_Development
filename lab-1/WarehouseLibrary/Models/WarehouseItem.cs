using WarehouseLibrary.Helpers;
using WarehouseLibrary.Interfaces;

namespace WarehouseLibrary.Models
{
    public class WarehouseItem : IWarehouseItem
    {
        public IProduct Product { get; set; }
        public int Count { get; set; }
        public DateTime LastIncoming { get; set; }
        public WarehouseItem(IProduct product, int count, DateTime lastIncoming)
        {
            Product = product;
            Count = count;
            LastIncoming = lastIncoming;
        }

        public WarehouseItem(IWarehouseItem item)
        {
            Product = item.Product;
            Count = item.Count;
            LastIncoming = item.LastIncoming;
        }

        public IMoney GetTotalPrice()
        {
            IMoney totalPrice = MoneyExtensions.GetMultiplied(Product.Price, Count);
            return totalPrice;
        }

        public void Add(IWarehouseItem item)
        {
            if (item == null || item.Product != Product)
                return;
            Count += item.Count;
            LastIncoming = item.LastIncoming > LastIncoming ? item.LastIncoming : LastIncoming;
        }

        public override string ToString()
        {
            return $"{LastIncoming}: {Product.Name} - {Product.Price} x {Count}. Total price = {GetTotalPrice()}";
        }

        public string GetFullInfo()
        {
            return $"Product: {Product.Name}\nDescription: {Product.Description}\nLast incoming: {LastIncoming}\nPrice: {Product.Price}\nCount: {Count}\nTotal price = {GetTotalPrice()}";
        }
    }
}
