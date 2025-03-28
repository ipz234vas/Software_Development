using Decorator.Hero;

namespace Decorator.Decorator
{
    public class WeaponDecorator : HeroDecorator
    {
        public WeaponDecorator(IHero hero) : base(hero) { }

        public override int AttackPower => base.AttackPower + 5;

        public override string GetDetails()
        {
            return base.GetDetails() + ", has weapon";
        }
    }
}
