using Prototype;

Virus covid19 = new Virus("COVID-19", "Coronavirus", 20, 240);

Virus delta = new Virus("Delta", "Coronavirus", 18, 180);
Virus omicron = new Virus("Omicron", "Coronavirus", 16, 120);

covid19.AddChild(delta);
covid19.AddChild(omicron);

Virus ay1 = new Virus("AY.1", "Coronavirus", 17, 60);
Virus ay2 = new Virus("AY.2", "Coronavirus", 14, 40);

delta.AddChild(ay1);
delta.AddChild(ay2);

Virus kraken = new Virus("Kraken", "Coronavirus", 15, 100);
Virus pirola = new Virus("Pirola", "Coronavirus", 14, 80);

omicron.AddChild(kraken);
omicron.AddChild(pirola);

Console.WriteLine("Original virus family:");
Console.WriteLine(covid19.ToStringWithChildren());

Virus clonedCovid = covid19.DeepClone();
Console.WriteLine("\nCloned virus family:");
Console.WriteLine(clonedCovid.ToStringWithChildren());

Console.WriteLine($"\nCloned and original virus same instance? {(covid19 == clonedCovid ? "Yes" : "No")}");

// If the parent is a child, its children won't be displayed to avoid recursion
pirola.AddChild(covid19);
Console.WriteLine("\nOriginal virus family with parent added as child:");
Console.WriteLine(covid19.ToStringWithChildren());