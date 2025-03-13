namespace Abstract_Factory.EBooks
{
    public class BalaxyEBook : EBook
    {
        public override string Brand => "Balaxy";
        public bool HasSamsungDeX { get; set; }
        public BalaxyEBook()
        {
            Model = "E47";
            ScreenSize = 10;
            Storage = 128;
            BatteryLifeInDays = 20;
            Price = 16800;
            HasSamsungDeX = false;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"Has Samsung DeX: {(HasSamsungDeX ? "yes" : "no")}\n";
        }
    }
}
