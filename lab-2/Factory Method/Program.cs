using Factory_Method.Factories;
using Factory_Method.Helpers;
using Factory_Method.Subscriptions;

Console.WriteLine("Creating premium subscription by manager call:\n");
ISubscriptionFactory managerCall = new ManagerCall();
Subscription sub1 = managerCall.CreateSubscription(SubscriptionType.Premium);
Console.WriteLine(sub1.GetDetails());
Console.WriteLine("-------------------");

Console.WriteLine("Creating premium subscription by mobile:\n");
ISubscriptionFactory mobileApp = new MobileApp();
Subscription sub2 = mobileApp.CreateSubscription(SubscriptionType.Premium);
Console.WriteLine(sub2.GetDetails());
Console.WriteLine("-------------------");

Console.WriteLine("Creating educational subscription by web:\n");
ISubscriptionFactory web = new WebSite();
Subscription sub3 = web.CreateSubscription(SubscriptionType.Educational);
Console.WriteLine(sub3.GetDetails());
Console.WriteLine("-------------------");

Console.WriteLine("Creating domestic subscription by mobile:\n");
Subscription sub4 = mobileApp.CreateSubscription(SubscriptionType.Domestic);
Console.WriteLine(sub4.GetDetails());
Console.WriteLine("-------------------");