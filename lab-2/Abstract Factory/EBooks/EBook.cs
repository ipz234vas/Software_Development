using System.Text;

namespace Abstract_Factory.EBooks
{
    public abstract class EBook
    {
        public abstract string Brand { get; }
        public string Model { get; set; }  
        public double Price { get; set; }
        public double ScreenSize { get; set; } 
        public int BatteryLifeInDays { get; set; } 
        public int Storage { get; set; } 

        public virtual string GetDetails()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{Brand} {Model}");
            builder.AppendLine($"Price: {Price} UAH");
            builder.AppendLine($"Screen size: {ScreenSize}");
            builder.AppendLine($"Storage: {Storage} GB");
            builder.AppendLine($"Battery life: {BatteryLifeInDays} days");
            return builder.ToString();
        }
    }
}
