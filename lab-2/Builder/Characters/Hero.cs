namespace Builder.Characters
{
    public class Hero : Character
    {
        public string SuperPower { get; set; }
        public List<string> GoodDeeds { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Hero, {base.ToString()}\nSuper power: {SuperPower}\nGood deeds: {string.Join(", ", GoodDeeds)}";
        }
    }
}
