namespace Abstract_Factory.SmartWatches
{
    public class BalaxySmartWatch : SmartWatch
    {
        public int Storage { get; set; }
        public override string OS => "Wear OS";
        public BalaxySmartWatch()
        {
            Model = "Balaxy Watch 4";
            DisplayType = "Super AMOLED";
            Price = 8000;
            BatteryLifeInDays = 2;
            HasWaterResistance = true;
            HasGPS = true;
            Storage = 16;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"Storage: {Storage} GB\n";
        }
    }
}
