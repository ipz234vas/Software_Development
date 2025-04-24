namespace ChainOfResponsibility
{
    public class AISupportHandler : SupportHandler
    {
        public override bool Handle(string request)
        {
            if (request == "balance")
            {
                Console.WriteLine("AI: Your balance = 10$");
                return true;
            }

            return base.Handle(request);
        }
    }
}
