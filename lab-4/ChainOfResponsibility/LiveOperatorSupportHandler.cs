namespace ChainOfResponsibility
{
    public class LiveOperatorSupportHandler : SupportHandler
    {
        public override bool Handle(string request)
        {
            if (request == "other")
            {
                Console.WriteLine("Operator: Hello, I am here to help you with your question!");
                return true;
            }

            return base.Handle(request);
        }
    }
}
