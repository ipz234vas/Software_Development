using Mediator;

var runway1 = new Runway();
var runway2 = new Runway();

var mediator = new CommandCentre(new[] { runway1, runway2 });

var planeA = new Aircraft("Plane A1", mediator);
var planeB = new Aircraft("Plane B2", mediator);
var planeC = new Aircraft("Plane C3", mediator);

planeA.Land();
Console.WriteLine();

planeB.Land();
Console.WriteLine();

planeC.Land();
Console.WriteLine();

planeA.TakeOff();
Console.WriteLine();

planeB.TakeOff();
Console.WriteLine();

planeC.Land();