using WarehouseLibrary.Helpers;
using WarehouseLibrary.Interfaces;
using WarehouseLibrary.Models;
using WarehouseLibrary.Services;

ICurrency uah = new Currency("USD", 1);
IWarehouse warehouse = new Warehouse();
WarehouseEventLogger eventLogger = new WarehouseEventLogger();
IReportGenerator<string> inventoryReportGenerator = new TextReportGenerator(uah);
IReporting<string> reporting = new Reporting<string>(eventLogger, inventoryReportGenerator);

ICurrency currency = new Currency("UAH", 42m);
IMoney apple_price = new Money(currency, 3, 50);
IMoney orange_price = new Money(currency, 12);
IProduct apple = new Product("Apple", "Very tasteful fruit", apple_price);
IProduct orange = new Product("Orange", "Very tasteful fruit", orange_price);

IWarehouseManager manager = new WarehouseManager(warehouse, eventLogger);
manager.AddItem(new WarehouseItem(apple, 200, DateTime.Now));
manager.AddItem(new WarehouseItem(orange, 70, DateTime.Now));
manager.AddItem(new WarehouseItem(apple, 30, DateTime.Now));
manager.RemoveItem(new WarehouseItem(apple, 100, DateTime.Now));
manager.RemoveItem(new WarehouseItem(orange, 20, DateTime.Now));
manager.RemoveItem(new WarehouseItem(orange, 45, DateTime.Now));

Console.WriteLine(reporting.GenerateIncomingReport());
Console.WriteLine(reporting.GenerateOutcomingReport());
Console.WriteLine(reporting.GenerateInventoryReport(warehouse));