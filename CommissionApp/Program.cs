using CommissionApp;
using Microsoft.Extensions.DependencyInjection;
using CommissionApp.Components.CsvReader;
using CommissionApp.Data.Entities;
using CommissionApp.Data.Repositories;
using CommissionApp.Components.DataProviders;
using CommissionApp.Audit.ImportCsvToSqlAuditTxtFile;
using CommissionApp.Audit.InputToSqlAuditTxtFile;
using CommissionApp.JsonFile.ImportCsvToSqlExportJsonFile;

var services = new ServiceCollection();

services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Customer>, ListRepository<Customer>>(); 
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICarsProvider, CarsProvider>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IJsonFileService<Customer>>(new JsonFileService<Customer>("Resources\\Files\\Customers.json"));
services.AddSingleton<IJsonFileService<Car>>(new JsonFileService<Car>("Resources\\Files\\Car.json"));
services.AddSingleton<IImportCsvToSqlAuditTxtFile<Customer>>(new ImportCsvToSqlAuditTxtFile<Customer>("Resources\\Files\\Custom.txt"));
services.AddSingleton<IImportCsvToSqlAuditTxtFile<Car>>(new ImportCsvToSqlAuditTxtFile<Car>("Resources\\Files\\Ca.txt"));

services.AddTransient<IAudit>(provider =>
{
    string action = "[item Added!]";
    string itemData = "[itemData Added!]";

    return
         new JsonAudit($"{action}", $"{itemData}");
});

var serviceProvider = services.BuildServiceProvider(); 
var app = serviceProvider.GetService<IApp>()!;

app.Run(); 

