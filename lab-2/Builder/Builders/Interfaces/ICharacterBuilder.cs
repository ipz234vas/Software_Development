using Builder.Characters;

namespace Builder.Builders.Interfaces
{
    public interface ICharacterBuilder<T, TBuilder> where T : Character
        where TBuilder : ICharacterBuilder<T, TBuilder>
    {
        TBuilder WithName(string name);
        TBuilder WithHeight(double height);
        TBuilder WithStature(string stature);
        TBuilder WithHairColor(string hairColor);
        TBuilder WithEyeColor(string eyeColor);
        TBuilder WearingClothing(string clothing);
        TBuilder AddItem(string item);
        TBuilder AddAlly(string ally);
        TBuilder Reset();
        T Create();
    }
}
