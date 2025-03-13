namespace Factory_Method.Subscriptions
{
    public class PremiumSubscription : Subscription
    {
        public PremiumSubscription() : base()
        {
            MonthlyFee = 20;
            Name = "Premium Subscription";
            MinimumPeriodInMonths = 1;
            Channels = new() { "News", "Sports", "Movies", "Documentaries", "Exclusive Content", "QTV" };
            Features = new() { "4K Quality", "Ad-Free", "Multi-Device Support", "Content Download", "QTV is returned" };
        }
    }
}
