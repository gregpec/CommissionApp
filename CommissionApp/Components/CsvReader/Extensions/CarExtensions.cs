using System.Globalization;
using CommissionApp.Data.Entities;

namespace CommissionApp.Components.CsvReader.Extensions
{
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source) //stworzenie samochodu na podstawie jednego source'a
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car
                {                  
                    CarBrand = columns[0],
                    CarModel = columns[1],
                    CarPrice = decimal.Parse(columns[2], CultureInfo.InvariantCulture),                  
                };
            }
        }
    }
}
