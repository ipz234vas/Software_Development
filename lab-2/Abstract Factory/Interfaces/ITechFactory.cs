using Abstract_Factory.EBooks;
using Abstract_Factory.Laptops;
using Abstract_Factory.Smartphones;
using Abstract_Factory.SmartWatches;

namespace Abstract_Factory.Interfaces
{
    public interface ITechFactory
    {
        Laptop CreateLaptop();
        Smartphone CreateSmartphone();
        EBook CreateEBook();
        SmartWatch CreateSmartWatch();
    }
}
