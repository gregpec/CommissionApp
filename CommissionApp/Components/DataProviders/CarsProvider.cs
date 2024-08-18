using CommissionApp.Data.Entities;
using CommissionApp.Data.Repositories;

namespace CommissionApp.Components.DataProviders
{
    public class CarsProvider : ICarsProvider
    {
        private readonly IRepository<Car> _carsRepository;
        public CarsProvider(IRepository<Car> carRepository)
        {
            _carsRepository = carRepository;
        }

        public Car GetCarWithMinimumPrice()
        {
            var minPriceCar = _carsRepository.GetAll()
                                      .OrderBy(car => car.CarPrice)
                                      .FirstOrDefault();
            return minPriceCar;

            void DisplayCarDetails(Car car)
            {
                if (car != null)
                {
                    Console.WriteLine($"ID: {car.Id}");
                    Console.WriteLine($"Brand: {car.CarBrand}");
                    Console.WriteLine($"Model: {car.CarModel}");
                    Console.WriteLine($"Price: {car.CarPrice:C}");
                }
                else
                {
                    Console.WriteLine("Car with minimum price not found.");
                }
            }
        }     
        public decimal GetMinimumPriceOfAllCars()
        {
            var cars = _carsRepository.GetAll();
            return cars.Select(x => x.CarPrice).Min();
        }
      
        public List<Car> OrderByName()
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderBy(x => x.CarBrand).ToList();          
        }

        public List<Car> GetCarsSortedByPrice()
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderBy(x => x.CarPrice).ToList();       
        }

        public List<Car> WhereStartsWithAndCostIsGraterThan(string prefix, decimal cost)
        {    
            cost = 150000;
            var cars = _carsRepository.GetAll();
            return cars.Where(x => x.CarModel.StartsWith(prefix) && x.CarPrice > cost).ToList(); 

        }   
        public List<string> DistinctAllCarModel()
        {
            var cars = _carsRepository.GetAll(); 
            return cars
                .Select(x => x.CarModel)
                .Distinct()
                .OrderBy(c => c) 
                .ToList();
        }

        public List<Car> DistinctByPrice()  
        {
            var cars = _carsRepository.GetAll();
            return cars
            .DistinctBy(x => x.CarPrice)
            .OrderBy(c => c.CarPrice)          
             .ToList();  
        }
    }
}

