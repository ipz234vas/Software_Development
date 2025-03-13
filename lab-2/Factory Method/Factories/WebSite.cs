using Factory_Method.Helpers;
using Factory_Method.Subscriptions;

namespace Factory_Method.Factories
{
    public class WebSite : SubscriptionFactory
    {
        //nothing unique
        public override Subscription CreateSubscription(SubscriptionType type)
        {
            return base.CreateSubscription(type);
        }
    }
}
