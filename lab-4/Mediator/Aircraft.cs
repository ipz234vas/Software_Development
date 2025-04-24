namespace Mediator
{
    public class Aircraft
    {
        public string Name { get; }
        public bool IsTakingOff { get; set; }

        private readonly IAirportMediator _mediator;

        public Aircraft(string name, IAirportMediator mediator)
        {
            Name = name;
            _mediator = mediator;
        }

        public void Land()
        {
            Console.WriteLine($"Aircraft {this.Name} is landing.");
            if (_mediator.RequestLanding(this))
                Console.WriteLine($"Aircraft {this.Name} has landed.");
            else
                Console.WriteLine($"Could not land, the runway is busy.");
        }

        public void TakeOff()
        {
            Console.WriteLine($"Aircraft {this.Name} is taking off.");
            if (_mediator.RequestTakeOff(this))
                Console.WriteLine($"Aircraft {this.Name} has took off.");
            else
                Console.WriteLine($"Aircraft {this.Name} cannot take off.");
        }
    }
}