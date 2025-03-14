using Singleton;

Task task1 = Task.Run(() =>
{
    var auth1 = Authenticator.GetInstance();
    if (auth1.Authenticate("admin", "password"))
        Console.WriteLine("Task 1: Authenticated");
});

Task task2 = Task.Run(() =>
{
    var auth2 = Authenticator.GetInstance();
    Thread.Sleep(100);
    if (auth2.IsAuthenticated)
        Console.WriteLine("Task 2: Already authenticated as " + auth2.Login);
});

Task.WaitAll(task1, task2);

var authenticator1 = Authenticator.GetInstance();
var authenticator2 = Authenticator.GetInstance();

if (authenticator1 == authenticator2)
    Console.WriteLine("Main: Authenticator instance is the same.");

if (authenticator1.Logout())
    Console.WriteLine("Main: Successfully logged out.");