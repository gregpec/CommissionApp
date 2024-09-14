namespace CommissionApp.Data.Entities
{
    public class Car : EntityBase
    {
        public Car(string carbrand, string carmodel, decimal carprice)
        {
        }
        public Car()
        {
        }
        public string? CarBrand { get; set; }
        public string? CarModel { get; set; }
        public decimal CarPrice { get; set; }
        public override string ToString() => $"Id: {Id}, brand: {CarBrand}, model: {CarModel}, price {CarPrice}";
    }
}


