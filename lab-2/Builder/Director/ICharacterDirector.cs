using Builder.Builders.Implementations;
using Builder.Builders.Interfaces;
using Builder.Characters;

namespace Builder.Director
{
    public interface ICharacterDirector
    {
        Character CreateTheMostEvilEnemy(IEnemyBuilder<EnemyBuilder> builder);
        Character CreateTheGreatestHero(IHeroBuilder<HeroBuilder> builder);
    }
}
