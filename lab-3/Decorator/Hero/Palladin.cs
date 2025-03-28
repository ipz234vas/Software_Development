namespace Decorator.Hero
{
    public class Palladin : IHero
    {
        public string Name { get; }

        public int AttackPower { get; }

        public int Defense { get; }

        public int MagicPower { get; }

        public Palladin()
        {
            Name = "Palladin";
            AttackPower = 7;
            Defense = 9;
            MagicPower = 6;
        }
    }
}
