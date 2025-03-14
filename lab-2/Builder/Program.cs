using Builder.Builders.Implementations;
using Builder.Director;

ICharacterDirector director = new CharacterDirector();

var hero = director.CreateTheGreatestHero(new HeroBuilder());
var enemy = director.CreateTheMostEvilEnemy(new EnemyBuilder());

Console.WriteLine(hero);
Console.WriteLine("----------------");
Console.WriteLine(enemy);