namespace Abstract_Factory.Laptops
{
    public class KiaomiLaptop : Laptop
    {
        public bool HasAMOLEDDisplay { get; set; }  
        public override string OS => "Linux";
        public KiaomiLaptop()
        {
            Model = "Laptop Pro 14";
            ScreenSize = 14;
            Storage = 512;
            Price = 29900;
            Processor = "Intel Core i5";
            GPU = "Intel Iris Xe Graphics";
            RAM = 16;
            HasAMOLEDDisplay = false;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"Has AMOLED Display: {(HasAMOLEDDisplay ? "yes" : "no")}\n";
        }
    }
}
