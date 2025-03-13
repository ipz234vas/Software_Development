using System.Text;

namespace Factory_Method.Subscriptions
{
    public abstract class Subscription
    {
        public string Name { get; protected set; }
        protected double monthlyFee;
        public double MonthlyFee
        {
            get => monthlyFee;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Monthly fee cannot be less than 0");
                }
                monthlyFee = value;
            }
        }
        public int MinimumPeriodInMonths { get; protected set; }
        public List<string> Channels { get; protected set; }
        public List<string> Features { get; protected set; }

        public string GetDetails()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{Name}:");
            builder.AppendLine($"Monthly Fee: {MonthlyFee}");
            builder.AppendLine($"Minimum Subscription Period (Months): {MinimumPeriodInMonths}");
            builder.AppendLine("Available Channels: " + string.Join(", ", Channels));
            builder.AppendLine("Features: " + string.Join(", ", Features));
            return builder.ToString();
        }
    }
}
