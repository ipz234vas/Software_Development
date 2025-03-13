using Factory_Method.Helpers;
using Factory_Method.Subscriptions;

namespace Factory_Method.Factories
{
    public class MobileApp : SubscriptionFactory
    {
        private double _mobileAppDiscount => 10;
        public override Subscription CreateSubscription(SubscriptionType type)
        {
            var subscription = base.CreateSubscription(type);
            subscription.MonthlyFee -= subscription.MonthlyFee * _mobileAppDiscount / 100;
            return subscription;
        }
    }
}
