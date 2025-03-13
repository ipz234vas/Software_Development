namespace Abstract_Factory.Laptops
{
    public class IproneLaptop : Laptop
    {
        public string NacOSVersion { get; set; }
        public override string OS => "NacOS";
        public IproneLaptop()
        {
            Model = "NacBook Bro";
            ScreenSize = 16;
            Storage = 1024;
            Price = 120000;
            Processor = "N4 Bro 12-core CPU";
            GPU = "Iprone N4 Bro GPU (16-core)";
            RAM = 32;
            NacOSVersion = "Sequoia (version 15)";
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"NacOS Version: {NacOSVersion}\n";
        }
    }
}
