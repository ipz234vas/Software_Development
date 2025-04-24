namespace Mediator
{
    public class Runway
    {
        public Guid Id { get; } = Guid.NewGuid();
        public bool IsBusy { get; set; } = false;

        private IAirportMediator? _mediator;

        public void SetMediator(IAirportMediator mediator)
        {
            _mediator = mediator;
        }

        public bool CheckIsActive()
        {
            return _mediator?.IsRunwayActive(this) ?? false;
        }

        public void HighLightRed()
        {
            Console.WriteLine($"Runway {this.Id} is busy!");
        }

        public void HighLightGreen()
        {
            Console.WriteLine($"Runway {this.Id} is free!");
        }
    }
}