namespace Builder.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public string Stature { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Outfit { get; set; }
        public List<string> Allies { get; set; } = new List<string>();
        public List<string> Inventory { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Height: {Height}\n" +
                   $"Stature: {Stature}\n" +
                   $"Hair Color: {HairColor}\n" +
                   $"Eye Color: {EyeColor}\n" +
                   $"Outfit: {Outfit}\n" +
                   $"Allies: {string.Join(", ", Allies)}\n" +
                   $"Inventory: {string.Join(", ", Inventory)}";
        }
    }
}
