namespace Abstract_Factory.SmartWatches
{
    public class KiaomiSmartWatch : SmartWatch
    {
        public bool HasSleepTracker { get; set; }
        public override string OS => "MUIU for Band";
        public KiaomiSmartWatch()
        {
            Model = "Kiaomi Mi Band 6";
            DisplayType = "AMOLED";
            Price = 1000;
            BatteryLifeInDays = 14;
            HasWaterResistance = true;
            HasSleepTracker = true;
            HasGPS = false;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"Sleep tracker: {(HasSleepTracker ? "yes" : "no")}\n";
        }
    }
}
