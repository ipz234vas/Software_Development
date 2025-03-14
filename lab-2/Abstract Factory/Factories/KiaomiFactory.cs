using Abstract_Factory.EBooks;
using Abstract_Factory.Interfaces;
using Abstract_Factory.Laptops;
using Abstract_Factory.Smartphones;
using Abstract_Factory.SmartWatches;

namespace Abstract_Factory.Factories
{
    public class KiaomiFactory : ITechFactory
    {
        public Laptop CreateLaptop()
        {
            return new KiaomiLaptop();
        }

        public Smartphone CreateSmartphone()
        {
            return new KiaomiSmartphone();
        }

        public EBook CreateEBook()
        {
            return new KiaomiEBook();
        }

        public SmartWatch CreateSmartWatch()
        {
            return new KiaomiSmartWatch();
        }
    }
}
