using Abstract_Factory.Factories;
using Abstract_Factory.Interfaces;

List<ITechFactory> factories = new List<ITechFactory>();
factories.Add(new IProneFactory());
factories.Add(new KiaomiFactory());
factories.Add(new BalaxyFactory());

foreach (var factory in factories)
{
    List<IDevice> devices = new List<IDevice>();
    devices.Add(factory.CreateSmartphone());
    devices.Add(factory.CreateLaptop());
    devices.Add(factory.CreateEBook());
    devices.Add(factory.CreateSmartWatch());
    Console.WriteLine("Factory: " + factory.ToString() + "\n");
    foreach (var device in devices)
    {
        Console.Write(device.GetDetails());
        Console.WriteLine("-----------------");
    }
}