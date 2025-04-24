namespace ChainOfResponsibility
{
    public class LoanSupportHandler : SupportHandler
    {
        public override bool Handle(string request)
        {
            if (request != "credit")
            {
                return base.Handle(request);
            }

            Console.WriteLine("Loan Support:");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(" - 'loan' -> Take a new loan");
            Console.WriteLine(" - 'other' -> I have a different question");
            Console.Write("Your choice: ");
            var answer = Console.ReadLine();
            if (answer == "loan")
            {
                Console.WriteLine("Loan Support: Let me walk you through our loan conditions...");
                return true;
            }
            return base.Handle(answer);
        }
    }
}
