namespace Mediator
{
    public class CommandCentre : IAirportMediator
    {
        private List<Runway> _runways;
        private readonly Dictionary<Aircraft, Runway> _assignments = new();

        public CommandCentre(IEnumerable<Runway> runways)
        {
            _runways = runways.ToList();
            foreach (Runway runway in _runways)
                runway.SetMediator(this);
        }

        public bool IsRunwayActive(Runway runway)
        {
            var assignment = _assignments
                .FirstOrDefault(kvp => kvp.Value == runway);

            return assignment.Key != null && assignment.Key.IsTakingOff;
        }

        public bool RequestLanding(Aircraft aircraft)
        {
            Console.WriteLine($"Checking runway.");
            var freeRunway = _runways.FirstOrDefault(r => !r.IsBusy);
            if (freeRunway == null)
                return false;

            freeRunway.IsBusy = true;
            freeRunway.HighLightRed();
            _assignments[aircraft] = freeRunway;
            return true;
        }

        public bool RequestTakeOff(Aircraft aircraft)
        {
            if (!_assignments.TryGetValue(aircraft, out var runway))
                return false;

            aircraft.IsTakingOff = true;

            runway.IsBusy = false;
            runway.HighLightGreen();
            _assignments.Remove(aircraft);

            aircraft.IsTakingOff = false;
            return true;
        }
    }
}