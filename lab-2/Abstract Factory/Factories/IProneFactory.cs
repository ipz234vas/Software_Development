using Abstract_Factory.EBooks;
using Abstract_Factory.Interfaces;
using Abstract_Factory.Laptops;
using Abstract_Factory.Smartphones;
using Abstract_Factory.SmartWatches;

namespace Abstract_Factory.Factories
{
    public class IProneFactory : ITechFactory
    {
        public Laptop CreateLaptop()
        {
            return new IproneLaptop();
        }

        public Smartphone CreateSmartphone()
        {
            return new IProneSmartphone();
        }

        public EBook CreateEBook()
        {
            return new IproneEBook();
        }

        public SmartWatch CreateSmartWatch()
        {
            return new IproneSmartWatch();
        }
    }
}
