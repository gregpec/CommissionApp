using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionApp.Entities
{
    public class Car : EntityBase
    {
        public Car(string carbrand, string carmodel)
        {
        }
        public Car()
        {
        }
        public string? CarBrand { get; set; }
        public string? CarModel { get; set; }
        public override string ToString() => $"Id: {Id}, brand: {CarBrand}, model: {CarModel}"; 
    }
}
