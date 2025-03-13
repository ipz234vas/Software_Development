namespace Abstract_Factory.Smartphones
{
    public class KiaomiSmartphone : Smartphone
    {
        public bool WithTurboCharge { get; set; }
        public override string OS => "MUIU";
        public KiaomiSmartphone()
        {
            Model = "Kiaomi Pedmi Note 9 Pro";
            ScreenSize = 6.67;
            RAM = 6;
            Storage = 128;
            BatteryCapacity = 5020;
            Price = 4999;
            WithTurboCharge = true;
        }
        public override string GetDetails()
        {
            return base.GetDetails() + $"With Turbo Charge: {(WithTurboCharge ? "yes" : "no")}\n";
        }
    }
}
