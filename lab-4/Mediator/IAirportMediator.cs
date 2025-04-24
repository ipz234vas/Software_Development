namespace Mediator
{
    public interface IAirportMediator
    {
        bool RequestLanding(Aircraft aircraft);
        bool RequestTakeOff(Aircraft aircraft);
        bool IsRunwayActive(Runway runway);
    }
}
