namespace Factory_Method.Subscriptions
{
    public class DomesticSubscription : Subscription
    {
        public DomesticSubscription() : base()
        {
            MonthlyFee = 5;
            Name = "Domestic Subscription";
            MinimumPeriodInMonths = 1;
            Channels = new() { "STB", "New channel", "1+1" };
            Features = new() { "HD Quality" };
        }
    }
}