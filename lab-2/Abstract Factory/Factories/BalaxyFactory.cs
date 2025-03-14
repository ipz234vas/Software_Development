using Abstract_Factory.EBooks;
using Abstract_Factory.Interfaces;
using Abstract_Factory.Laptops;
using Abstract_Factory.Smartphones;
using Abstract_Factory.SmartWatches;

namespace Abstract_Factory.Factories
{
    public class BalaxyFactory : ITechFactory
    {
        public Laptop CreateLaptop()
        {
            return new BalaxyLaptop();
        }

        public Smartphone CreateSmartphone()
        {
            return new BalaxySmartphone();
        }

        public EBook CreateEBook()
        {
            return new BalaxyEBook();
        }

        public SmartWatch CreateSmartWatch()
        {
            return new BalaxySmartWatch();
        }
    }
}
