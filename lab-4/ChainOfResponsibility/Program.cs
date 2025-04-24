using ChainOfResponsibility;

var aiHandler = new AISupportHandler();
var techHandler = new TechSupportHandler();
var loanHandler = new LoanSupportHandler();
var liveOperatorHandler = new LiveOperatorSupportHandler();

aiHandler.SetNext(techHandler);
techHandler.SetNext(loanHandler);
loanHandler.SetNext(liveOperatorHandler);

Console.WriteLine("Welcome to Bank Support!");
while (true)
{

    Console.WriteLine("Type your request:");
    Console.WriteLine(" - 'balance' to check your balance");
    Console.WriteLine(" - 'transaction_problem' if you have issues with a transaction");
    Console.WriteLine(" - 'credit' for loan-related questions");
    Console.WriteLine(" - 'other' for any other questions");
    Console.WriteLine(" - 'exit' to end");
    Console.Write("Your request: ");

    string? request = Console.ReadLine();
    Console.WriteLine();

    if (request == "exit" || aiHandler.Handle(request))
    {
        Console.WriteLine("Thank you for contacting us. Goodbye!");
        break;
    }

    Console.WriteLine("Sorry, we couldn't understand your request. Try again.");
    Console.WriteLine("\n-------------------------------\n");
}