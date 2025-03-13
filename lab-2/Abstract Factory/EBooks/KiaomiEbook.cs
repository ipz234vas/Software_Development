namespace Abstract_Factory.EBooks
{
    public class KiaomiEbook : EBook
    {
        public override string Brand => "Kiaomi";
        public bool SupportsFastCharging { get; set; }
        public KiaomiEbook()
        {
            Model = "Reader 12 Pro Max";
            ScreenSize = 8.4;
            Storage = 32;
            BatteryLifeInDays = 10;
            Price = 4200;
            SupportsFastCharging = true;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"Supports Fast Charging: {(SupportsFastCharging ? "yes" : "no")}\n";
        }
    }
}
