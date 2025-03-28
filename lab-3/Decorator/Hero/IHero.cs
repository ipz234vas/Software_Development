namespace Decorator.Hero
{
    public interface IHero
    {
        string Name { get; }
        int AttackPower { get; }
        int Defense { get; }
        int MagicPower { get; }
        string GetDetails()
        {
            return $"{Name}";
        }
    }
}
