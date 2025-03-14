using Builder.Builders.Implementations;
using Builder.Builders.Interfaces;
using Builder.Characters;

namespace Builder.Director
{
    public class CharacterDirector : ICharacterDirector
    {
        public Character CreateTheGreatestHero(IHeroBuilder<HeroBuilder> builder)
        {
            builder.Reset();

            var hero = builder
                .WithName("Poor Student")
                .WithStature("Skinny")
                .WithHeight(180)
                .WearingClothing("Old Shirt")
                .WithEyeColor("Brown")
                .WithHairColor("Dark")
                .AddAlly("ChatGPT")
                .AddAlly("Documentation")
                .AddAlly("Own brain")
                .AddItem("Laptop")
                .AddGoodDeed("Learn PHP")
                .AddGoodDeed("Complete lab assignments to learn design patterns")
                .AddGoodDeed("Visit the university regularly")
                .UsingSuperPower("Burn the midnight oil")
                .Create();

            return hero;
        }

        public Character CreateTheMostEvilEnemy(IEnemyBuilder<EnemyBuilder> builder)
        {
            builder.Reset();

            var enemy = builder
                .WithName("Coursework Humanization")
                .WithStature("Muscular")
                .WithHeight(210)
                .WearingClothing("Black Luxury Jacket")
                .WithEyeColor("Red")
                .WithHairColor("Dark")
                .AddAlly("Anti-Plagiarism")
                .AddAlly("Procrastination")
                .AddAlly("Coursework Report")
                .AddItem("Coursework Methodology Recommendation")
                .AddEvilDeed("Kidnap all your time")
                .AddEvilDeed("Torture students")
                .UsingDarkPower("Inevitable Deadline")
                .Create();

            return enemy;
        }
    }
}
