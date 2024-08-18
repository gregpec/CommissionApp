using CommissionApp.Data.Entities;

namespace CommissionApp.Components.DataProviders
{
    public interface ICarsProvider
    {
        public Car GetCarWithMinimumPrice();

        public List<string> DistinctAllCarModel();

        public List<Car> DistinctByPrice();
        
        decimal GetMinimumPriceOfAllCars()
        {
            throw new NotImplementedException();
        }

        //order by
        public List<Car> OrderByName()

        {
            throw new NotImplementedException();
        }
        public List<Car> GetCarsSortedByPrice()

        {
            throw new NotImplementedException();
        }
        public List<Car> WhereStartsWithAndCostIsGraterThan(string prefix, decimal cost);
    }
}
