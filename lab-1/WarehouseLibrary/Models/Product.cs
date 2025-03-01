using WarehouseLibrary.Helpers;
using WarehouseLibrary.Interfaces;

namespace WarehouseLibrary.Models
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IMoney Price { get; set; }
        public Product(string name, string description, IMoney price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
        public void IncreasePrice(IMoney money)
        {
            Price = Price.GetIncreased(money);
        }

        public void DecreasePrice(IMoney money)
        {
            Price = Price.GetDecreased(money);
        }
    }
}
