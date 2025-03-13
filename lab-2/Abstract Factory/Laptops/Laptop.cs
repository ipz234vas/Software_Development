using System.Text;

namespace Abstract_Factory.Laptops
{
    public abstract class Laptop
    {
        public abstract string OS { get; }  
        public string Model { get; set; }  
        public double Price { get; set; } 
        public double ScreenSize { get; set; } 
        public string Processor { get; set; }  
        public int RAM { get; set; }    
        public int Storage { get; set; } 
        public string GPU { get; set; }

        public virtual string GetDetails()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{Model} - {OS}");
            builder.AppendLine($"Price: {Price} UAH");
            builder.AppendLine($"Screen size: {ScreenSize}");
            builder.AppendLine($"Storage: {Storage} GB");
            builder.AppendLine($"RAM: {RAM} GB");
            builder.AppendLine($"Processor: {Processor}");
            builder.AppendLine($"GPU: {GPU}");
            return builder.ToString();
        }
    }
}
