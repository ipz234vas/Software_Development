using Builder.Characters;

namespace Builder.Builders.Interfaces
{
    public interface IHeroBuilder<TBuilder> : ICharacterBuilder<Hero, TBuilder> where TBuilder : IHeroBuilder<TBuilder>
    {
        TBuilder UsingSuperPower(string superPower);
        TBuilder AddGoodDeed(string goodDeed);
    }
}
