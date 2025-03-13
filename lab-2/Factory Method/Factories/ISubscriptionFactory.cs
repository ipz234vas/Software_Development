using Factory_Method.Helpers;
using Factory_Method.Subscriptions;

namespace Factory_Method.Factories
{
    public interface ISubscriptionFactory
    {
        Subscription CreateSubscription(SubscriptionType type);
    }
}
