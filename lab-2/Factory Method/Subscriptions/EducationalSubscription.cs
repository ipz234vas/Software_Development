namespace Factory_Method.Subscriptions
{
    public class EducationalSubscription : Subscription
    {
        public EducationalSubscription() : base()
        {
            MonthlyFee = 7.5;
            Name = "Educational Subscription";
            MinimumPeriodInMonths = 9;
            Channels = new() { "Documentaries", "Learning", "Science" };
            Features = new() { "HD Quality", "Ad-Free" };
        }
    }
}
