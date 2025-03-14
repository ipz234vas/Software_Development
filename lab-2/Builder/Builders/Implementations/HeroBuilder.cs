using Builder.Builders.Interfaces;
using Builder.Characters;

namespace Builder.Builders.Implementations
{
    public class HeroBuilder : CharacterBuilder<Hero, HeroBuilder>, IHeroBuilder<HeroBuilder>
    {
        public HeroBuilder()
        {
            Reset();
        }

        public override HeroBuilder Reset()
        {
            _character = new Hero();
            return this;
        }

        public HeroBuilder AddGoodDeed(string goodDeed)
        {
            _character.GoodDeeds.Add(goodDeed);
            return this;
        }

        public HeroBuilder UsingSuperPower(string superPower)
        {
            _character.SuperPower = superPower;
            return this;
        }

        public override Hero Create()
        {
            var hero = _character;
            Reset();
            return hero;
        }
    }
}
