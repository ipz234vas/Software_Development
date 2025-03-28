namespace Decorator.Hero
{
    public class Warrior : IHero
    {
        public string Name { get; }

        public int AttackPower { get; }

        public int Defense { get; }

        public int MagicPower { get; }

        public Warrior()
        {
            Name = "Warrior";
            AttackPower = 9;
            Defense = 8;
            MagicPower = 1;
        }
    }
}
