using CommissionApp.Audit;
using CommissionApp;
using Microsoft.Extensions.DependencyInjection;
using CommissionApp.Components.CsvReader;
using CommissionApp.Data.Entities;
using CommissionApp.Data.Repositories;
using CommissionApp.Components.DataProviders;
using System;

var services = new ServiceCollection();

services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Customer>, ListRepository<Customer>>(); 
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICarsProvider, CarsProvider>();
services.AddSingleton<ICsvReader, CsvReader>();

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

