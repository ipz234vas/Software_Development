using System.Runtime.Intrinsics.Arm;

namespace Abstract_Factory.EBooks
{
    public class IproneEbook : EBook
    {
        public override string Brand => "Iprone";
        public bool SupportsApplePencil { get; set; }
        public IproneEbook()
        {
            Model = "EBook 30000 Ultra";
            ScreenSize = 12;
            Storage = 64;
            BatteryLifeInDays = 15;
            Price = 30000;
            SupportsApplePencil = false;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"Supports Apple Pencil: {(SupportsApplePencil ? "yes" : "no")}\n";
        }
    }
}
