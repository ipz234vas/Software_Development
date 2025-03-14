using Builder.Characters;
namespace Builder.Builders.Interfaces
{
    public interface IEnemyBuilder<TBuilder> : ICharacterBuilder<Enemy, TBuilder> where TBuilder : IEnemyBuilder<TBuilder>
    {
        TBuilder UsingDarkPower(string darkPower);
        TBuilder AddEvilDeed(string evilDeed);
    }
}
