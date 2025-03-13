using Factory_Method.Helpers;
using Factory_Method.Subscriptions;

namespace Factory_Method.Factories
{
    public class ManagerCall : SubscriptionFactory
    {
        private double _monthlyServiceFee => 1.5;
        public override Subscription CreateSubscription(SubscriptionType type)
        {
            var subscription = base.CreateSubscription(type);
            subscription.MonthlyFee += _monthlyServiceFee;
            return subscription;
        }
    }
}
