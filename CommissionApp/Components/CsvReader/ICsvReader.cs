using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommissionApp.Components.CsvReader;
using CommissionApp.Data.Entities;

namespace CommissionApp.Components.CsvReader
{
    public interface ICsvReader
    {
        List<Car> ProcessCars(string filePath);

        List<Customer> ProcessCustomers(string filePathCustomer);
    }
}
