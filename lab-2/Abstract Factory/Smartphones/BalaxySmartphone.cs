namespace Abstract_Factory.Smartphones
{
    public class BalaxySmartphone : Smartphone
    {
        public string AnbroibVersion { get; set; }
        public override string OS => "Anbroib";
        public BalaxySmartphone()
        {
            Model = "Balaxy B25 Ultra";
            ScreenSize = 6.67;
            RAM = 12;
            Storage = 512;
            BatteryCapacity = 5000;
            Price = 67999;
            AnbroibVersion = "14.2.0";
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"Anbroib Version: {AnbroibVersion}\n";
        }
    }
}
