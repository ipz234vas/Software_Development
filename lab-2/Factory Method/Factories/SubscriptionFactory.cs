using Factory_Method.Helpers;
using Factory_Method.Subscriptions;

namespace Factory_Method.Factories
{
    public class SubscriptionFactory : ISubscriptionFactory
    {
        public virtual Subscription CreateSubscription(SubscriptionType type)
        {
            switch (type)
            {
                case SubscriptionType.Domestic:
                    return new DomesticSubscription();
                case SubscriptionType.Educational:
                    return new EducationalSubscription();
                case SubscriptionType.Premium:
                    return new PremiumSubscription();
                default:
                    throw new ArgumentException("Subscription type is invalid");
            }
        }
    }
}
