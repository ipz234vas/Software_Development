using Builder.Builders.Interfaces;
using Builder.Characters;

namespace Builder.Builders.Implementations
{
    public abstract class CharacterBuilder<T, TBuilder> : ICharacterBuilder<T, TBuilder> where T : Character
        where TBuilder : CharacterBuilder<T, TBuilder>
    {
        protected T _character;
        public abstract T Create();
        public abstract TBuilder Reset();

        public TBuilder AddAlly(string ally)
        {
            _character.Allies.Add(ally);
            return (TBuilder)this;
        }

        public TBuilder AddItem(string item)
        {
            _character.Inventory.Add(item);
            return (TBuilder)this;
        }

        public TBuilder WearingClothing(string clothing)
        {
            _character.Outfit = clothing;
            return (TBuilder)this;
        }

        public TBuilder WithEyeColor(string eyeColor)
        {
            _character.EyeColor = eyeColor;
            return (TBuilder)this;
        }

        public TBuilder WithHairColor(string hairColor)
        {
            _character.HairColor = hairColor;
            return (TBuilder)this;
        }

        public TBuilder WithHeight(double height)
        {
            _character.Height = height;
            return (TBuilder)this;
        }

        public TBuilder WithName(string name)
        {
            _character.Name = name;
            return (TBuilder)this;
        }

        public TBuilder WithStature(string stature)
        {
            _character.Stature = stature;
            return (TBuilder)this;
        }
    }
}
