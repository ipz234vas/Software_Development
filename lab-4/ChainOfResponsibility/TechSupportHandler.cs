namespace ChainOfResponsibility
{
    public class TechSupportHandler : SupportHandler
    {
        public override bool Handle(string request)
        {
            if (request == "transaction_problem")
            {
                Console.WriteLine("Tech support: One second and I'll fix it...");
                return true;
            }

            return base.Handle(request);
        }
    }
}
