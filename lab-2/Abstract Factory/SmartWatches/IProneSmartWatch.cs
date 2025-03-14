namespace Abstract_Factory.SmartWatches
{
    public class IproneSmartWatch : SmartWatch
    {
        public bool HasCompass { get; set; }
        public override string OS => "watchOS";
        public IproneSmartWatch()
        {
            Model = "Abble Watch SE";
            DisplayType = "OLED";
            Price = 7500;
            BatteryLifeInDays = 1;
            HasWaterResistance = true;
            HasCompass = true;
            HasGPS = true;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"Compass: {(HasCompass ? "yes" : "no")}\n";
        }
    }
}
