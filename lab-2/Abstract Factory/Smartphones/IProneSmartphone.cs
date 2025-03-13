namespace Abstract_Factory.Smartphones
{
    public class IProneSmartphone : Smartphone
    {
        public override string OS => "NacOS";
        public bool WithFaceID { get; set; }
        public IProneSmartphone()
        {
            Model = "Iprone 15 Pro Max";
            ScreenSize = 6.7;
            RAM = 8;
            Storage = 256;
            BatteryCapacity = 4440;
            Price = 45000;
            WithFaceID = true;
        }
        public override string GetDetails()
        {
            return base.GetDetails() + $"With Face ID: {(WithFaceID ? "yes" : "no")}\n";
        }
    }
}
