namespace Decorator.Hero
{
    public class Mage : IHero
    {
        public string Name { get; }

        public int AttackPower { get; }

        public int Defense { get; }

        public int MagicPower { get; }

        public Mage()
        {
            Name = "Mage";
            AttackPower = 2;
            Defense = 3;
            MagicPower = 10;
        }
    }
}
