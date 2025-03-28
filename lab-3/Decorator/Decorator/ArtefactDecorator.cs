using Decorator.Hero;

namespace Decorator.Decorator
{
    public class ArtefactDecorator : HeroDecorator
    {
        public ArtefactDecorator(IHero hero) : base(hero) { }

        public override int AttackPower => base.AttackPower + 2;
        public override int Defense => base.Defense + 1;
        public override int MagicPower => base.MagicPower + 7;
        public override string GetDetails()
        {
            return base.GetDetails() + ", has artefact";
        }
    }
}
