using Abstract_Factory.EBooks;
using Abstract_Factory.Laptops;
using Abstract_Factory.Smartphones;

Smartphone smart = new BalaxySmartphone();
Console.WriteLine(smart.GetDetails());


EBook book = new IproneEbook();
Console.WriteLine(book.GetDetails());

Laptop laptop = new KiaomiLaptop();
Console.WriteLine(laptop.GetDetails());