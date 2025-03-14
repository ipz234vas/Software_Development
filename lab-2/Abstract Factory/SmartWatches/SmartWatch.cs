using Abstract_Factory.Interfaces;
using System.Text;

namespace Abstract_Factory.SmartWatches
{
    public abstract class SmartWatch  : IDevice
    {
        public abstract string OS { get; }              
        public string Model { get; set; }
        public double Price { get; set; }
        public string DisplayType { get; set; }     
        public int BatteryLifeInDays { get; set; }       
        public bool HasGPS { get; set; }           
        public bool HasWaterResistance { get; set; }  

        public virtual string GetDetails()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{Model} Smartwatch - {OS}");
            builder.AppendLine($"Price: {Price} UAH");
            builder.AppendLine($"Display Type: {DisplayType}");
            builder.AppendLine($"Battery Life: {BatteryLifeInDays} days");
            builder.AppendLine($"GPS: {(HasGPS ? "yes" : "no")}");
            builder.AppendLine($"Water Resistance: {(HasWaterResistance ? "yes" : "no")}");
            return builder.ToString();
        }
    }
}
