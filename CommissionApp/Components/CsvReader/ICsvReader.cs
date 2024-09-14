using CommissionApp.Data.Entities;

namespace CommissionApp.Components.CsvReader
{
    public interface ICsvReader
    {
        List<Car> ProcessCars(string filePath);
        List<Customer> ProcessCustomers(string filePathCustomer);
    }
}
