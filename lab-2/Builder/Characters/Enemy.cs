namespace Builder.Characters
{
    public class Enemy : Character
    {
        public string DarkPower { get; set; }
        public List<string> EvilDeeds { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Enemy, {base.ToString()}\nDark power: {DarkPower}\nEvil deeds: {string.Join(", ", EvilDeeds)}";
        }
    }
}
