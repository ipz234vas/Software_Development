using Decorator.Hero;

namespace Decorator.Decorator
{
    public class ArmorDecorator : HeroDecorator
    {
        public ArmorDecorator(IHero hero) : base(hero) { }

        public override int Defense => base.Defense + 10;

        public override string GetDetails()
        {
            return base.GetDetails() + ", has armor";
        }
    }
}
