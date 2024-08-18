using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionApp.Data.Entities
{
    public class Customer : EntityBase
    {
        public Customer(string firstname, string lastname, string email, string price)
        {
        }
        public Customer()
        {
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? Email { get; set; }
        public decimal? Price { get; set; }
        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Premium: {Email}, Price EUR: {Price}";
    }
}