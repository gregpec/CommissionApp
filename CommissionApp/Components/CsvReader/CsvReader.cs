using System;
using System.Collections.Generic;
using System.Linq;
using CommissionApp.Components.CsvReader.Extensions;
using CommissionApp.Data.Entities;

namespace CommissionApp.Components.CsvReader;

public class CsvReader : ICsvReader
{
    public List<Car> ProcessCars(string filePath)
    {

        if (!File.Exists(filePath))
        {
            return new List<Car>();
        }
        var cars = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToCar()
            ;
        return cars.ToList();
    }

    public List<Customer> ProcessCustomers(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Customer>();
        }
        var customers = File
          .ReadAllLines(filePath)
          .Where(x => x.Length > 1)
          .Select(x =>        //select bez extension
          {
              var columns = x.Split(',');
              return new Customer()
              {
                  FirstName = columns[0],
                  LastName = columns[1],
                  Email= bool.Parse(columns[2]),
                  Price = int.Parse(columns[3])
              };
          });

        return customers.ToList();
    }

}

