namespace Prototype
{
    public class Virus : IDeepCloneable<Virus>
    {
        public double WeightFg { get; set; }
        public int AgeHours { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Virus> Children { get; set; }

        public Virus(string name, string type, double weightFg, int ageHours)
        {
            Name = name;
            Type = type;
            WeightFg = weightFg;
            AgeHours = ageHours;
            Children = new List<Virus>();
        }

        public void AddChild(Virus child)
        {
            Children.Add(child);
        }

        public override string ToString()
        {
            return $"{Name} ({Type}), Weight: {WeightFg} fg, Age: {AgeHours} hours, Children: {Children.Count}";
        }

        public string ToStringWithChildren(HashSet<Virus>? visitedViruses = null, int level = 0)
        {
            if (visitedViruses == null)
                visitedViruses = new HashSet<Virus>();

            string indent = new string(' ', level * 2);

            string result = $"{indent}{this.ToString()}";

            if (!visitedViruses.Add(this))
                return result;

            foreach (var child in Children)
            {
                string childInfo = child.ToStringWithChildren(visitedViruses, level + 1);
                if (!string.IsNullOrEmpty(childInfo))
                    result += "\n" + childInfo;
            }

            return result;
        }

        public Virus DeepClone(IDictionary<Virus, Virus>? clonedViruses = null)
        {
            if (clonedViruses == null)
                clonedViruses = new Dictionary<Virus, Virus>();

            if (clonedViruses.ContainsKey(this))
                return clonedViruses[this];

            var virus = new Virus(Name, Type, WeightFg, AgeHours);
            clonedViruses[this] = virus;

            foreach (var child in Children)
                virus.AddChild(child.DeepClone(clonedViruses));

            return virus;
        }
    }
}
