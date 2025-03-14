using Builder.Builders.Interfaces;
using Builder.Characters;

namespace Builder.Builders.Implementations
{
    public class EnemyBuilder : CharacterBuilder<Enemy, EnemyBuilder>, IEnemyBuilder<EnemyBuilder>
    {
        public EnemyBuilder()
        {
            Reset();
        }

        public override EnemyBuilder Reset()
        {
            _character = new Enemy();
            return this;
        }

        public EnemyBuilder AddEvilDeed(string evilDeed)
        {
            _character.EvilDeeds.Add(evilDeed);
            return this;
        }

        public EnemyBuilder UsingDarkPower(string darkPower)
        {
            _character.DarkPower = darkPower;
            return this;
        }

        public override Enemy Create()
        {
            var enemy = _character;
            Reset();
            return enemy;
        }
    }
}
