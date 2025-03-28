using Decorator.Hero;

namespace Decorator.Decorator
{
    public abstract class HeroDecorator : IHero
    {
        protected readonly IHero _hero;
        public HeroDecorator(IHero hero)
        {
            _hero = hero;
        }

        public virtual string Name => _hero.Name;

        public virtual int AttackPower => _hero.AttackPower;

        public virtual int Defense => _hero.Defense;

        public virtual int MagicPower => _hero.MagicPower;

        public virtual string GetDetails()
        {
            return _hero.GetDetails();
        }
    }
}
