using Decorator.Decorator;
using Decorator.Hero;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        IHero warrior = new Warrior();
        PrintFullHeroInfo(warrior);
        warrior = new WeaponDecorator(new ArmorDecorator(warrior));
        PrintFullHeroInfo(warrior);

        Console.WriteLine();

        IHero mage = new Mage();
        PrintFullHeroInfo(mage);
        mage = new ArtefactDecorator(mage);
        PrintFullHeroInfo(mage);

        Console.WriteLine();

        IHero palladin = new Palladin();
        PrintFullHeroInfo(palladin);
        palladin = new ArmorDecorator(new WeaponDecorator(new ArtefactDecorator(palladin)));
        PrintFullHeroInfo(palladin);
    }

    private static void PrintFullHeroInfo(IHero hero)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(hero.GetDetails());
        stringBuilder.AppendLine("Atack: " + hero.AttackPower);
        stringBuilder.AppendLine("Defense: " + hero.Defense);
        stringBuilder.AppendLine("Magic: " + hero.MagicPower);
        Console.WriteLine(stringBuilder.ToString());
    }
}