namespace Abstract_Factory.Laptops
{
    public class BalaxyLaptop : Laptop
    {
        public int RefreshRate { get; set; }
        public override string OS => "Winbows 10";
        public BalaxyLaptop()
        {
            Model = "NP 930";
            ScreenSize = 15.6;
            Storage = 128;
            Price = 12500;
            Processor = "Intel Core i7";
            GPU = "Intel UHD Graphics 620";
            RAM = 8;
            RefreshRate = 120;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"Refresh Rate: {RefreshRate} Hz\n";
        }
    }
}
