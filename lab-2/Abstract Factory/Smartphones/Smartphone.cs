using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Abstract_Factory.Smartphones
{
    public abstract class Smartphone
    {
        public string Model { get; set; }
        public abstract string OS { get; }
        public double Price { get; set; }
        public double ScreenSize { get; set; }
        public int RAM { get; set; } 
        public int Storage { get; set; } 
        public int BatteryCapacity { get; set; }

        public virtual string GetDetails()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{Model}");
            builder.AppendLine($"OS: {OS}");
            builder.AppendLine($"Price: {Price} UAH");
            builder.AppendLine($"Screen size: {ScreenSize}");
            builder.AppendLine($"RAM: {RAM} GB");
            builder.AppendLine($"Storage: {Storage} GB");
            builder.AppendLine($"Battery capacity: {BatteryCapacity} mah");
            return builder.ToString();
        }
    }
}
